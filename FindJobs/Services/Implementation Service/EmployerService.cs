using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Services.Api_Service;
using Services.DTO;
using Repositiries;
using Repositiries.Api_Repo;
using Repositiries.Models;

namespace Services.Implementation_Service
{
    public class EmployerService:IEmployerService
    {
        private readonly IEmployerRepo _EmployerRepo;
        public EmployerService(ManagerRepo dalManager)
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
                    Password = employer.Password,
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
            e.Password = employer.Password;
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
                Password = employer.Password,
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
            e.Password = employer.Password;
            e.Phone = employer.Phone;
            e.Firstname = employer.Firstname;
            e.Lastname = employer.Lastname;
            e.CompanyName = employer.CompanyName;
            e.CompanyAddress = employer.CompanyAddress;
            _EmployerRepo.Create(e);
            return employer;
        }

        public EmployerDTO GetByCode(int code)
        {
            throw new NotImplementedException();
        }
    }
}



