using Bl.Bl_Api;
using DataBase;
using DataBase.Dal_Api;
using DataBase.Dal_Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Bl_Implementation
{
    public class BlFieldOfWork:IBlFieldOfWork
    {
        IFieldOfWorkRepo fieldOfWorkRepo;
        public BlFieldOfWork(DalManager dalManager)
        {
            this.fieldOfWorkRepo = dalManager.fieldOfWork;
        }
        public List<BlFieldOfWork> GetAll()
        {
            //List<FieldOfWorkRepo> fieldOfWorkRepos = fieldOfWorkRepo.

            //return ans;
            return null;
            
        }

    }
}
