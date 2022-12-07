namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;

    public interface IApproveService
    {
        Task<bool> AddToApprovalsAsync(string email, string position);
    }
}
