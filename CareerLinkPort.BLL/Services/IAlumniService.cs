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
   public interface IAlumniService
    {
        Task<Alumni> GetAlumniByIdAsync(string id);
        Task<bool> UpdateAlumniProfileAsync(string id, AlumniUpdateDto model);
        Task<List<JobApplication>> GetAlumniApplicationsAsync(string alumniId);
        Task<JobApplication> GetAlumniApplicationByIdAsync(string alumniId, int applicationId);
        
        Task<bool> WithdrawApplicationAsync(string alumniId, int applicationId);
        Task<List<Job>> SearchJobsAsync(string searchTerm, string location, string jobType);
    }
}
