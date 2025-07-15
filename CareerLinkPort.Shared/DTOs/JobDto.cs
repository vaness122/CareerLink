using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.Shared.DTOs
{
  public class JobDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
        public string Type { get; set; }
        public string Requirements { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = false;
        public int Views { get; set; } = 0;

        public string EmployerId { get; set; }
    }
}
