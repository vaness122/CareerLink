using CareerLinkPort.Core.Models.UserModels;
using CareerLinkPort.DAL.Data;
using CareerLinkPort.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly CareerLinkDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public UserService(CareerLinkDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IdentityResult> RegisterEmployerAsync(EmployerRegistrationDto model)
        {
            var employer = new Employer
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                BirthDate = model.BirthDate,
                CompanyName = model.CompanyName,
                CompanyDescription = model.CompanyDescription,
                CompanyLogo = model.CompanyLogo
            };

            var result = await _userManager.CreateAsync(employer, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(employer, "Employer");
            }

            return result;
        }

        public async Task<IdentityResult> RegisterAlumniAsync(AlumniRegistrationDto model)
        {
            var alumni = new Alumni
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                BirthDate = model.BirthDate,
                Bachelor = model.Bachelor,
                Skills = model.Skills,
                Resume = model.Resume
            };

            var result = await _userManager.CreateAsync(alumni, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(alumni, "Alumni");
            }

            return result;
        }

        public async Task<IdentityResult> RegisterAdminAsync(AdminRegistrationDto model)
        {
            var admin = new Admin
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                BirthDate = model.BirthDate
            };

            var result = await _userManager.CreateAsync(admin, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(admin, "Admin");
            }

            return result;


        }
    }
}
