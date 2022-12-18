namespace TravelGuide.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Ganss.Xss;
    using Microsoft.EntityFrameworkCore;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels.Utilities;

    public class AddressService : IAddressService
    {
        private readonly IDeletableEntityRepository<Address> addressRepository;
        private readonly ITownService townService;
        private readonly IHtmlSanitizer htmlSanitizer;

        public AddressService(
            IDeletableEntityRepository<Address> addressRepository,
            ITownService townService)
        {
            this.addressRepository = addressRepository;
            this.townService = townService;
            this.htmlSanitizer = new HtmlSanitizer();
        }

        public async Task<Address> GetAddressAsync<T>(T model)
            where T : CreateViewModel
        {
            Town foundTown = await this.townService.GetTownAsync<T>(model);

            var foundAddress = this.addressRepository.All()
                .Include(a => a.Town)
                .ToList()
                .FirstOrDefault(x => x.AddressText == model.AddressAddressText
            && x.Country == model.AddressCountry
            && x.Town.Name == model.AddressTownName);

            if (foundAddress == null)
            {
                foundAddress = new Address()
                {
                    AddressText = this.htmlSanitizer.Sanitize(model.AddressAddressText),
                    Country = this.htmlSanitizer.Sanitize(model.AddressCountry),
                    TownId = foundTown.Id,
                };

                await this.addressRepository.AddAsync(foundAddress);
                await this.addressRepository.SaveChangesAsync();
            }

            return foundAddress;
        }
    }
}
