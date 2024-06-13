using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Api_Service
{
    public interface IRepositoryService<T>
    {
        List<T> GetAll();
        T GetByCode(int code);

        T Create(T item);

        T Delete(int code);

        T Update(int code, T item);
    }
}
