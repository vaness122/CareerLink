using CareerLinkPort.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.BLL.Services
{
   public interface IUserService
    {
        Task<IdentityResult> RegisterEmployerAsync(EmployerRegistrationDto model);
        Task<IdentityResult> RegisterAlumniAsync(AlumniRegistrationDto model);
        Task<IdentityResult> RegisterAdminAsync(AdminRegistrationDto model);

        Task<IdentityResult> LoginEmployerAsync(EmployerLoginDto model);
        Task<IdentityResult> LoginAlumniAsync(AlumniLoginDto model);
        Task <IdentityResult> LoginAdminAsync(AdminLoginDto model);
    }
}
