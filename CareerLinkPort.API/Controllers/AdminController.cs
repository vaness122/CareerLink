using Microsoft.AspNetCore.Mvc;

namespace CareerLinkPort.API.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
