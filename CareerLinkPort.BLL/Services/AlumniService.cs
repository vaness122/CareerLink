using CareerLinkPort.Core.Models.JobModels;
using CareerLinkPort.Core.Models.UserModels;
using CareerLinkPort.DAL.Repositories;
using CareerLinkPort.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.BLL.Services
{
    public class AlumniService : IAlumniService
    {

        private readonly IRepository<Alumni> _alumniRepository;
        private readonly IRepository<Job> _jobRepository;
        private readonly IRepository<JobApplication> _applicationRepository;
        private readonly UserManager<AppUser> _userManager;


        public AlumniService(
            IRepository<Alumni> alumniRepository,
            IRepository<Job> jobRepository,
            IRepository<JobApplication> applicationRepository,
            UserManager<AppUser> userManager)
        {
            _alumniRepository = alumniRepository;
            _jobRepository = jobRepository;
            _applicationRepository = applicationRepository;
            _userManager = userManager;
        }

        public Task<JobApplication> GetAlumniApplicationByIdAsync(string alumniId, int applicationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<JobApplication>> GetAlumniApplicationsAsync(string alumniId)
        {
            throw new NotImplementedException();
        }

        public Task<Alumni> GetAlumniByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Job>> SearchJobsAsync(string searchTerm, string location, string jobType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAlumniProfileAsync(string id, AlumniUpdateDto model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> WithdrawApplicationAsync(string alumniId, int applicationId)
        {
            throw new NotImplementedException();
        }
    }
}
