namespace TravelGuide.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;

    public class TownService : ITownService
    {
        private readonly IDeletableEntityRepository<Town> townRepository;

        public TownService(IDeletableEntityRepository<Town> townRepository)
        {
            this.townRepository = townRepository;
        }

        public async Task<Town> GetTownAsync(CreateHotelViewModel model)
        {
            var foundTown = this.townRepository.All().ToList().FirstOrDefault(x => x.Name == model.AddressTownName);

            if (foundTown == null)
            {
                var town = new Town()
                {
                    Name = model.AddressTownName,
                };

                await this.townRepository.AddAsync(town);
                await this.townRepository.SaveChangesAsync();

                foundTown = town;
            }

            return foundTown;
        }

        // FIXME: /New folder (Shared) in ViewModels/Create ViewModel containing AddressTownName and extend CreateHotelViewModel and CreateRestaurantViewModel with it. Then -> whete T : SpecialViewModel

        //public async Task<Town> AddTownAsync<T>(T model)
        //    where T : CreateHotelViewModel, CreateRestaurantViewModel
        //{
        //    var foundTown = this.townRepository.All().ToList().FirstOrDefault(x => x.Name == model.AddressTownName);

        //    if (foundTown == null)
        //    {
        //        var town = new Town()
        //        {
        //            Name = model.AddressTownName,
        //        };

        //        await this.townRepository.AddAsync(town);
        //        await this.townRepository.SaveChangesAsync();

        //        foundTown = town;
        //    }

        //    return foundTown;
        //}
    }
}
