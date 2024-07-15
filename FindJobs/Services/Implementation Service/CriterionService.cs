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
            c.Code = criterion.Code;
            c.SeveralYearsOfExperience = criterion.SeveralYearsOfExperience;
            c.Car = criterion.Car;
            c.NumberOfCvsSent = criterion.NumberOfCvsSent;
            c.Salary = criterion.Salary;
            c.Descriptions = criterion.Descriptions;
            _CriterionRepo.Create(c);
            return criterion;
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
            throw new NotImplementedException();
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

