namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;

    /// <summary>
    /// Interface for approve service.
    /// </summary>
    public interface IApproveService
    {
        Task<bool> AddToApprovalsAsync(string email, string position);

        bool Contains(Guid userId, string position);
    }
}
