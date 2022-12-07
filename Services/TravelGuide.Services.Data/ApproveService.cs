namespace TravelGuide.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;

    public class ApproveService : IApproveService
    {
        private readonly IDeletableEntityRepository<Approve> approveService;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public ApproveService(
            IDeletableEntityRepository<Approve> approveService,
            IDeletableEntityRepository<ApplicationUser> userRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.approveService = approveService;
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

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

            if (this.approveService.AllAsNoTracking().Any(a => a.User == user && a.Position == position))
            {
                return false;
            }

            await this.approveService.AddAsync(approve);
            await this.approveService.SaveChangesAsync();

            return true;
        }
    }
}
