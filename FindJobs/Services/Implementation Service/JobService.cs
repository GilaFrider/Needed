using System;
using System.Collections.Generic;
using System.Linq;
using Repositiries;
using Repositiries.Api_Repo;
using Repositiries.Models;
using Services.Api_Service;
using Services.DTO;

namespace Services
{
    public class JobService : IJobService
    {
        private readonly IJobRepo _jobRepo;

        public JobService(ManagerRepo managerRepo)
        {
            _jobRepo = managerRepo.job;
        }

        public JobDTO Create(JobDTO jobDTO)
        { 
            var job = MapToJob(jobDTO);
            var createdJob = _jobRepo.Create(job);
            return MapToJobDTO(createdJob);
        }

        public JobDTO Delete(int code)
        {
            var deletedJob = _jobRepo.Delete(code);
            return MapToJobDTO(deletedJob);
        }

        public List<JobDTO> GetAll()
        {
            var jobs = _jobRepo.GetAll();
            return jobs.Select(j => MapToJobDTO(j)).ToList();
        }

        public JobDTO GetByCode(int code)
        {
            var job = _jobRepo.GetByCode(code);
            return job != null ? MapToJobDTO(job) : null;
        }

        public JobDTO Update(int code, JobDTO jobDto)
        {
            var job = MapToJob(jobDto);
            var updatedJob = _jobRepo.Update(code, job);
            return updatedJob != null ? MapToJobDTO(updatedJob) : null;
        }


        private Job MapToJob(JobDTO jobDto)
        {
            return new Job
            {
                Code = jobDto.Code,
                EmployersCode = jobDto.EmployersCode,
                FieldOfWorkCode = jobDto.FieldOfWorkCode,
                CriteriaCode = jobDto.CriteriaCode,
                CriteriaCodeNavigation = jobDto.CriteriaCodeNavigation != null ? new Criterion
                {
                    Code = jobDto.CriteriaCodeNavigation.Code,
                    SeveralYearsOfExperience = jobDto.CriteriaCodeNavigation?.SeveralYearsOfExperience,
                    Car = jobDto.CriteriaCodeNavigation?.Car,
                    NumberOfCvsSent = jobDto.CriteriaCodeNavigation?.NumberOfCvsSent,
                    Salary = jobDto.CriteriaCodeNavigation?.Salary,
                    Descriptions = jobDto.CriteriaCodeNavigation?.Descriptions,
                    //Jobs = (ICollection<Job>)jobDto.CriteriaCodeNavigation.Jobs.Select(j => j.Code).ToList()
                }: new Criterion { Code = jobDto.CriteriaCode },
                EmployersCodeNavigation = jobDto.EmployersCodeNavigation != null ? new Employer
                {
                    Code = jobDto.EmployersCodeNavigation.Code,
                    Email = jobDto.EmployersCodeNavigation?.Email,
                    Password = jobDto.EmployersCodeNavigation?.Password,
                    Phone = jobDto.EmployersCodeNavigation?.Phone,
                    Firstname = jobDto.EmployersCodeNavigation?.Firstname,
                    Lastname = jobDto.EmployersCodeNavigation?.Lastname,
                    CompanyName = jobDto.EmployersCodeNavigation?.CompanyName,
                    CompanyAddress = jobDto.EmployersCodeNavigation?.CompanyAddress,
                   // Jobs = (ICollection<Job>)(jobDto.EmployersCodeNavigation?.Jobs.Select(j => j.Code).ToList())
                }:new Employer { Code = jobDto.EmployersCode},
                FieldOfWorkCodeNavigation = jobDto.FieldOfWorkCodeNavigation != null ? new FieldOfWork
                {
                    Code = jobDto.FieldOfWorkCodeNavigation.Code,
                    FieldOfWorkName = jobDto.FieldOfWorkCodeNavigation?.FieldOfWorkName,
                    //Jobs = (ICollection<Job>)(jobDto.FieldOfWorkCodeNavigation?.Jobs.Select(j => j.Code).ToList())
                }:new FieldOfWork { Code = jobDto.FieldOfWorkCode}
                //CriteriaCodeNavigation = new Criterion { Code = jobDto.CriteriaCode },
                //EmployersCodeNavigation = new Employer { Code = jobDto.EmployersCode },
                //FieldOfWorkCodeNavigation = new FieldOfWork { Code = jobDto.FieldOfWorkCode }
            };
        }

        private JobDTO MapToJobDTO(Job job)
        {
            return new JobDTO
            {
                Code = job.Code,
                EmployersCode = job.EmployersCode,
                FieldOfWorkCode = job.FieldOfWorkCode,
                CriteriaCode = job.CriteriaCode,
                CriteriaCodeNavigation = job.CriteriaCodeNavigation != null ? new CriterionDTO
                {
                    Code = job.CriteriaCodeNavigation.Code,
                    SeveralYearsOfExperience = job.CriteriaCodeNavigation.SeveralYearsOfExperience,
                    Car = job.CriteriaCodeNavigation.Car,
                    NumberOfCvsSent = job.CriteriaCodeNavigation.NumberOfCvsSent,
                    Salary = job.CriteriaCodeNavigation.Salary,
                    Descriptions = job.CriteriaCodeNavigation.Descriptions,
                    //Jobs = job.CriteriaCodeNavigation.Jobs?.Select(j => j.Code).ToList()
                } : new CriterionDTO { Code = job.CriteriaCode},
                EmployersCodeNavigation = job.EmployersCodeNavigation != null ? new EmployerDTO
                {
                    Code = job.EmployersCodeNavigation.Code,
                    Email = job.EmployersCodeNavigation.Email,
                    Password = job.EmployersCodeNavigation.Password,
                    Phone = job.EmployersCodeNavigation.Phone,
                    Firstname = job.EmployersCodeNavigation.Firstname,
                    Lastname = job.EmployersCodeNavigation.Lastname,
                    CompanyName = job.EmployersCodeNavigation.CompanyName,
                    CompanyAddress = job.EmployersCodeNavigation.CompanyAddress,
                    //Jobs = job.EmployersCodeNavigation.Jobs?.Select(j => j.Code).ToList()
                } : new EmployerDTO { Code = job.EmployersCode},
                FieldOfWorkCodeNavigation = job.FieldOfWorkCodeNavigation != null ? new FieldOfWorkDTO
                {
                    Code = job.FieldOfWorkCodeNavigation.Code,
                    FieldOfWorkName = job.FieldOfWorkCodeNavigation.FieldOfWorkName,
                    //Jobs = job.FieldOfWorkCodeNavigation.Jobs?.Select(j => j.Code).ToList()
                } : new FieldOfWorkDTO { Code = job.FieldOfWorkCode}
            };
        }

    }
}
