namespace TravelGuide.Data.Configurations
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TravelGuide.Data.Models;

    public class AmenityHotelsConfiguration : IEntityTypeConfiguration<AmenityHotel>
    {
        public void Configure(EntityTypeBuilder<AmenityHotel> builder)
        {
            builder
                .HasKey(x => new { x.AmenityId, x.HotelId });
        }
    }
}
