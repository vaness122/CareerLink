using Microsoft.AspNetCore.Mvc;

namespace CareerLinkPort.API.Controllers
{
    //handling validations of users and job approval
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
