using CareerLinkPort.Core.Models.JobModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.Core.Models.UserModels
{
    public class Employer : AppUser
    {
        public string CompanyName { get; set; }
        public string CompanyDescription {  get; set; }
        public string? CompanyLogo {get ; set; }
        public virtual List<Job> Jobs { get; set; } = new List<Job>();
    }
}
