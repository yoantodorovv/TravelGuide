namespace TravelGuide.Common
{
    /// <summary>
    /// A static class for error messages.
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        /// Static class for hotel error messages.
        /// </summary>
        public static class HotelErrorMessages
        {
            public const string SomethingWentWrong = "Something went wrong!";

            public const string CannotRequestApprovalMoreThanOnce = "You have already requested to become {0}. You cannot request to be approved for the possion of {1} more than once with the same email!";

            public const string InvalidEmail = "Email cannot be different from yours! Please try again.";
        }

        /// <summary>
        /// Static class for account error messages.
        /// </summary>
        public static class AccountErrorMessages
        {
            public const string InvalidLogin = "Invalid Login";
        }
    }
}
