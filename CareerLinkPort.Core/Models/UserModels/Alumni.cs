using CareerLinkPort.Core.Models.JobModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.Core.Models.UserModels
{
   public class Alumni : AppUser
    {
        public string Bachelor {  get; set; }
        public string Skills { get; set; }
        public string? Resume {  get; set; }
        public virtual List<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}
