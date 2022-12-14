namespace TravelGuide.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class BecomeHotelierViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
