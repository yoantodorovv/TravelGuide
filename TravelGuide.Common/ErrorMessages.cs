namespace TravelGuide.Common
{
    /// <summary>
    /// A static class for error messages.
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        /// Static class for become error messages.
        /// </summary>
        public static class BecomeErrorMessages
        {
            public const string SomethingWentWrong = "Something went wrong!";

            public const string CannotRequestApprovalMoreThanOnce = "You have already requested to become {0}. You cannot request to be approved for the possion of {1} more than once!";

            public const string InvalidEmail = "Email cannot be different from yours! Please try again.";
        }

        public static class RestaurantErrorMessages
        {
            public const string SomethingWentWrong = "Something went wrong!";
        }

        public static class HotelErrorMessages
        {
            public const string SomethingWentWrong = "Something went wrong!";
        }

        public static class ReservationErrorMessages
        {
            public const string SomethingWentWrong = "Something went wrong!";

            public const string DateCannotBeAlreadyPassed = "Date should not be already passed and should be within the working time of the restaurant. Please make sure you enter a valid date and time.";

            public const string AlreadyReserved = "Sorry, the {0} is already reserved! The {1} has no empty {2} unitl {3}.";
        }

        public static class CreateErrorMessages
        {
            public const string SomethingWentWrongException = "Something went wrong!";

            public const string AlreadyExistsException = "The {0} already exists!";

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
