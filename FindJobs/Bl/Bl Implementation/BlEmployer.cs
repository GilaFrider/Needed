using DataBase.Dal_Api;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bl.DTO;
using DataBase.Models;
using System.Numerics;
using Bl.Bl_Api;

namespace Bl.Bl_Implementation
{
    public class BlEmployer:IBlEmployer
    {
        private readonly IEmployerRepo _EmployerRepo;
        public BlEmployer(DalManager dalManager)
        {
            _EmployerRepo = dalManager.employer;
        }
        public List<EmployerDTO> GetAll()
        {
            try
            {
                List<Employer> employers = _EmployerRepo.GetAll();


                List<EmployerDTO> employerDTOs = employers.Select(employer => new EmployerDTO
                {
                    Code = employer.Code,
                    Email = employer.Email,
                    Phone = employer.Phone,
                    Firstname = employer.Firstname,
                    Lastname = employer.Lastname,
                    CompanyName = employer.CompanyName,
                    CompanyAddress = employer.CompanyAddress

                }).ToList();

                return employerDTOs;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public EmployerDTO Create(EmployerDTO employer)
        {
            Employer e = new Employer();
            e.Code = employer.Code;
            e.Email = employer.Email;
            e.Phone = employer.Phone;
            e.Firstname = employer.Firstname;
            e.Lastname = employer.Lastname;
            e.CompanyName = employer.CompanyName;
            e.CompanyAddress = employer.CompanyAddress;
            _EmployerRepo.Create(e);
            return employer;
        }

        public EmployerDTO Delete(int code)
        {
            Employer employer = _EmployerRepo.Delete(code);
            return new EmployerDTO()
            {
                Code = code,
                Email = employer.Email,
                Phone = employer.Phone,
                Firstname = employer.Firstname,
                Lastname = employer.Lastname,
                CompanyName = employer.CompanyName,
                CompanyAddress = employer.CompanyAddress
            };
        }
        public EmployerDTO Update(int code, EmployerDTO employer)
        {
            Employer e = new Employer();
            e.Code = employer.Code;
            e.Email = employer.Email;
            e.Phone = employer.Phone;
            e.Firstname = employer.Firstname;
            e.Lastname = employer.Lastname;
            e.CompanyName = employer.CompanyName;
            e.CompanyAddress = employer.CompanyAddress;
            _EmployerRepo.Create(e);
            return employer;
        }
    }
}



