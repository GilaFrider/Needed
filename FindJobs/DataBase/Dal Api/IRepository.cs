using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public interface ICrud<T>
    {
            
        void Create(T item);

        void Delete(T item);

        void Upadte(T item);
        void Get(T item);


        List<T> Read();
    }
}

