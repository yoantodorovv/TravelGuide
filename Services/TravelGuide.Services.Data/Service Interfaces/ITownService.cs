namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Threading.Tasks;

    using TravelGuide.Data.Models;
    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Utilities;

    public interface ITownService
    {
        Task<Town> GetTownAsync<T>(T model)
            where T : CreateViewModel;
    }
}
