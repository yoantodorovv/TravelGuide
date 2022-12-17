namespace TravelGuide.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Services.Mapping;

    /// <summary>
    /// Service for approves.
    /// </summary>
    public class ApproveService : IApproveService
    {
        private readonly IDeletableEntityRepository<Approve> approveRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly UserManager<ApplicationUser> userManager;

        /// <summary>
        /// IoC.
        /// </summary>
        /// <param name="approveRepository">Approve repository injection.</param>
        /// <param name="userRepository">User repository injection.</param>
        /// <param name="userManager">User manager injection.</param>
        public ApproveService(
            IDeletableEntityRepository<Approve> approveRepository,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.approveRepository = approveRepository;
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        /// <summary>
        /// Adds an approval, with the current user and position, to the DB.
        /// </summary>
        /// <returns>Boolean based on the success of the addition.</returns>
        public async Task<bool> AddToApprovalsAsync(string email, string position)
        {
            var user = await this.userManager.FindByEmailAsync(email);

            var approve = new Approve()
            {
                User = user,
                Position = position,
            };

            if (approve == null)
            {
                return false;
            }

            if (this.Contains(user.Id, position))
            {
                return false;
            }

            await this.approveRepository.AddAsync(approve);
            await this.approveRepository.SaveChangesAsync();

            return true;
        }

        public async Task<Approve> ApproveAsync(string approveId)
        {
            var approve = await this.GetByIdAsync(approveId);

            await this.userManager.AddToRoleAsync(approve.User, approve.Position);

            approve.IsApproved = true;

            await this.UpdateAsync(approve);

            return approve;
        }

        public bool Contains(Guid userId, string position) => this.approveRepository.AllAsNoTracking().Any(a => a.User.Id == userId && a.Position == position);

        public async Task UpdateAsync(Approve approve)
        {
            this.approveRepository.Update(approve);

            await this.approveRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Approve approve)
        {
            this.approveRepository.Delete(approve);

            await this.approveRepository.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync<T>() => await this.approveRepository.AllAsNoTracking()
            .Where(x => x.IsApproved == false)
            .OrderByDescending(x => x.CreatedOn)
            .To<T>()
            .ToListAsync();

        public async Task<Approve> GetByIdAsync(string id) => await this.approveRepository.All()
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Id.ToString() == id);

        public async Task<ICollection<T>> GetAllApprovedAsync<T>() => await this.approveRepository.AllAsNoTracking()
            .Where(x => x.IsApproved == true)
            .OrderByDescending(x => x.CreatedOn)
            .To<T>()
            .ToListAsync();

        public async Task<Approve> RejectAsync(string approveId)
        {
            var approve = await this.GetByIdAsync(approveId);

            await this.DeleteAsync(approve);

            return approve;
        }

        public async Task<ApplicationUser> DemoteAsync(string approveId)
        {
            var approve = await this.GetByIdAsync(approveId);

            var user = approve.User;

            await this.userManager.RemoveFromRoleAsync(user, approve.Position);

            approve.IsApproved = false;

            await this.UpdateAsync(approve);

            return user;
        }

        public async Task<ICollection<T>> GetAllRejectedAsync<T>() => await this.approveRepository.AllAsNoTrackingWithDeleted()
            .Where(x => x.IsApproved == false && x.IsDeleted == true)
            .OrderByDescending(x => x.CreatedOn)
            .To<T>()
            .ToListAsync();
    }
}
