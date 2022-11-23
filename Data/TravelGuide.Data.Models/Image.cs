namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using TravelGuide.Data.Common.Models;

    public class Image : BaseDeletableModel<Guid>
    {
        [Required]
        public string Extension { get; set; }

        [Required]
        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }

        [Required]
        public virtual ApplicationUser Author { get; set; }

        [ForeignKey(nameof(Hotel))]
        public Guid? HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public Guid? RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
