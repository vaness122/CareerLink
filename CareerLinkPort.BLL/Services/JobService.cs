using CareerLinkPort.Core.Models.JobModels;
using CareerLinkPort.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerLinkPort.BLL.Services
{
    public class JobService : IJobService
    {
        private readonly IRepository<Job> _jobRepository;
        public JobService(IRepository<Job> jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task<bool> AddJobAsync(Job job)
        {
            try
            {
                if (string.IsNullOrEmpty(job.EmployerId))
                    throw new Exception("EmployerId is missing");

                await _jobRepository.AddAsync(job);
                var saved = await _jobRepository.SaveChangesAsync();
                return saved;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add job: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> ApproveJobsAsync(int jobId)
        {
            var job = await GetJobByIdAsync(jobId);
            if (job == null) return false;

            job.IsActive = true; 
            return await UpdateJobAsync(job);

        }

        public async Task<bool> DeleteJobAsync(int jobId , string employerId)
        {
            var job = await GetJobByIdAsync(jobId);
            if(job == null) return false;

             // if (job.EmployerId != employerId) return false;

            await _jobRepository.DeleteAsync(jobId);
            return await _jobRepository.SaveChangesAsync();
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
           return await _jobRepository.GetAllAsync() as List<Job>;
        }

        public async Task<List<Job>> GetByEmployerJobAsync(string employerId)

        {
            return await _jobRepository.FindAsync(j => j.EmployerId == employerId) as List<Job>;
        }

        public async Task<Job> GetJobByIdAsync(int id)
        {
            return await _jobRepository.GetByIdAsync(id);
        }

        public async Task<List<Job>> GetMostAppliedJobsAsync(int count = 5)
        {
            var jobs = await GetAllJobsAsync();
            return jobs.OrderByDescending(j => j.Applications.Count).Take(count).ToList();
        }

        public async Task<List<Job>> GetMostViewedJobsAsync(int count = 5)
        {
            var jobs = await GetAllJobsAsync();
            return jobs.OrderByDescending(j => j.Views).Take(count).ToList();


        }

        public async Task<List<Job>> GetPendingJobsAsync()
        {
            return await _jobRepository.FindAsync(j => !j.IsActive) as List<Job>;
        }

        public async Task IncrementViewCountAsync(int jobId)
        {
            var job = await GetJobByIdAsync(jobId);
            if(job != null)
            {
                job.Views++;
                await UpdateJobAsync(job);
            }   
        }

        public async Task<bool> UpdateJobAsync(Job job)
        {
            await _jobRepository.UpdateAsync(job);
            return await _jobRepository.SaveChangesAsync();
        }
    }
}
