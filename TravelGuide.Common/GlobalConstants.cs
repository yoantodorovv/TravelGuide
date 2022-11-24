namespace TravelGuide.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "TravelGuide";

        public const string AdministratorRoleName = "Administrator";
        public const string HotelierRoleName = "Hotelier";
        public const string RestauranteurRoleName = "Restauranteur";
        public const string UserRoleName = "User";

        public static class WorkingHoursConstants
        {
            public const int WeekDayMinLength = 5;
            public const int WeekDayMaxLength = 10;
        }

        public static class UserConstants
        {
            public const int FirstNameMinLength = 3;
            public const int FirstNameMaxLength = 50;

            public const int LastNameMinLength = 5;
            public const int LastNameMaxLength = 50;
        }

        public static class HotelConstants
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 25;

            public const int LocationMinLength = 5;
            public const int LocationMaxLength = 50;

            public const string PriceMinValue = "0.0";
            public const string PriceMaxValue = "1000.0";

            public const double RatingMinValue = 0;
            public const double RatingMaxValue = 5;

            public const int DetailsMinLength = 10;
            public const int DetailsMaxLength = 2000;

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 50;

            public const int WebsiteMinLength = 3;
            public const int WebsiteMaxLength = 255;
        }

        public static class HotelReservationConstants
        {
            public const string PriceMinValue = "0.0";
            public const string PriceMaxValue = "1000.0";
        }

        public static class RestaurantConstants
        {
            public const int NameMinLength = 5;
            public const int NameMaxLength = 50;

            public const double RatingMinValue = 0;
            public const double RatingMaxValue = 5;

            public const int LocationMinLength = 5;
            public const int LocationMaxLength = 50;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 2000;

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 50;

            public const int WebsiteMinLength = 3;
            public const int WebsiteMaxLength = 255;
        }

        public static class AmenityConstants
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 25;
        }

        public static class ReviewConstants
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 50;

            public const double RatingMinValue = 0.0;
            public const double RatingMaxValue = 5.0;

            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 300;
        }

        public static class DiscountConstants
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 25;

            public const string DiscountPercentageMinValue = "0";
            public const string DiscountPercentageMaxValue = "100";
        }
    }
}
