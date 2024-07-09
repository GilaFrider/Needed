using Repositiries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositiries.Api_Repo
{
    public interface IEmployerRepo:IRepository<Employer>
    {
        Employer GetEmployerByEmail(string email);
    }
}
