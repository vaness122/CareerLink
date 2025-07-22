using Microsoft.AspNetCore.Mvc;

namespace CareerLinkPort.API.Controllers
{
    //create job //update job //delete job
    //see pending jobs
    //see approved jobs by the admin
    //handle job applications of alumni (change status of the application)
    //see pending job applications of alumni
    //update profile

    public class EmployerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
