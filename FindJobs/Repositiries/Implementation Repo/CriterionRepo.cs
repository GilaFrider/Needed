using Repositiries.Models;
using Repositiries.Api_Repo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositiries.Implementation_Repo
{
    public class CriterionRepo : ICriterionRepo
    {
        Context context;
        public CriterionRepo(Context context)
        {
            this.context = context;
        }
        public Criterion Create(Criterion item)
        {
            try
            {
                context.Criteria.Add(item);
                context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to add a new Criterion");
            }
        }

        public Criterion Delete(int code)
        {
            try
            {
                Criterion c = context.Criteria.FirstOrDefault(x => x.Code == code);
                context.Criteria.Remove(c);
                context.SaveChanges();
                return c;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to remove an Criterion");
            }
        }

        public List<Criterion> GetAll()
        {
            try
            {
                return context.Criteria.ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to display all  Criterion");
            }
        }

        public Criterion GetByCode(int code)
        {
            throw new NotImplementedException();
        }

        public Criterion Update(int code, Criterion item)
        {
            try
            {
                Criterion c = context.Criteria.FirstOrDefault(x => x.Code == code);
                if (c != null)
                {
                    c.SeveralYearsOfExperience = item.SeveralYearsOfExperience;
                    c.Car = item.Car;
                    c.NumberOfCvsSent = item.NumberOfCvsSent;
                    c.Salary = item.Salary;
                    c.Descriptions = item.Descriptions;
                }

                context.SaveChanges();
                return c;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to update Criterion");
            }
        }
    }
}
