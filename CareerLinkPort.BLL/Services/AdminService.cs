﻿using CareerLinkPort.Core.Models.JobModels;
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
    public class AdminService : IAdminService
    {
        public Task<bool> ActivateUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> AddAdminAccAsync(AdminRegistrationDto model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ApproveJobAsync(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateJobAsync(Job job)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeactivateUserAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteJobAsync(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Job>> GetAllPendingJobsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<AppUser>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RejectJobAsync(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAdminProfileAsync(string adminId, AdminUpdateDto model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateJobAsync(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
