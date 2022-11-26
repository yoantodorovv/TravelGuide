namespace TravelGuide.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Data.Models;
    using TravelGuide.Web.ViewModels;

    using static TravelGuide.Common.ErrorMessages.AccountErrorMessages;
    using static TravelGuide.Common.GlobalConstants;
    using static TravelGuide.Common.GlobalConstants.ActionsAndControllersConstants;

    public class AccountController : BaseController
    {
        //// TODO: Add profile drop down (from image) with options - View Profile, Account Info, Logout

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();

            return this.View(model);
        }

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
                UserName = model.FirstName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                //// EmailConfirmed = true,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await this.signInManager.SignInAsync(user, isPersistent: false);
                await this.userManager.AddToRoleAsync(user, UserRoleName);

                return this.RedirectToAction(HomeIndexActionConstant, HomeControllerConstant);
            }

            foreach (var item in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, item.Description);
            }

            return this.View(model);
        }

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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.userManager.FindByNameAsync(model.UsernameOrEmailField);

            if (user != null)
            {
                var isSucceeded = await this.SignInUserAsync(user, model);

                if (isSucceeded)
                {
                    if (model.ReturnUrl != null)
                    {
                        return this.Redirect(model.ReturnUrl);
                    }

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
                        return this.Redirect(model.ReturnUrl);
                    }

                    return this.RedirectToAction(HomeIndexActionConstant, HomeControllerConstant);
                }
            }

            // TODO: Add exception/error constants and vice versa.
            this.ModelState.AddModelError(string.Empty, InvalidLogin);

            return this.View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return this.RedirectToAction(HomeIndexActionConstant, HomeControllerConstant);
        }

        internal async Task<bool> SignInUserAsync(ApplicationUser user, LoginViewModel model)
        {
            var result = await this.signInManager.PasswordSignInAsync(user, model.Password, false, false);

            return result.Succeeded;
        }
    }
}
