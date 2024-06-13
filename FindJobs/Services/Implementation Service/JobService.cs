
using System;
using System.Collections.Generic;
using Services.Api_Service;
using Services.DTO;
using Repositiries;
using Repositiries.Api_Repo;
using Repositiries.Models;

namespace Services.Implementation_Service
{
    public class JobService : IJobService
    {
        private readonly IJobRepo _jobRepo;

        public JobService(ManagerRepo manager)
        {
            _jobRepo = manager.job;
        }

        public List<JobDTO> GetAll()
        {
            try
            {
                var jobs = _jobRepo.GetAll();

                var jobDTOs = jobs.Select(j => new JobDTO
                {
                    Code = j.Code,
                    EmployersCode = j.EmployersCode,
                    FieldOfWorkCode = j.FieldOfWorkCode,
                    CriteriaCode = j.CriteriaCode,
                    CriteriaCodeNavigation = new CriterionDTO
                    {
                        Code = j.CriteriaCodeNavigation.Code,
                        SeveralYearsOfExperience = j.CriteriaCodeNavigation.SeveralYearsOfExperience,
                        Car = j.CriteriaCodeNavigation.Car,
                        NumberOfCvsSent = j.CriteriaCodeNavigation.NumberOfCvsSent,
                        Salary = j.CriteriaCodeNavigation.Salary,
                        Descriptions = j.CriteriaCodeNavigation.Descriptions
                    },
                    EmployersCodeNavigation = new EmployerDTO
                    {
                        Code = j.EmployersCodeNavigation.Code,
                        Email = j.EmployersCodeNavigation.Email,
                        Phone = j.EmployersCodeNavigation.Phone,
                        Firstname = j.EmployersCodeNavigation.Firstname,
                        Lastname = j.EmployersCodeNavigation.Lastname,
                        CompanyName = j.EmployersCodeNavigation.CompanyName,
                        CompanyAddress = j.EmployersCodeNavigation.CompanyAddress
                    },
                    FieldOfWorkCodeNavigation = new FieldOfWorkDTO
                    {
                        Code = j.FieldOfWorkCodeNavigation.Code,
                        FieldOfWorkName = j.FieldOfWorkCodeNavigation.FieldOfWorkName
                    }
                }).ToList();

                return jobDTOs;
            }
            catch (Exception ex)
            {
                // התנהגות מתאימה לטיפול בשגיאות
                throw;
            }
        }

        //public JobDTO GetJobByCode(int code)
        //{
        //    try
        //    {
        //        var job = _jobRepo.GetByCode(code);

        //        if (job == null)
        //        {
        //            throw new Exception("Job not found");
        //        }

        //        var jobDTO = new JobDTO
        //        {
        //            Code = job.Code,
        //            EmployersCode = job.EmployersCode,
        //            FieldOfWorkCode = job.FieldOfWorkCode,
        //            CriteriaCode = job.CriteriaCode,
        //            CriteriaCodeNavigation = new CriterionDTO
        //            {
        //                Code = job.CriteriaCodeNavigation.Code,
        //                SeveralYearsOfExperience = job.CriteriaCodeNavigation.SeveralYearsOfExperience,
        //                Car = job.CriteriaCodeNavigation.Car,
        //                NumberOfCvsSent = job.CriteriaCodeNavigation.NumberOfCvsSent,
        //                Salary = job.CriteriaCodeNavigation.Salary,
        //                Descriptions = job.CriteriaCodeNavigation.Descriptions
        //            },
        //            EmployersCodeNavigation = new EmployerDTO
        //            {
        //                Code = job.EmployersCodeNavigation.Code,
        //                Email = job.EmployersCodeNavigation.Email,
        //                Phone = job.EmployersCodeNavigation.Phone,
        //                Firstname = job.EmployersCodeNavigation.Firstname,
        //                Lastname = job.EmployersCodeNavigation.Lastname,
        //                CompanyName = job.EmployersCodeNavigation.CompanyName,
        //                CompanyAddress = job.EmployersCodeNavigation.CompanyAddress
        //            },
        //            FieldOfWorkCodeNavigation = new FieldOfWorkDTO
        //            {
        //                Code = job.FieldOfWorkCodeNavigation.Code,
        //                FieldOfWorkName = job.FieldOfWorkCodeNavigation.FieldOfWorkName
        //            }
        //        };

