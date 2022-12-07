namespace TravelGuide.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;

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

            if (this.approveRepository.AllAsNoTracking().Any(a => a.User == user && a.Position == position))
            {
                return false;
            }

            await this.approveRepository.AddAsync(approve);
            await this.approveRepository.SaveChangesAsync();

            return true;
        }
    }
}
