namespace TravelGuide.Web.ViewModels.Image
{
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Mapping;

    public class HotelImageViewModel : IMapFrom<HotelImage>
    {
        public string ImageUrl { get; set; }
    }
}
