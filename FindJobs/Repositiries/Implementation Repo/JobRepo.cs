using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Repositiries.Api_Repo;
using Repositiries.Models;

namespace Repositiries.Implementation_Repo
{
    public class JobRepo : IJobRepo
    {
        Context context;

        public JobRepo(Context context)
        {
            this.context = context;
        }

        public Job Create(Job item)
        {
            try { 

            Debug.WriteLine("Attempting to add job to context.");

            // Ensure navigation properties are correctly set before adding
            var employer = context.Employers.Find(item.EmployersCode);
            var criterion = context.Criteria.Find(item.CriteriaCode);
            var fieldOfWork = context.FieldOfWorks.Find(item.FieldOfWorkCode);

            if (employer == null || criterion == null || fieldOfWork == null)
            {
                throw new Exception("Related entities not found.");
            }

            item.EmployersCodeNavigation = employer;
            item.CriteriaCodeNavigation = criterion;
            item.FieldOfWorkCodeNavigation = fieldOfWork;

            context.Jobs.Add(item);
            context.SaveChanges();

            // Eagerly load related entities
            context.Entry(item).Reference(j => j.CriteriaCodeNavigation).Load();
            context.Entry(item).Reference(j => j.EmployersCodeNavigation).Load();
            context.Entry(item).Reference(j => j.FieldOfWorkCodeNavigation).Load();

            Debug.WriteLine("Job added successfully.");
            return item;
        }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex.ToString()}");
                throw new Exception("Failed to add a new Job");
            }
        }


        public Job Delete(int code)
        {
            try
            {
                Job j = context.Jobs.FirstOrDefault(x => x.Code == code);
                if (j != null)
                {
                    context.Jobs.Remove(j);
                    context.SaveChanges();
                }
                return j;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to remove a Job");
            }
        }

        public List<Job> GetAll()
        {
            try
            {
                return context.Jobs
                    .Include(j => j.CriteriaCodeNavigation)
                    .Include(j => j.EmployersCodeNavigation)
                    .Include(j => j.FieldOfWorkCodeNavigation)
                    .ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to display all Jobs");
            }
        }

        public Job GetByCode(int code)
        {
            try
            {
                return context.Jobs
                    .Include(j => j.CriteriaCodeNavigation)
                    .Include(j => j.EmployersCodeNavigation)
                    .Include(j => j.FieldOfWorkCodeNavigation)
                    .FirstOrDefault(j => j.Code == code);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to get Job by code");
            }
        }
       
        public Job Update(int code, Job updatedJob)
        {
            try
            {
                var existingJob = context.Jobs.FirstOrDefault(j => j.Code == updatedJob.Code);

                if (existingJob != null)
                {
                    context.Entry(existingJob).CurrentValues.SetValues(updatedJob);
                    context.SaveChanges();
                    return existingJob;
                }
                else
                {
                    throw new Exception("Job not found for updating");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to update Job");
            }
        }


       
        }
    }
