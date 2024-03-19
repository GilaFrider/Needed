using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl
{
    public class Blmanger
    {
        private readonly DalManager _dalManager;

        public Blmanger(DalManager dalManager)
        {
            _dalManager = dalManager;
        }

    }
}
