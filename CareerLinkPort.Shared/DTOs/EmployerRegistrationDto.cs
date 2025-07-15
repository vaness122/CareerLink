using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.Shared.DTOs
{
   public class EmployerRegistrationDto : UserRegistrationDto
    {
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string? CompanyLogo { get; set; }
    }
}
