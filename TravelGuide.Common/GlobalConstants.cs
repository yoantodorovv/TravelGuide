﻿namespace TravelGuide.Common
{
    /// <summary>
    /// A class for all constants.
    /// </summary>
    public static class GlobalConstants
    {
        /// <summary>
        /// Administrative constants.
        /// </summary>
        public const string SystemName = "TravelGuide";

        public const string AdministratorRoleName = "Administrator";
        public const string HotelierRoleName = "Hotelier";
        public const string RestauranteurRoleName = "Restauranteur";
        public const string UserRoleName = "User";

        public const string AdministratorOrHotelier = $"{AdministratorRoleName}, {HotelierRoleName}";
        public const string AdministratorOrRestauranteur = $"{AdministratorRoleName}, {RestauranteurRoleName}";

        public static class SystemPathConstants
        {
            public const string SystemLoginPathConstant = "/Account/Login";
            public const string SystemExceptionHandlerPathConstant = "/Home/Error";
        }

        public static class ActionsAndControllersConstants
        {
            public const string HomeControllerConstant = "Home";
            public const string HomeIndexActionConstant = "Index";
        }

        public static class AddressConstants
        {
            public const int AddressMinLength = 2;
            public const int AddressMaxLength = 100;
        }

        public static class TownConstants
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 58;
        }

        /// <summary>
        /// WorkingHours class constants.
        /// </summary>
        public static class WorkingHoursConstants
        {
            public const int WeekDayMinLength = 5;
            public const int WeekDayMaxLength = 10;
        }

        /// <summary>
        /// User class constants.
        /// </summary>
        public static class UserConstants
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 75;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 75;

            public const int UsernameOrEmailFieldMinLength = FirstNameMinLength;
            public const int UsernameOrEmailFieldMaxLength = FirstNameMaxLength;
        }

        /// <summary>
        /// Hotel class constants.
        /// </summary>
        public static class HotelConstants
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 100;

            public const int LocationMinLength = 5;
            public const int LocationMaxLength = 100;

            public const string PriceMinValue = "0.0";
            public const string PriceMaxValue = "10000.0";

            public const double RatingMinValue = 0;
            public const double RatingMaxValue = 5;

            public const int DetailsMinLength = 10;
            public const int DetailsMaxLength = 3000;

            public const int WebsiteMinLength = 3;
            public const int WebsiteMaxLength = 255;
        }

        /// <summary>
        /// HotelReservations class constants.
        /// </summary>
        public static class HotelReservationConstants
        {
            public const string PriceMinValue = "0.0";
            public const string PriceMaxValue = "1000.0";
        }

        /// <summary>
        /// Restaurant class constants.
        /// </summary>
        public static class RestaurantConstants
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;

            public const double RatingMinValue = 0;
            public const double RatingMaxValue = 5;

            public const int LocationMinLength = 5;
            public const int LocationMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 3000;

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 150;

            public const int WebsiteMinLength = 3;
            public const int WebsiteMaxLength = 255;
        }

        /// <summary>
        /// Amenity class constants.
        /// </summary>
        public static class AmenityConstants
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 50;
        }

        /// <summary>
        /// Review class constants.
        /// </summary>
        public static class ReviewConstants
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 50;

            public const double RatingMinValue = 0.0;
            public const double RatingMaxValue = 5.0;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;
        }

        /// <summary>
        /// Discount class constants.
        /// </summary>
        public static class DiscountConstants
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 25;

            public const string DiscountPercentageMinValue = "0";
            public const string DiscountPercentageMaxValue = "100";
        }
    }
}
