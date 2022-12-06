﻿namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Threading.Tasks;

    using TravelGuide.Web.ViewModels.Hotel;

    public interface IHotelService
    {
        Task AddAsync(CreateHotelViewModel createHotelViewModel);
    }
}