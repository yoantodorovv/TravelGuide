﻿namespace TravelGuide.Services.Data.ServiceInterfaces
{
    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        string UploadImage(IFormFile image);

        // TODO: Change return type.
        IFormFile GetImage();
    }
}
