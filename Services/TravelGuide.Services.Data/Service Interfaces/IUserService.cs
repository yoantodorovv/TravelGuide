namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;

    public interface IUserService
    {
        Task<ApplicationUser> GetUser(string userId);

        Task<ICollection<Hotel>> GetUserHotelsAsync(string userId);
    }
}
