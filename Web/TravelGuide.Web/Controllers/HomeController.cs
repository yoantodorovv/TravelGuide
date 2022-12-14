namespace TravelGuide.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels;
    using TravelGuide.Web.ViewModels.Home;
    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;

    /// <summary>
    /// Controller responsible for home functionality.
    /// </summary>
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly IHomeUserService homeUserService;
        private readonly ISearchService searchService;

        /// <summary>
        /// IoC.
        /// </summary>
        /// <param name="homeUserService">Home service injection.</param>
        /// <param name="searchService">Search service injection.</param>
        public HomeController(
            IHomeUserService homeUserService,
            ISearchService searchService)
        {
            this.homeUserService = homeUserService;
            this.searchService = searchService;
        }

        /// <summary>
        /// Returns the view that visualises the index page.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexViewModel()
            {
                HotelsToRender = await this.homeUserService.GetAllHotelsToRender<HotelPagingViewModel>(),
                RestaurantsToRender = await this.homeUserService.GetAllRestaurantsToRender<RestaurantPagingViewModel>(),
            };

            return this.View(model);
        }

        /// <summary>
        /// Searches ,for matching to the searchString, hotels or restaurants.
        /// </summary>
        public async Task<IActionResult> Search(HomeIndexViewModel model, string searchString)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            model.HotelsToRender = await this.searchService.GetAllHotelsInSearchArea<HotelPagingViewModel>(searchString);
            model.RestaurantsToRender = await this.searchService.GetAllRestaurantsInSearchArea<RestaurantPagingViewModel>(searchString);

            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        /// <summary>
        /// Returns error page.
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
