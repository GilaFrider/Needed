using DataBase.Dal_Api;
using DataBase.Models;
using System.Diagnostics;

namespace DataBase.Dal_Implementation
{
    public class FieldOfWorkRepo : IFieldOfWorkRepo
    {
        Context context;
        public FieldOfWorkRepo(Context context)
        {
            this.context = context;
        }

        public List<FieldOfWork> GetAll()
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
