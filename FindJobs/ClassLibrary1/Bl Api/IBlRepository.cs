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

        T Delete(T item);

        T Upadte(int ID, T item);
    }
}
