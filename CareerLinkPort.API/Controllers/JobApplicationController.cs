using Microsoft.AspNetCore.Mvc;

namespace CareerLinkPort.API.Controllers
{
    //handling jobapplications of alumni
    public class JobApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
