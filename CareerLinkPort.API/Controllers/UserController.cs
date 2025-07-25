﻿// UserController.cs
using CareerLinkPort.BLL.Services;
using CareerLinkPort.Core.Models.UserModels;
using CareerLinkPort.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CareerLinkPort.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;

        public UserController(IUserService userService, IConfiguration configuration, UserManager<AppUser> userManager  )
        {
            _userService = userService;
            _configuration = configuration;
            _userManager = userManager;
        }


        // register API


        [HttpPost("register/employer")]
        public async Task<IActionResult> RegisterEmployer([FromBody] EmployerRegistrationDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RegisterEmployerAsync(model);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { Message = "Employer registration successful" });
        }

        [HttpPost("register/alumni")]
        public async Task<IActionResult> RegisterAlumni([FromBody] AlumniRegistrationDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RegisterAlumniAsync(model);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { Message = "Alumni registration successful" });
        }

        [HttpPost("register/admin")]
        [Authorize(Roles = "Admin")] // Only existing admins can register new admins
        public async Task<IActionResult> RegisterAdmin([FromBody] AdminRegistrationDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.RegisterAdminAsync(model);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { Message = "Admin registration successful" });
        }


        //login API


        [HttpPost("login/employer")]
        public async Task<IActionResult> LoginEmployer([FromBody] EmployerLoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.LoginEmployerAsync(model);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var user = await _userManager.FindByEmailAsync(model.Email);
            var token = await _userService.GenerateTokenAsync(user);

            return Ok(new
            {
                Token = token,
                Message = "Employer successfully logged in"
            });
        }


        [HttpPost("login/alumni")]
        public async Task<IActionResult> LoginAlumni([FromBody] AlumniLoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.LoginAlumniAsync(model);

            if (!result.Succeeded)
                return BadRequest(result.Errors);


            var user = await _userManager.FindByEmailAsync(model.Email);
            var token = await _userService.GenerateTokenAsync(user);

            return Ok(new
            {
                Token = token,
                Message = "Alumni successfully logged in"
            });
        }

        [HttpPost("login/admin")]
        public async Task<IActionResult> LoginAdmin([FromBody] AdminLoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.LoginAdminAsync(model);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            var user = await _userManager.FindByEmailAsync(model.Email);
            var token = await _userService.GenerateTokenAsync(user);

            return Ok(new
            {
                Token = token,
                Message = "Admin successfully logged in"
            });
        }





    }
}
