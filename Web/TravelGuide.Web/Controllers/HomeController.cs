namespace TravelGuide.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels;
    using TravelGuide.Web.ViewModels.Home;

    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly IHomeUserService homeUserService;
        private readonly ISearchService searchService;

        public HomeController(
            IHomeUserService homeUserService,
            ISearchService searchService)
        {
            this.homeUserService = homeUserService;
            this.searchService = searchService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexViewModel()
            {
                HotelsToRender = await this.homeUserService.GetAllHotelsToRender(),
                RestaurantsToRender = await this.homeUserService.GetAllRestaurantsToRender(),
            };

            return this.View(model);
        }

        public async Task<IActionResult> Search(HomeIndexViewModel model, string searchString)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            model.HotelsToRender = await this.searchService.GetAllHotelsInSearchArea(searchString);
            model.RestaurantsToRender = await this.searchService.GetAllRestaurantsInSearchArea(searchString);

            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
