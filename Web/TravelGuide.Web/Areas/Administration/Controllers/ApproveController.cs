namespace TravelGuide.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Data.Models;
    using TravelGuide.Services.Data.ServiceInterfaces;
    using TravelGuide.Web.ViewModels.Administration.Approve;

    using static TravelGuide.Common.ErrorMessages.ApproveErrorMessages;
    using static TravelGuide.Common.GlobalConstants;
    using static TravelGuide.Common.GlobalConstants.ToastrMessageConstants;
    using static TravelGuide.Common.SuccessMessages.ApproveSuccessMessages;

    [Area("Administration")]
    [Authorize(Roles = AdministratorRoleName)]
    public class ApproveController : Controller
    {
        private readonly IApproveService approveService;

        public ApproveController(
            IApproveService approveService)
        {
            this.approveService = approveService;
        }

        public async Task<IActionResult> Index()
        {
            var approves = await this.approveService.GetAllAsync<ApproveViewModel>();

            return this.View(approves);
        }

        public async Task<IActionResult> ApprovedRequests()
        {
            var approves = await this.approveService.GetAllApprovedAsync<ApproveViewModel>();

            return this.View(approves);
        }

        public async Task<IActionResult> RejectedRequests()
        {
            var approves = await this.approveService.GetAllRejectedAsync<ApproveViewModel>();

            return this.View(approves);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            Approve approve = new();

            try
            {
                approve = await this.approveService.ApproveAsync(id);
            }
            catch (Exception ex)
            {
                this.TempData[ErrorMessage] = ex.Message;

                return this.RedirectToAction(nameof(this.Index));
            }

            this.TempData[SuccessMessage] = SuccessfullyApprovedUser;

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpPost]
        public async Task<IActionResult> Reject(string id)
        {
            if (id == null)
            {
                this.TempData[ErrorMessage] = SomethingWentWrong;

                return this.RedirectToAction(nameof(this.Index));
            }

            Approve approve = new();

            try
            {
                approve = await this.approveService.RejectAsync(id);
            }
            catch (Exception ex)
            {
                this.TempData[ErrorMessage] = ex.Message;

                return this.RedirectToAction(nameof(this.Index));
            }

            this.TempData[SuccessMessage] = SuccessfullyRejectedUser;

            return this.RedirectToAction(nameof(this.Index));
        }

        public async Task<IActionResult> Demote(string id)
        {
            ApplicationUser user = new();

            try
            {
                user = await this.approveService.DemoteAsync(id);
            }
            catch (Exception ex)
            {
                this.TempData[ErrorMessage] = ex.Message;

                return this.RedirectToAction(nameof(this.Index));
            }

            this.TempData[SuccessMessage] = SuccessfullyDemotedUser;

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
