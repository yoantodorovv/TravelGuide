namespace TravelGuide.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Base controller.
    /// </summary>
    [Authorize]
    public class BaseController : Controller
    {
    }
}
