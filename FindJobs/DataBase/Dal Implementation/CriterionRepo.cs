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
            try
            {
                context.Criteria.Remove(item);
                context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to remove an Criterion");
            }
        }

        public List<Criterion> GetAll()
        {
            try
            {
                return context.Criteria.ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw new Exception("Failed to display all  Criterion");
            }
        }



        public Criterion Upadte(int ID, Criterion item)
        {
            throw new NotImplementedException();
        }
    }
}
