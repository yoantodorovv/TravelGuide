namespace TravelGuide.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TravelGuide.Data.Models;

    public class HotelWorkingHoursConfiguration : IEntityTypeConfiguration<HotelWorkingHours>
    {
        public void Configure(EntityTypeBuilder<HotelWorkingHours> builder)
        {
            builder
                .HasKey(x => new { x.HotelId, x.WorkingHoursId });
        }
    }
}
