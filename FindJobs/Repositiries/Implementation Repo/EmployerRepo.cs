using Repositiries.Models;
using Repositiries.Api_Repo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repositiries.Implementation_Repo
{
    public class EmployerRepo : IEmployerRepo
    {
        Context context;
        public EmployerRepo(Context context)
        {
            this.context = context;
        }
        public Employer Create(Employer item)
        {
            try
            {
                context.Employers.Add(item);
                context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to add a new Employer");
            }
        }

        public Employer Delete(int code)
        {

            try
            {
                Employer e = context.Employers.FirstOrDefault(x => x.Code == code);
                context.Employers.Remove(e);
                context.SaveChanges();
                return e;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to remove an Employer");
            }
        }

        public List<Employer> GetAll()
        {
            try
            {
                return context.Employers.ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to display all  Employer");
            }
        }

        public Employer GetByCode(int code)
        {
            throw new NotImplementedException();
        }

        public Employer GetEmployerByEmail(string email)
        {
            try
            {
                return context.Employers.FirstOrDefault(e => e.Email == email);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed");
            }
        }

        public Employer Update(int code, Employer employer)
        {
            try
            {
                Employer e = context.Employers.FirstOrDefault(x => x.Code == code);
                if (e != null)
                {
                    e.Email = employer.Email;   
                    e.Phone = employer.Phone;
                    e.Firstname = employer.Firstname;
                    e.Lastname = employer.Lastname;
                    e.CompanyAddress = employer.CompanyAddress;
                    e.CompanyName = employer.CompanyName;
                }
                    
                context.SaveChanges();
                return e;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to update Employers");
            }
        }
    }
}
