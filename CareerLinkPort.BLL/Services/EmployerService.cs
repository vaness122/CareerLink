using CareerLinkPort.Core.Models.JobModels;
using CareerLinkPort.Core.Models.UserModels;
using CareerLinkPort.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.BLL.Services
{
    public class EmployerService : IEmployerService
    {
        public Task<bool> CreateJobAsync(Job job)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteJobAsync(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Job>> GetApprovedJobsAsync(string employerId)
        {
            throw new NotImplementedException();
        }

        public Task<Employer> GetEmployerByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<JobApplication> GetJobApplicationByIdAsync(int jobId, int applicationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<JobApplication>> GetJobApplicationsAsync(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task<List<JobApplication>> GetPendingApplicationsAsync(string employerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Job>> GetPendingApprovalJobsAsync(string employerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateApplicationStatusAsync(int jobId, int applicationId, string status, string notes)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEmployerProfileAsync(string id, EmployerUpdateDto model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateJobAsync(Job job)
        {
            throw new NotImplementedException();
        }
    }
}
