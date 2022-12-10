namespace TravelGuide.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AmenityHotel
    {
        [ForeignKey(nameof(Hotel))]
        public Guid HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        [ForeignKey(nameof(Amenity))]
        public Guid AmenityId { get; set; }

        public virtual Amenity Amenity { get; set; }
    }
}
