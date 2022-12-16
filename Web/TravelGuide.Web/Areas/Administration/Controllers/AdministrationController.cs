namespace TravelGuide.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelGuide.Web.Controllers;

    using static TravelGuide.Common.GlobalConstants;

    [Authorize(Roles = $"{AdministratorRoleName}")]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
