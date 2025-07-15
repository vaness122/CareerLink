using Microsoft.AspNetCore.Mvc;

namespace CareerLinkPort.API.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
