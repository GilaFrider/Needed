using Services.Api_Service;
using Services.DTO;
using Repositiries;
using Repositiries.Api_Repo;
using Repositiries.Models;

namespace Services.Implementation_Service
{
    public class CriterionService : ICriterionService
    {
        ICriterionRepo _CriterionRepo;
        public CriterionService(ManagerRepo dalManager)
        {
            _CriterionRepo = dalManager.criterion;
        }
        public List<CriterionDTO> GetAll()
        {
            try
            {
                List<Criterion> criterions = _CriterionRepo.GetAll();


                List<CriterionDTO> criterionDTOs = criterions.Select(criterion => new CriterionDTO
                {
                    Code = criterion.Code,
                    SeveralYearsOfExperience = criterion.SeveralYearsOfExperience,
                    Car = criterion.Car,
                    NumberOfCvsSent = criterion.NumberOfCvsSent,
                    Salary = criterion.Salary,
                    Descriptions = criterion.Descriptions,
                }).ToList();

                return criterionDTOs;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public CriterionDTO Create(CriterionDTO criterion)
        {
            Criterion c = new Criterion();
            //c.Code = criterion.Code;
            c.SeveralYearsOfExperience = criterion.SeveralYearsOfExperience;
            c.Car = criterion.Car;
            c.NumberOfCvsSent = criterion.NumberOfCvsSent;
            c.Salary = criterion.Salary;
            c.Descriptions = criterion.Descriptions;

            
            var createdCriterion = _CriterionRepo.Create(c);

            return new CriterionDTO
            {
                Code = createdCriterion.Code,
                SeveralYearsOfExperience = createdCriterion.SeveralYearsOfExperience,
                Car = createdCriterion.Car,
                NumberOfCvsSent = createdCriterion.NumberOfCvsSent,
                Salary = createdCriterion.Salary,
                Descriptions = createdCriterion.Descriptions
            };
            //return criterion;
        }

        public CriterionDTO Delete(int code)
        {
            Criterion c = _CriterionRepo.Delete(code);
            return new CriterionDTO()
            {
                Code = code,
                SeveralYearsOfExperience = c.SeveralYearsOfExperience,
                Car = c.Car,
                NumberOfCvsSent = c.NumberOfCvsSent,
                Salary = c.Salary,
                Descriptions = c.Descriptions
            };
        }
        public CriterionDTO Update(int code, CriterionDTO criterion)
        {
            Criterion c = new Criterion();
            c.Code = criterion.Code;
            c.SeveralYearsOfExperience = criterion.SeveralYearsOfExperience;
            c.Car = criterion.Car;
            c.NumberOfCvsSent = criterion.NumberOfCvsSent;
            c.Salary = criterion.Salary;
            c.Descriptions = criterion.Descriptions;
            _CriterionRepo.Update(code, c);
            return criterion;
        }

        public CriterionDTO GetByCode(int code)
        {
            var criterion = _CriterionRepo.GetByCode(code);
            if (criterion == null)
            {
                throw new Exception("Criterion not found");
            }

            // Map the Criterion entity to CriterionDTO
            var criterionDto = new CriterionDTO
            {
                Code = criterion.Code,
                SeveralYearsOfExperience = criterion.SeveralYearsOfExperience,
                Car = criterion.Car,
                NumberOfCvsSent = criterion.NumberOfCvsSent,
                Salary = criterion.Salary,
                Descriptions = criterion.Descriptions,
                Jobs = criterion.Jobs.Select(job => new JobDTO
                {
                    Code = job.Code,
                    EmployersCode = job.EmployersCode,
                    FieldOfWorkCode = job.FieldOfWorkCode,
                    CriteriaCode = job.CriteriaCode,
                    // Map other properties as needed
                }).ToList()
            };

            return criterionDto;

        }
        //    Crown c = crowns.Delete(name);
        //        Name = name,
        //        Description = c.Description,
        //        Price = c.Price,
        //        ColorId = c.ColorId,
        //        Qtty = c.Qtty,
        //        Image = c.Image
        //    };
    }  
}

