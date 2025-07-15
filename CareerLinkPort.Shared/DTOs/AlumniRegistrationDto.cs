using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.Shared.DTOs
{
    public class AlumniRegistrationDto : UserRegistrationDto
    {
        public string Bachelor { get; set; }
        public string Skills { get; set; }
        public string? Resume { get; set; }
    }
}
