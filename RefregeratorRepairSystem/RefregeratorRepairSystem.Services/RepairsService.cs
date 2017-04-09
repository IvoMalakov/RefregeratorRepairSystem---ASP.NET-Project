using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RefregeratorRepairSystem.Models.EntityModels;
using RefregeratorRepairSystem.Models.ViewModels.Repairs;

namespace RefregeratorRepairSystem.Services
{
    public class RepairsService : Service
    {
        public IEnumerable<ListRepairsViewModel> GetAllRepairs()
        {
            IEnumerable<Repair> repairs = this.Context
                .Repairs
                .OrderBy(r => r.Customer.FirstName)
                .ThenByDescending(r => r.Price)
                .ToList();

            IEnumerable<ListRepairsViewModel> repairsViewModels =
                Mapper.Map<IEnumerable<Repair>, IEnumerable<ListRepairsViewModel>>(repairs);

            return repairsViewModels;
        }
    }
}
