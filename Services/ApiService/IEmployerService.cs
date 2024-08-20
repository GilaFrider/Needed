using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ApiService
{
    public interface IEmployerService : IDataService<EmployerDTO>
    {
        Task<EmployerDTO> LoginAsync(string email, string password);
        Task SendCvAsync(int employerId, Stream cvStream, string cvFileName, string message);
    }
}
