using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using DataBase.Dal_Api;
using DataBase.Models;

namespace DataBase.Dal_Implementation
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
            try
            {
                context.Jobs.Add(item);
                context.SaveChanges();

                // Include related entities when returning the created job
                context.Entry(item)
                       .Reference(j => j.CriteriaCodeNavigation)
                       .Load();

                context.Entry(item)
                       .Reference(j => j.EmployersCodeNavigation)
                       .Load();

                context.Entry(item)
                       .Reference(j => j.FieldOfWorkCodeNavigation)
                       .Load();

                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
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
        //בעזרת שיטות אלה, כעת תוכל לאחזר רשימה של משרות על סמך השדה שצוין של קוד העבודה או קוד הקריטריונים.
        //זכור להתאים את הלוגיקה של השיטה ושמות המאפיינים בהתאם ליישום שלך בפועל
        public List<Job> GetByEmployer(int employerCode)
        {
            try
            {
                return context.Jobs
                    .Where(j => j.EmployersCode == employerCode)
                    .Include(j => j.CriteriaCodeNavigation)
                    .Include(j => j.EmployersCodeNavigation)
                    .Include(j => j.FieldOfWorkCodeNavigation)
                    .ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to get Jobs by Employer");
            }
        }

        public List<Job> GetByFieldOfWork(int fieldOfWorkCode)
        {
            try
            {
                return context.Jobs
                    .Where(j => j.FieldOfWorkCode == fieldOfWorkCode)
                    .Include(j => j.CriteriaCodeNavigation)
                    .Include(j => j.EmployersCodeNavigation)
                    .Include(j => j.FieldOfWorkCodeNavigation)
                    .ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to get Jobs by Field of Work");
            }
        }

        public List<Job> GetByCriteria(int criteriaCode)
        {
            try
            {
                return context.Jobs
                    .Where(j => j.CriteriaCode == criteriaCode)
                    .Include(j => j.CriteriaCodeNavigation)
                    .Include(j => j.EmployersCodeNavigation)
                    .Include(j => j.FieldOfWorkCodeNavigation)
                    .ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to get Jobs by Criteria");
            }
        }

       
        }
    }
