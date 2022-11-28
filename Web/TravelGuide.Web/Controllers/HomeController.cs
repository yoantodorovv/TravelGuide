namespace TravelGuide.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels;

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

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel()
            {
                HotelsToRender = this.homeUserService.GetAllHotelsToRender(),
                RestaurantsToRender = this.homeUserService.GetAllRestaurantsToRender(),
            };

            return this.View(model);
        }

        public IActionResult Search(HomeIndexViewModel model, string searchString)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            model.HotelsToRender = this.searchService.GetAllHotelsInSearchArea(searchString);
            model.RestaurantsToRender = this.searchService.GetAllRestaurantsInSearchArea(searchString);

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
