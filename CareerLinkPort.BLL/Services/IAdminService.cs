using CareerLinkPort.Core.Models.JobModels;
using CareerLinkPort.Core.Models.UserModels;
using CareerLinkPort.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.BLL.Services
{
    public interface IAdminService
    {
        Task<bool> ApproveJobAsync(int jobId);
        Task<bool> RejectJobAsync(int jobId);
        Task<List<Job>> GetAllPendingJobsAsync();
        Task<bool> ActivateUserAsync(string userId);
        Task<bool> DeactivateUserAsync(string userId);
        Task<List<AppUser>> GetAllUsersAsync();
        Task<IdentityResult> AddAdminAccAsync(AdminRegistrationDto model);
        Task<bool> CreateJobAsync(Job job);
        Task<bool> UpdateJobAsync(Job job);
        Task<bool> DeleteJobAsync(int jobId);
        Task<bool> UpdateAdminProfileAsync(string adminId, AdminUpdateDto model);



    }
}
