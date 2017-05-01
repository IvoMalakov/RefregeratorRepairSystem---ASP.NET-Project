using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefregeratorRepairSystem.Models.EntityModels;

namespace RefregeratorRepairSystem.Data.Mocks
{
    public class FakePartsDbSet : FakeDbSet<Part>
    {
        public override Part Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(part => part.Id == wantedId);
        }
    }
}
