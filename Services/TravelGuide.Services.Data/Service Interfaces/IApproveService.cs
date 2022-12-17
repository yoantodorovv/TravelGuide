namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;

    /// <summary>
    /// Interface for approve service.
    /// </summary>
    public interface IApproveService
    {
        Task<bool> AddToApprovalsAsync(string email, string position);

        bool Contains(Guid userId, string position);

        Task<ICollection<T>> GetAllAsync<T>();

        Task<ICollection<T>> GetAllApprovedAsync<T>();

        Task<ICollection<T>> GetAllRejectedAsync<T>();

        Task<Approve> GetByIdAsync(string id);

        Task<Approve> ApproveAsync(string approveId);

        Task<Approve> RejectAsync(string approveId);

        Task<ApplicationUser> DemoteAsync(string approveId);

        Task UpdateAsync(Approve approve);

        Task DeleteAsync(Approve approve);
    }
}
