namespace TravelGuide.Web.Controllers
{
    using System.Threading.Tasks;
    using Ganss.Xss;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Data.Models;
    using TravelGuide.Web.ViewModels.Account;

    using static TravelGuide.Common.ErrorMessages.AccountErrorMessages;
    using static TravelGuide.Common.GlobalConstants;
    using static TravelGuide.Common.GlobalConstants.ActionsAndControllersConstants;
    using static TravelGuide.Common.GlobalConstants.ToastrMessageConstants;
    using static TravelGuide.Common.SuccessMessages.AccountSuccessMessages;

    /// <summary>
    /// Controller responsible for the identity.
    /// </summary>
    public class AccountController : BaseController
    {
        //// TODO: Add profile drop down (from image) with options - View Profile, Account Info, Logout

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly IHtmlSanitizer htmlSanitizer;

        /// <summary>
        /// IoC.
        /// </summary>
        /// <param name="userManager">User manager injection.</param>
        /// <param name="signInManager">SingIn manager injection.</param>
        /// <param name="roleManager">Role manager injection.</param>
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.htmlSanitizer = new HtmlSanitizer();
        }

        /// <summary>
        /// Returns the view that visualises the register page.
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() => this.View(new RegisterViewModel());

        /// <summary>
        /// Registers an user.
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = new ApplicationUser()
            {
                UserName = this.htmlSanitizer.Sanitize(model.FirstName),
                FirstName = this.htmlSanitizer.Sanitize(model.FirstName),
                LastName = this.htmlSanitizer.Sanitize(model.LastName),
                Email = this.htmlSanitizer.Sanitize(model.Email),
                //// EmailConfirmed = true,
            };

            var result = await this.userManager.CreateAsync(user, this.htmlSanitizer.Sanitize(model.Password));

            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, isPersistent: false);
                await this.userManager.AddToRoleAsync(user, UserRoleName);

                this.TempData[SuccessMessage] = SuccessfullyRegistered;

                return this.RedirectToAction(nameof(this.Login));
            }

            foreach (var item in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, item.Description);
            }

            return this.View(model);
        }

        /// <summary>
        /// Returns the view that visualises the register page.
        /// </summary>
        /// <param name="returnUrl">Return path if the user has accessed a view that requires registration.</param>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
            };

            return this.View(model);
        }

        /// <summary>
        /// Logs an user in.
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.userManager.FindByNameAsync(this.htmlSanitizer.Sanitize(model.UsernameOrEmailField));

            if (user != null)
            {
                var isSucceeded = await this.SignInUserAsync(user, model);

                if (isSucceeded)
                {
                    if (model.ReturnUrl != null)
                    {
                        this.TempData[SuccessMessage] = SuccessfullyLogedIn;

                        return this.Redirect(model.ReturnUrl);
                    }

                    this.TempData[SuccessMessage] = SuccessfullyLogedIn;

                    return this.RedirectToAction(HomeIndexActionConstant, HomeControllerConstant);
                }
            }
            else if ((user = await this.userManager.FindByEmailAsync(model.UsernameOrEmailField)) != null)
            {
                var isSucceeded = await this.SignInUserAsync(user, model);

                if (isSucceeded)
                {
                    if (model.ReturnUrl != null)
                    {
                        this.TempData[SuccessMessage] = SuccessfullyLogedIn;

                        return this.Redirect(model.ReturnUrl);
                    }

                    this.TempData[SuccessMessage] = SuccessfullyLogedIn;

                    return this.RedirectToAction(HomeIndexActionConstant, HomeControllerConstant);
                }
            }

            this.TempData[ErrorMessage] = InvalidLogin;

            return this.View(model);
        }

        /// <summary>
        /// Logs out an user.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            this.TempData[SuccessMessage] = SuccessfullyLogedOut;

            return this.RedirectToAction(HomeIndexActionConstant, HomeControllerConstant);
        }

        /// <summary>
        /// Internal method that signs in the user with the current password.
        /// </summary>
        /// <param name="user">Current Application User.</param>
        /// <param name="model">LoginViewModel.</param>
        /// <returns>Boolean depending on whether the user has been signed in or not.</returns>
        internal async Task<bool> SignInUserAsync(ApplicationUser user, LoginViewModel model)
        {
            var result = await this.signInManager.PasswordSignInAsync(user, model.Password, false, false);

            return result.Succeeded;
        }
    }
}
