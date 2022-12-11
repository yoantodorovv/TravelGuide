namespace TravelGuide.Services.Data
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using TravelGuide.Services.Data.ServiceInterfaces;

    public class CloudinaryService : ICloudinaryService
    {
        private readonly IConfiguration configuration;
        private IConfiguration cloudinaryAccount;
        private Account account;
        private Cloudinary cloudinary;

        public CloudinaryService(IConfiguration configuration)
        {
            this.configuration = configuration;

            this.cloudinaryAccount = this.configuration.GetSection("Cloudinary");
            this.account = new Account(
                this.cloudinaryAccount["Cloud_Name"],
                this.cloudinaryAccount["API_Key"],
                this.cloudinaryAccount["Api_Secret"]);

            this.cloudinary = new Cloudinary(this.account);
        }

        // TODO: Turn it into collection of images
        public string UploadImage(IFormFile image)
        {
            var file = image;

            var uploadResult = new ImageUploadResult();

            if (file != null)
            {
                if (file.Length > 0)
                {
                    using var stream = file.OpenReadStream();
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream),
                        AssetFolder = "TravelGuide",
                    };

                    uploadResult = this.cloudinary.Upload(uploadParams);
                }

                return uploadResult.Url.ToString();
            }

            return string.Empty;
        }

        public IFormFile GetImage()
        {
            throw new System.NotImplementedException();
        }
    }
}
