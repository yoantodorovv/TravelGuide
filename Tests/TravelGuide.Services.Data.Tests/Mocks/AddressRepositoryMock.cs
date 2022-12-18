namespace TravelGuide.Services.Data.Tests.Mocks
{
    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Data.Repositories;

    public static class AddressRepositoryMock
    {
        public static IDeletableEntityRepository<Address> Instance
        {
            get
            {
                var dbContextOptions = DatabaseMock.Instance;

                return new EfDeletableEntityRepository<Address>(dbContextOptions);
            }
        }
    }
}
