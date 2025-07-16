using CareerLinkPort.Core.Models.UserModels;
using CareerLinkPort.DAL.Data;
using CareerLinkPort.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly CareerLinkDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(CareerLinkDbContext context, UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
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

        //login

        public async Task<IdentityResult> LoginEmployerAsync(EmployerLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });

            if (!(user is Employer))
                return IdentityResult.Failed(new IdentityError { Description = "User is not an employer." });

            var inRole = await _userManager.IsInRoleAsync(user, "Employer");
            if (!inRole)
                return IdentityResult.Failed(new IdentityError { Description = "User is not in Employer role." });

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
                return IdentityResult.Failed(new IdentityError { Description = "Incorrect password." });

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> LoginAlumniAsync(AlumniLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });

            if (!(user is Alumni))
                return IdentityResult.Failed(new IdentityError { Description = "User is not an alumni." });

            var inRole = await _userManager.IsInRoleAsync(user, "Alumni");
            if (!inRole)
                return IdentityResult.Failed(new IdentityError { Description = "User is not in Alumni role." });

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
                return IdentityResult.Failed(new IdentityError { Description = "Incorrect password." });

            return IdentityResult.Success;
        }

        public async Task<IdentityResult> LoginAdminAsync(AdminLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });

            if (!(user is Admin))
                return IdentityResult.Failed(new IdentityError { Description = "User is not an admin." });

            var inRole = await _userManager.IsInRoleAsync(user, "Admin");
            if (!inRole)
                return IdentityResult.Failed(new IdentityError { Description = "User is not in Admin role." });

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
                return IdentityResult.Failed(new IdentityError { Description = "Incorrect password." });

            return IdentityResult.Success;
        }




        // token configuration
        public async Task<string> GenerateTokenAsync(AppUser user)
        {
            var authClaims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(ClaimTypes.Name, user.UserName)
    };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }





    }
}
