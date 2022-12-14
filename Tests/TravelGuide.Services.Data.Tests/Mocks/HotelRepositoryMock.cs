namespace TravelGuide.Services.Data.Tests.Mocks
{
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Data.Repositories;

    public class HotelRepositoryMock
    {
        public static IDeletableEntityRepository<Hotel> Instance
        {
            get
            {
                var dbContextOptions = DatabaseMock.Instance;

                return new EfDeletableEntityRepository<Hotel>(dbContextOptions);
            }
        }
    }
}
