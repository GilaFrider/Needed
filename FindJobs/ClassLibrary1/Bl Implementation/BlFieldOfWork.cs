using Bl.Bl_Api;
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
        public List<> GetAll()
        {
            List<Address> addressToClients = addressRepo.GetAll();
            List<AddressToClient> ans = new List<AddressToClient>();
            for (int i = 0; i < addressToClients.Count; i++)
            {
                ans.Add(new AddressToClient() { City = addressToClients[i].City, Nighbord = addressToClients[i].Street });
            }
            return ans;
        }

    }
}
