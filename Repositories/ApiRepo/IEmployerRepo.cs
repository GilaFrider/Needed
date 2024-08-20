using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ApiRepo
{
    public interface IEmployerRepo : IRepository<Employer>
    {
        Task<Employer> GetByEmailAsync(string email);
    }
}
