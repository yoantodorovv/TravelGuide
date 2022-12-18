namespace TravelGuide.Services.Data.Tests.Mocks
{
    using System;

    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Data.Repositories;

    public static class TownRepositoryMock
    {
        public static IDeletableEntityRepository<Town> Instance
        {
            get
            {
                var dbContextOptions = DatabaseMock.Instance;

                return new EfDeletableEntityRepository<Town>(dbContextOptions);
            }
        }
    }
}
