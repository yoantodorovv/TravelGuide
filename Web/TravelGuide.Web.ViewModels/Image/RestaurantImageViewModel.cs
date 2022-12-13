namespace TravelGuide.Web.ViewModels.Image
{
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;

    public class RestaurantImageViewModel : IMapFrom<RestaurantImage>
    {
        public string ImageUrl { get; set; }
    }
}
