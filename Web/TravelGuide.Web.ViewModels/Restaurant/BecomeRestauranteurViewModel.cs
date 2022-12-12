namespace TravelGuide.Web.ViewModels.Restaurant
{
    using System.ComponentModel.DataAnnotations;

    public class BecomeRestauranteurViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
