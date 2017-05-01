using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefregeratorRepairSystem.Models.EntityModels;

namespace RefregeratorRepairSystem.Data.Mocks
{
    public class FakeItemsDbSet : FakeDbSet<Item>
    {
        public override Item Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(item => item.Id == wantedId);
        }
    }
}
