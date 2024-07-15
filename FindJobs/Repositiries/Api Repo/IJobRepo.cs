using Repositiries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositiries.Api_Repo
{
    public interface IJobRepo:IRepository<Job>
    {
        //public Employer GetEmployerByEmployerCode(int code);

        //public Criterion GetCriterionByCriterionCode(int code);

        //public FieldOfWork GetFieldOfWorkByFieldOfWorkCode(int code);
       
    }
}
