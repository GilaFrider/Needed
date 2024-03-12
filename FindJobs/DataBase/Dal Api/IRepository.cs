using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        //List<T> GetByCriterions(T item);

        T Create(T item);

        T Delete(T item);

        T Upadte(int ID, T item);
        
        


        //List<T> Read();
    }
}

