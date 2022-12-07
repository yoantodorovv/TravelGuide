﻿namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using System;
    using System.Threading.Tasks;

    using TravelGuide.Web.ViewModels.Hotel;

    /// <summary>
    /// Interface for Hotel service.
    /// </summary>
    public interface IHotelService
    {
        /// <summary>
        /// Adds a hotel to the DB asynchroniously.
        /// </summary>
        Task AddAsync(CreateHotelViewModel createHotelViewModel, string userId, string imagePath);
    }
}
