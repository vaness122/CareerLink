using CareerLinkPort.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CareerLinkPort.Core.Models.JobModels;
using CareerLinkPort.Shared.DTOs;

namespace CareerLinkPort.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobsAsync();
            return Ok(jobs);
        }

        [HttpGet("getbyidincrementview/{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var job = await _jobService.GetJobByIdAsync(id);
            if (job == null) return NotFound();

            await _jobService.IncrementViewCountAsync(id);
            return Ok(job);
        }

        [HttpGet("employer/{employerId}")]
       // [Authorize(Roles = "Employer,Admin")]
        public async Task<IActionResult> GetEmployerJobs(string employerId)
        {
            var jobs = await _jobService.GetByEmployerJobAsync(employerId);
            return Ok(jobs);
        }

        [HttpGet("pending")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetPendingJobs()
        {
            var jobs = await _jobService.GetPendingJobsAsync();
            return Ok(jobs);
        }

        [HttpPost]
       // [Authorize(Roles = "Employer,Admin")]
        public async Task<IActionResult> CreateJob([FromBody] JobDto jobDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Map DTO to domain model
            var job = new Job
            {
                Title = jobDto.Title,
                Description = jobDto.Description,
                Location = jobDto.Location,
                Salary = jobDto.Salary,
                Type = jobDto.Type,
                Requirements = jobDto.Requirements,
                PostedDate = jobDto.PostedDate,
                IsActive = jobDto.IsActive,
                Views = jobDto.Views,
                EmployerId = jobDto.EmployerId
            };

            var result = await _jobService.AddJobAsync(job);
            if (!result)
                return BadRequest("Failed to create job");

            return CreatedAtAction(nameof(GetJob), new { id = job.Id }, job);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Employer,Admin")]
        public async Task<IActionResult> UpdateJob(int id, [FromBody] Job job)
        {
            if (id != job.Id) return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _jobService.UpdateJobAsync(job);
            if (!result)
                return BadRequest("Failed to update job");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Employer,Admin")]
     
        public async Task<IActionResult> DeleteJob(int id, [FromQuery] string employerId)
        {
            var result = await _jobService.DeleteJobAsync(id, employerId);
            if (!result)
                return Ok("Job not found or access denied");

            return Ok("Job deleted successfully");
        }



        [HttpPatch("approve/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveJob(int id)
        {
            var result = await _jobService.ApproveJobsAsync(id);
            if (!result)
                return BadRequest("Failed to approve job");

            return Ok(result);
        }

        [HttpGet("top/{count}")]
        public async Task<IActionResult> GetMostAppliedJobs(int count)
        {
            var jobs = await _jobService.GetMostAppliedJobsAsync(count);
            return Ok(jobs);
        }
    }
}
