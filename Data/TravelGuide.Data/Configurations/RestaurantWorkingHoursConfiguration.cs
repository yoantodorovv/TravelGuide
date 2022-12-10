namespace TravelGuide.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TravelGuide.Data.Models;

    public class RestaurantWorkingHoursConfiguration : IEntityTypeConfiguration<RestaurantWorkingHours>
    {
        public void Configure(EntityTypeBuilder<RestaurantWorkingHours> builder)
        {
            builder
                .HasKey(x => new { x.RestaurantId, x.WorkingHoursId });
        }
    }
}
