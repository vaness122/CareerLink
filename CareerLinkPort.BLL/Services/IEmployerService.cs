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
    
   public interface IEmployerService
    {
        Task<Employer> GetEmployerByIdAsync(string id);
        Task<bool> UpdateEmployerProfileAsync(string id, EmployerUpdateDto model);
        Task<List<JobApplication>> GetJobApplicationsAsync(int jobId);
        Task<JobApplication> GetJobApplicationByIdAsync(int jobId, int applicationId);
        Task<bool> UpdateApplicationStatusAsync(int jobId, int applicationId, string status, string notes);
        Task<List<JobApplication>> GetPendingApplicationsAsync(string employerId);
        Task<bool> CreateJobAsync(Job job);
        Task<bool> UpdateJobAsync(Job job);
        Task<bool> DeleteJobAsync(int jobId);
        Task<List<Job>> GetApprovedJobsAsync(string employerId);
        Task<List<Job>> GetPendingApprovalJobsAsync(string employerId);
    }
}
