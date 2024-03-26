using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Bl_Api
{
    public interface IBlRepository<T>
    {
        List<T> GetAll();

        T Create(T item);

        T Delete(int code);

        T Update(int code, T item);
    }
}
