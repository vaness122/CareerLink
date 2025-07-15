using CareerLinkPort.Core.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.Core.Models.JobModels
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
        public string Type {get ; set; }
        public string Requirements {  get; set; }
        public DateTime PostedDate {get ; set; } = DateTime.Now;
        public bool IsActive { get; set; } = false;
        public int Views { get; set; } = 0;
        
        public string EmployerId { get; set; }
        public Employer Employer { get; set; }

        public List<JobApplication> Applications { get; set; } = new List<JobApplication>();

    }
}
