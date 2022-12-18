namespace TravelGuide.Services.Data.Tests.Mocks
{
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Data.Repositories;

    public class RestaurantRepositoryMock
    {
        public static IDeletableEntityRepository<Restaurant> Instance
        {
            get
            {
                var dbContextOptions = DatabaseMock.Instance;

                return new EfDeletableEntityRepository<Restaurant>(dbContextOptions);
            }
        }
    }
}
