
using Repositiries.Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Api_Service
{
    public interface IJobService:IRepositoryService<JobDTO>
    {
        //public EmployerDTO GetEmployerByEmployerCode(int code);

        //public CriterionDTO GetCriterionByCriterionCode(int code);

        //public FieldOfWorkDTO GetFieldOfWorkByFieldOfWorkCode(int code);

    }
}
