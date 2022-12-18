namespace TravelGuide.Services.Data.Tests.Services
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Services.Data.Tests.Mocks;
    using TravelGuide.Services.Mapping;
    using TravelGuide.Web.ViewModels.Hotel;
    using Xunit;

    public class AddressServiceTest
    {
        public AddressServiceTest()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(CreateHotelViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public async Task GetAddressAsyncShouldReturnCorrectExistingObjectUponCall()
        {
            // Arrange
            var addressRepo = AddressRepositoryMock.Instance;
            var addressService = await this.GetAddressServiceAsync(addressRepo);

            var model = new CreateHotelViewModel()
            {
                AddressAddressText = "TestAddressText",
                AddressCountry = "TestAddressCountry",
                AddressTownName = "TestTownName",
            };

            // Act
            var address = await addressService.GetAddressAsync<CreateHotelViewModel>(model);

            // Assert
            Assert.NotNull(address);
            Assert.Equal(1, await addressRepo.AllAsNoTracking().CountAsync());
        }

        [Fact]
        public async Task GetAddressAsyncShouldReturnCorrectNewObjectUponCall()
        {
            // Arrange
            var addressRepo = AddressRepositoryMock.Instance;
            var addressService = await this.GetAddressServiceAsync(addressRepo);

            var model = new CreateHotelViewModel()
            {
                AddressAddressText = "TestAddressTextNew",
                AddressCountry = "TestAddressCountryNew",
                AddressTownName = "TestTownName",
            };

            // Act
            var address = await addressService.GetAddressAsync<CreateHotelViewModel>(model);

            // Assert
            Assert.NotNull(address);
            Assert.Equal(1, await addressRepo.AllAsNoTracking().CountAsync());
        }

        [Fact]
        public async Task GetAddressAsyncShouldReturnCorrectExistingObjectUponCallWithNewTown()
        {
            // Arrange
            var addressRepo = AddressRepositoryMock.Instance;
            var addressService = await this.GetAddressServiceAsync(addressRepo);

            var model = new CreateHotelViewModel()
            {
                AddressAddressText = "TestAddressTextNew",
                AddressCountry = "TestAddressCountryNew",
                AddressTownName = "TestTownNameNew",
            };

            // Act
            var address = await addressService.GetAddressAsync<CreateHotelViewModel>(model);

            // Assert
            Assert.NotNull(address);
            Assert.Equal(1, await addressRepo.AllAsNoTracking().CountAsync());
        }

        private async Task<IAddressService> GetAddressServiceAsync(IDeletableEntityRepository<Address> addressRepo)
        {
            using var data = DatabaseMock.Instance;

            await data.Towns.AddAsync(new Town()
            {
                Id = Guid.Parse("19abe34c-e1bb-4713-a0a9-f473fdd3ec25"),
                Name = "TestTownName",
            });

            await data.Addresses.AddAsync(new Address()
            {
                Id = Guid.Parse("5bdb93aa-bdf5-4075-ad79-a6287a048ac7"),
                AddressText = "TestAddressText",
                Country = "TestAddressCountry",
                TownId = Guid.Parse("19abe34c-e1bb-4713-a0a9-f473fdd3ec25"),
            });

            await data.SaveChangesAsync();

            var townRepo = TownRepositoryMock.Instance;

            var townService = new TownService(townRepo);

            return new AddressService(addressRepo, townService);
        }
    }
}
