using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Repositories.ApiRepo;
using Repositories.Models;
using Services.ApiService;
using Services.DTO;

namespace Services.ImplementationService
{
    public class JobService : IJobService
    {
        private readonly IJobRepo _jobRepo;
        private readonly IMapper _mapper;
        
        public JobService(IJobRepo jobRepo, IMapper mapper)
        {
            _jobRepo = jobRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<JobDTO>> GetAllAsync()
        {
            var jobs = await _jobRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<JobDTO>>(jobs);
        }

        public async Task<JobDTO> GetByIdAsync(int id)
        {
            var job = await _jobRepo.GetByIdAsync(id);
            return _mapper.Map<JobDTO>(job);
        }

        public async Task CreateAsync(JobDTO jobDto)
        {
            var job = _mapper.Map<Job>(jobDto);
            await _jobRepo.CreateAsync(job);
        }

        public async Task UpdateAsync(JobDTO jobDto)
        {
            //var job = _mapper.Map<Job>(jobDto);
            //await _jobRepo.UpdateAsync(job);
            var existingJob = await _jobRepo.GetByIdAsync(jobDto.Code);

            if (existingJob == null)
            {
                throw new InvalidOperationException("Job not found.");
            }

            // Map the updated fields from jobDto to the existing job entity
            _mapper.Map(jobDto, existingJob);

            // Update the existing job entity
            await _jobRepo.UpdateAsync(existingJob);
        }

        public async Task DeleteAsync(int id)
        {
            await _jobRepo.DeleteAsync(id);
        }
    }
}
