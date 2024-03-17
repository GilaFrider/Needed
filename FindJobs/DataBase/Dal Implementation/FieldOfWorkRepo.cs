using DataBase.Dal_Api;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Dal_Implementation
{
    public class FieldOfWorkRepo : IFieldOfWorkRepo
    {
        Context context;
        public FieldOfWorkRepo(Context context)
        {
            this.context = context;
        }

        List<FieldOfWork> IFieldOfWorkRepo.GetAll()
        {
            try
            {
                return context.FieldOfWorks.ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to display all Field Of Work");
            }
        }
        public FieldOfWork Create(FieldOfWork item)
        {
            try
            {
                context.FieldOfWorks.Add(item);
                context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to add a new Field Of Work");
            }
        }
    }
}
