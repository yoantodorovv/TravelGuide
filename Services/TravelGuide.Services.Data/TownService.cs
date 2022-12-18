namespace TravelGuide.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using Ganss.Xss;
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels.Utilities;

    public class TownService : ITownService
    {
        private readonly IDeletableEntityRepository<Town> townRepository;
        private readonly IHtmlSanitizer htmlSanitizer;

        public TownService(IDeletableEntityRepository<Town> townRepository)
        {
            this.townRepository = townRepository;
            this.htmlSanitizer = new HtmlSanitizer();
        }

        public async Task<Town> GetTownAsync<T>(T model)
            where T : CreateViewModel
        {
            var foundTown = this.townRepository.All().ToList().FirstOrDefault(x => x.Name == model.AddressTownName);

            if (foundTown == null)
            {
                var town = new Town()
                {
                    Name = this.htmlSanitizer.Sanitize(model.AddressTownName),
                };

                await this.townRepository.AddAsync(town);
                await this.townRepository.SaveChangesAsync();

                foundTown = town;
            }

            return foundTown;
        }
    }
}
