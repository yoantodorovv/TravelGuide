namespace TravelGuide.Web.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static TravelGuide.Common.GlobalConstants.UserConstants;

    public class LoginViewModel
    {
        [Required]
        [StringLength(UsernameOrEmailFieldMaxLength, MinimumLength = UsernameOrEmailFieldMinLength)]
        public string UsernameOrEmailField { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [UIHint("hidden")]
        public string ReturnUrl { get; set; }
    }
}
