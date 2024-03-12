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
    public class CriterionRepo : ICriterionRepo
    {
        Context context;
        public CriterionRepo(Context context)
        {
            this.context = context;
        }
        public Criterion Create(Criterion item)
        {
            try
            {
                context.Criteria.Add(item);
                context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to add a new Criterion");
            }
        }

        public Criterion Delete(Criterion item)
        {
            throw new NotImplementedException();
        }

        public List<Criterion> GetAll()
        {
            throw new NotImplementedException();
        }



        public Criterion Upadte(int ID, Criterion item)
        {
            throw new NotImplementedException();
        }
    }
}
