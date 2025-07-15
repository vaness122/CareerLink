using CareerLinkPort.Core.Models.JobModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.BLL.Services
{
   public interface IJobService
    {
        Task<List<Job>> GetAllJobsAsync();
        Task<Job> GetJobByIdAsync(int id);
        Task<List<Job>> GetByEmployerJobAsync(string employerId);
        Task<List<Job>> GetPendingJobsAsync();
        Task<bool> AddJobAsync(Job job);    
        Task <bool> UpdateJobAsync(Job job);
        Task<bool> DeleteJobAsync(int jobId , string employerId);
        Task<bool> ApproveJobsAsync(int jobId);
        Task IncrementViewCountAsync(int jobId);
        Task<List<Job>> GetMostViewedJobsAsync(int count = 5);
        Task<List<Job>> GetMostAppliedJobsAsync(int count = 5);

    }
}
