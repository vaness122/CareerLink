using Microsoft.AspNetCore.Mvc;

namespace CareerLinkPort.API.Controllers
{
    //apply jobs  
    //see application status
    //see applied jobs
    //update profile
    public class AlumniController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
