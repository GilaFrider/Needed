
using Repositiries.Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Api_Service
{
    public interface IFieldOfWorkService
    {
        List<FieldOfWorkDTO> GetAll();
        FieldOfWorkDTO GetByName(string name);
        FieldOfWorkDTO Create(FieldOfWorkDTO item);
    }
}
