using CareerLinkPort.Core.Models.JobModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.BLL.Services
{
    //should be handled by the employer
    public interface IJobApplicationService
    {
        Task<JobApplication> GetApplicationByIdAsync(int id);
        Task<List<JobApplication>> GetApplicationsByJobIdAsync(int jobId);
        Task<List<JobApplication>> GetApplicationsByAlumniIdAsync(string alumniId);
     
        Task<bool> UpdateApplicationAsync(JobApplication application);
        Task<bool> DeleteApplicationAsync(int id);
        Task<bool> ChangeApplicationStatusAsync(int applicationId, string status);
        Task<int> GetApplicationCountForJobAsync(int jobId);
    }
}
