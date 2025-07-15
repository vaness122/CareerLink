using CareerLinkPort.Core.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.Core.Models.JobModels
{
    public class JobApplication
    {
        public int Id { get; set; }
        public DateTime AppliedDate { get; set; }
        public string Status { get; set; } = "Applied";
        public string? Notes {get ; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public string AlumniId { get; set; }
        public Alumni Alumni { get; set; }

    }
}
