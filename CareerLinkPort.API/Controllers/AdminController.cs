using Microsoft.AspNetCore.Mvc;

namespace CareerLinkPort.API.Controllers
{
    //create job //update job //delete job
    //validate user registration of employer (see if it is active or not, change status )
    //approve jobs being created by the employer(jobs created by the employer must be approved by the admin first before letting it appear on the web)
    //can also create job(and the job will automatically appear)
    //update profile

    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
