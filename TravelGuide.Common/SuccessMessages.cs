namespace TravelGuide.Common
{
    public static class SuccessMessages
    {
        public static class AccountSuccessMessages
        {
            public const string SuccessfullyRegistered = "You have successfully registered!";

            public const string SuccessfullyLogedIn = "You have successfully loged in!";

            public const string SuccessfullyLogedOut = "You have successfully loged out!";
        }

        public static class CreateSuccessMessages
        {
            public const string SuccessfullyCreated = "The {0} was successfully created!";
        }

        public static class ReservationSuccessMessages
        {
            public const string SuccessfullyCreatedReservation = "The reservation has been successfully made! We are looking forward to seeing you soon!";
        }

        public static class BecomeSuccessMessages
        {
            public const string SuccessfullyRequested = "You have successfully requested to become {0}! Your request will be reviewed soon.";
        }
    }
}
