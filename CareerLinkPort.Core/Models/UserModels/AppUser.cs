
using CareerLinkPort.Core.Models.JobModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.Core.Models.UserModels
{
   public class AppUser : IdentityUser
    {
        public string FullName {  get; set; }
        public DateTime BirthDate { get; set; }
        public string? ProfilePicture { get; set; }
        public bool isActive { get; set; } = false;
        public virtual ICollection<Notification> Notifications { get; set; }

    }
}
