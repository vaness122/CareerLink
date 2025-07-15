using Microsoft.AspNetCore.Mvc;

namespace CareerLinkPort.API.Controllers
{
    public class AdminControl : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
