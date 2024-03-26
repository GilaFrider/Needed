using Bl.DTO;
using DataBase.Dal_Api;
using DataBase.Models;
using DataBase;
using System;
using System.Collections.Generic;
using Bl.Bl_Api;

namespace Bl.Bl_Implementation
{
    public class BlJob : IBlJob
    {
        private readonly IJobRepo _jobRepo;

        public BlJob(DalManager dalManager)
        {
            _jobRepo = dalManager.job;
        }

        public List<JobDTO> GetAll()
        {
            try
            {
                List<Job> jobs = _jobRepo.GetAll();

                List<JobDTO> jobDTOs = jobs.Select(job => new JobDTO
                {
                    Code = job.Code,
                    EmployersCode = job.EmployersCode,
                    FieldOfWorkCode = job.FieldOfWorkCode,
                    CriteriaCode = job.CriteriaCode,
                    CriteriaCodeNavigation = new CriterionDTO
                    {
                        
                    },
                    EmployersCodeNavigation = new EmployerDTO
                    {
                        // Populate properties of EmployerDTO here
                    },
                    FieldOfWorkCodeNavigation = new FieldOfWorkDTO
                    {
                        // Populate properties of FieldOfWorkDTO here
                    }
                }).ToList();

                return jobDTOs;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get all jobs", ex);
            }
        }

        public JobDTO Create(JobDTO job)
        {
            Job j = new Job
            {
                Code = job.Code,
                EmployersCode = job.EmployersCode,
                FieldOfWorkCode = job.FieldOfWorkCode,
                CriteriaCode = job.CriteriaCode
            };

            _jobRepo.Create(j);

            return job;
        }

        public JobDTO Delete(int code)
        {
            Job j = _jobRepo.Delete(code);
             
            return new JobDTO
            {
                Code = j.Code,
                EmployersCode = j.EmployersCode,
                FieldOfWorkCode = j.FieldOfWorkCode,
                CriteriaCode = j.CriteriaCode
            };
        }

        //public void Update(int code, Job item)
        //{
        //    try
        //    {
        //        Job jobToUpdate = _jobRepo.GetByCode(jobDTO.Code);

        //        if (jobToUpdate == null)
        //        {
        //            throw new Exception("Job not found for updating");
        //        }

        //        // Update the job entity with the data from the JobDTO
        //        jobToUpdate.EmployersCode = jobDTO.EmployersCode;
        //        jobToUpdate.FieldOfWorkCode = jobDTO.FieldOfWorkCode;
        //        jobToUpdate.CriteriaCode = jobDTO.CriteriaCode;

        //        // You can update the related entities as well if needed
        //        jobToUpdate.CriteriaCodeNavigation.SeveralYearsOfExperience = jobDTO.CriteriaCodeNavigation.SeveralYearsOfExperience;
        //        // Update other properties as needed for CriteriaCodeNavigation, EmployersCodeNavigation, and FieldOfWorkCodeNavigation

        //        _jobRepo.Update(jobToUpdate);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Failed to update job", ex);
        //    }
        //}

        public JobDTO Update(int code, JobDTO item)
        {
            throw new NotImplementedException();
        }
    }
}