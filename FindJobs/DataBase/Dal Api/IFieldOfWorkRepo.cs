using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Dal_Api
{
    public interface IFieldOfWorkRepo
    {
        List<FieldOfWork> GetAll();

        FieldOfWork Create(FieldOfWork item);
    }
}
