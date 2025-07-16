using Microsoft.AspNetCore.Mvc;

namespace CareerLinkPort.API.Controllers
{
    public class JobApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
