namespace TravelGuide.Data.Configurations
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TravelGuide.Data.Models;

    public class AmenityHotelsConfiguration : IEntityTypeConfiguration<AmenityHotels>
    {
        public void Configure(EntityTypeBuilder<AmenityHotels> builder)
        {
            builder
                .HasKey(x => new { x.AmenityId, x.HotelId });
        }
    }
}
