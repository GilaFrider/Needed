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

        void Create(T item);

        void Delete(T item);

        void Upadte(T item);
        
        


        //List<T> Read();
    }
}

