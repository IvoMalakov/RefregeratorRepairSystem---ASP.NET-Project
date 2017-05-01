using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefregeratorRepairSystem.Models.EntityModels;

namespace RefregeratorRepairSystem.Data.Mocks
{
    class FakeCustomersDbSet : FakeDbSet<Customer>
    {
        public override Customer Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(customer => customer.Id == wantedId);
        }
    }
}
