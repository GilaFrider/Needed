using Bl.Bl_Api;
using Bl.DTO;
using DataBase.Dal_Api;
using DataBase.Models;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Dal_Implementation;
using System.Runtime.ConstrainedExecution;

namespace Bl.Bl_Implementation
{
    public class BlCriterion : IBlCriterion
    {
        ICriterionRepo _CriterionRepo;
        public BlCriterion(DalManager dalManager)
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
            Car = c.Car
            NumberOfCvsSent = criterion.NumberOfCvsSent;
            Salary = criterion.Salary;
            Descriptions = criterion.Descriptions;
            };
        }

        public CriterionDTO Upadte(int ID, CriterionDTO item)
        {
            throw new NotImplementedException();
        }

        public CriterionDTO Delete(int code)
        {
            throw new NotImplementedException();
        }
        //public CriterionDTO Delete(string name)
        //{
        //    Crown c = crowns.Delete(name);
        //    return new CrownDTO()
        //    {
        //        CrownCode = c.CrownCode,
        //        Name = name,
        //        Description = c.Description,
        //        Price = c.Price,
        //        ColorId = c.ColorId,
        //        Qtty = c.Qtty,
        //        Image = c.Image
        //    };
    }

}

