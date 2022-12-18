namespace TravelGuide.Services.Data.Tests.Services
{
    using System;
    using System.Reflection;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Services.Data.Tests.Mocks;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.Hotel;
    using Xunit;

    public class TownServiceTest
    {
        public TownServiceTest()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(CreateHotelViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public async Task GetTownAsyncShouldReturnCorrectExistingTown()
        {
            // Arrange
            var townRepo = TownRepositoryMock.Instance;
            var townService = await this.GetTownServiceAsync(townRepo);

            var model = new CreateHotelViewModel()
            {
                AddressAddressText = "TestAddressText",
                AddressCountry = "TestAddressCountry",
                AddressTownName = "TestTownName",
            };

            // Act
            var town = await townService.GetTownAsync<CreateHotelViewModel>(model);

            // Assert
            Assert.NotNull(town);
            Assert.Equal(1, await townRepo.AllAsNoTracking().CountAsync());
        }

        [Fact]
        public async Task GetTownAsyncShouldReturnCorrectNewTown()
        {
            // Arrange
            var townRepo = TownRepositoryMock.Instance;
            var townService = await this.GetTownServiceAsync(townRepo);

            var model = new CreateHotelViewModel()
            {
                AddressAddressText = "TestAddressTextNew",
                AddressCountry = "TestAddressCountryNew",
                AddressTownName = "TestTownNameNew",
            };

            // Act
            var town = await townService.GetTownAsync<CreateHotelViewModel>(model);

            // Assert
            Assert.NotNull(town);
            Assert.Equal(1, await townRepo.AllAsNoTracking().CountAsync());
        }

        public async Task<ITownService> GetTownServiceAsync(IDeletableEntityRepository<Town> townRepo)
        {
            using var data = DatabaseMock.Instance;

            await data.Towns.AddAsync(new Town()
            {
                Id = Guid.Parse("19abe34c-e1bb-4713-a0a9-f473fdd3ec25"),
                Name = "TestTownName",
            });

            await data.SaveChangesAsync();

            var townService = new TownService(townRepo);

            var count = await townRepo.AllAsNoTracking().CountAsync();

            return new TownService(townRepo);
        }
    }
}
