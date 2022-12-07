namespace TravelGuide.Common
{
    using System;

    public static class ErrorMessages
    {
        public static class HotelErrorMessages
        {
            public const string CannotRequestApprovalMoreThanOnce = "You have already requested to become {0}. You cannot request to be approved for the possion of {1} more than once with the same email!";

            public const string InvalidEmail = "Email cannot be different from yours! Please try again.";
        }

        public static class AccountErrorMessages
        {
            public const string InvalidLogin = "Invalid Login";
        }
    }
}
