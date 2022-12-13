namespace TravelGuide.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TravelGuide.Data.Common.Repositories;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels.Hotel;
    using TravelGuide.Web.ViewModels.Restaurant;

    public class WorkingHoursService : IWorkingHoursService
    {
        private readonly IDeletableEntityRepository<WorkingHours> workingHoursRepository;
        private readonly IRepository<HotelWorkingHours> hotelWorkingHoursRepository;
        private readonly IRepository<RestaurantWorkingHours> restaurantWorkingHoursRepository;

        public WorkingHoursService(
            IDeletableEntityRepository<WorkingHours> workingHoursRepository,
            IRepository<HotelWorkingHours> hotelWorkingHoursRepository,
            IRepository<RestaurantWorkingHours> restaurantWorkingHoursRepository)
        {
            this.workingHoursRepository = workingHoursRepository;
            this.hotelWorkingHoursRepository = hotelWorkingHoursRepository;
            this.restaurantWorkingHoursRepository = restaurantWorkingHoursRepository;
        }

        public async Task AddWorkingHoursToHotelAsync(CreateHotelViewModel model, Guid hotelId)
        {
            int workingHoursRegistrationTime = (int.Parse(model.WorkingHoursRegistrationTime.Split(":")[0]) * 60) + int.Parse(model.WorkingHoursRegistrationTime.Split(":")[1]);
            int workingHoursLeaveTime = (int.Parse(model.WorkingHoursLeaveTime.Split(":")[0]) * 60) + int.Parse(model.WorkingHoursLeaveTime.Split(":")[1]);

            var foundWorkingHour = this.workingHoursRepository.All().ToList().FirstOrDefault(x => x.Text == model.WorkingHoursText
                && x.RegistrationTime == workingHoursRegistrationTime
                && x.LeaveTime == workingHoursLeaveTime);

            if (foundWorkingHour == null)
            {
                await this.hotelWorkingHoursRepository.AddAsync(new HotelWorkingHours()
                {
                    HotelId = hotelId,
                    WorkingHours = new WorkingHours()
                    {
                        Text = model.WorkingHoursText,
                        RegistrationTime = workingHoursRegistrationTime,
                        LeaveTime = workingHoursLeaveTime,
                    },
                });
            }
            else
            {
                await this.hotelWorkingHoursRepository.AddAsync(new HotelWorkingHours()
                {
                    HotelId = hotelId,
                    WorkingHoursId = foundWorkingHour.Id,
                });
            }

            await this.hotelWorkingHoursRepository.SaveChangesAsync();
        }

        public async Task AddWorkingHoursToRestaurantAsync(CreateRestaurantViewModel model, Guid restaurantId)
        {
            int workingHoursRegistrationTime = (int.Parse(model.WorkingHoursRegistrationTime.Split(":")[0]) * 60) + int.Parse(model.WorkingHoursRegistrationTime.Split(":")[1]);
            int workingHoursLeaveTime = (int.Parse(model.WorkingHoursLeaveTime.Split(":")[0]) * 60) + int.Parse(model.WorkingHoursLeaveTime.Split(":")[1]);

            var foundWorkingHour = this.workingHoursRepository.All().ToList().FirstOrDefault(x => x.Text == model.WorkingHoursText
                && x.RegistrationTime == workingHoursRegistrationTime
                && x.LeaveTime == workingHoursLeaveTime);

            if (foundWorkingHour == null)
            {
                await this.restaurantWorkingHoursRepository.AddAsync(new RestaurantWorkingHours()
                {
                    RestaurantId = restaurantId,
                    WorkingHours = new WorkingHours()
                    {
                        Text = model.WorkingHoursText,
                        RegistrationTime = workingHoursRegistrationTime,
                        LeaveTime = workingHoursLeaveTime,
                    },
                });
            }
            else
            {
                await this.restaurantWorkingHoursRepository.AddAsync(new RestaurantWorkingHours()
                {
                    RestaurantId = restaurantId,
                    WorkingHoursId = foundWorkingHour.Id,
                });
            }

            await this.restaurantWorkingHoursRepository.SaveChangesAsync();
        }
    }
}
