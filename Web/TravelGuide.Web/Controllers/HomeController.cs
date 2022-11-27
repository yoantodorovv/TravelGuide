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

        public HomeController(IHomeUserService homeUserService)
        {
            this.homeUserService = homeUserService;
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

            //// TODO: Implement search logic and use searchService

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