        //        return jobDTO;
        //    }
        //    catch (Exception ex)
        //    {
        //        // התנהגות מתאימה לטיפול בשגיאות
        //        throw;
        //    }
        //}

        public JobDTO Create(JobDTO jobDTO)
        {
            try
            {
                var jobEntity = new Job
                {
                    // המרת ה-DTO ל-Entity
                    EmployersCode = jobDTO.EmployersCode,
                    FieldOfWorkCode = jobDTO.FieldOfWorkCode,
                    CriteriaCode = jobDTO.CriteriaCode
                };
                // קריאה לפונקציה המתאימה ב-DAL ליצירת ה-Entity
                _jobRepo.Create(jobEntity);

                // החזרת ה-Entity המתאימה בצורת DTO
                return jobDTO;
            }
            catch (Exception ex)
            {
                // התנהגות מתאימה לטיפול בשגיאות
                throw;
            }
        }

        public JobDTO Update(int code, JobDTO updatedJobDTO)
        {
            try
            {
                var existingJob = _jobRepo.GetAll().FirstOrDefault(x => x.Code == code);

                if (existingJob == null)
                {
                    throw new Exception("Job not found");
                }

                // העתקת הנתונים מה-DTO המעודכן ל-Entity הקיים
                existingJob.EmployersCode = updatedJobDTO.EmployersCode;
                existingJob.FieldOfWorkCode = updatedJobDTO.FieldOfWorkCode;
                existingJob.CriteriaCode = updatedJobDTO.CriteriaCode;

                // קריאה לפונקציה המתאימה ב-DAL לעדכון ה-Entity
                _jobRepo.Update(code, existingJob);

                // החזרת ה-Entity המתאים בצורת DTO
                return updatedJobDTO;
            }
            catch (Exception ex)
            {
                // התנהגות מתאימה לטיפול בשגיאות
                throw;
            }
        }

        public JobDTO Delete(int code)
        {
            try
            {
                var deletedJob = _jobRepo.Delete(code);

                if (deletedJob == null)
                {
                    throw new Exception("Job not found");
                }

                // החזרת ה-Entity המתאימה בצורת DTO
                return new JobDTO
                {
                    Code = deletedJob.Code,
                    EmployersCode = deletedJob.EmployersCode,
                    FieldOfWorkCode = deletedJob.FieldOfWorkCode,
                    CriteriaCode = deletedJob.CriteriaCode,
                    CriteriaCodeNavigation = new CriterionDTO
                    {
                        Code = deletedJob.CriteriaCodeNavigation.Code,
                        SeveralYearsOfExperience = deletedJob.CriteriaCodeNavigation.SeveralYearsOfExperience,
                        Car = deletedJob.CriteriaCodeNavigation.Car,
                        NumberOfCvsSent = deletedJob.CriteriaCodeNavigation.NumberOfCvsSent,
                        Salary = deletedJob.CriteriaCodeNavigation.Salary,
                        Descriptions = deletedJob.CriteriaCodeNavigation.Descriptions
                    },
                    EmployersCodeNavigation = new EmployerDTO
                    {
                        Code = deletedJob.EmployersCodeNavigation.Code,
                        Email = deletedJob.EmployersCodeNavigation.Email,
                        Phone = deletedJob.EmployersCodeNavigation.Phone,
                        Firstname = deletedJob.EmployersCodeNavigation.Firstname,
                        Lastname = deletedJob.EmployersCodeNavigation.Lastname,
                        CompanyName = deletedJob.EmployersCodeNavigation.CompanyName,
                        CompanyAddress = deletedJob.EmployersCodeNavigation.CompanyAddress
                    },
                    FieldOfWorkCodeNavigation = new FieldOfWorkDTO
                    {
                        Code = deletedJob.FieldOfWorkCodeNavigation.Code,
                        FieldOfWorkName = deletedJob.FieldOfWorkCodeNavigation.FieldOfWorkName
                    }
                };
            }
            catch (Exception ex)
            {
                // התנהגות מתאימה לטיפול בשגיאות
                throw;
            }
        }

        public JobDTO GetByCode(int code)
        {
            throw new NotImplementedException();
        }
    }
}