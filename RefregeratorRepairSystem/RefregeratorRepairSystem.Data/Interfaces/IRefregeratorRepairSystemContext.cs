using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefregeratorRepairSystem.Models.EntityModels;

namespace RefregeratorRepairSystem.Data.Interfaces
{
    public interface IRefregeratorRepairSystemContext
    {
        DbSet<Customer> Customers { get; set; }

        DbSet<Employee> Employees { get; set; }

        DbSet<Part> Parts { get; set; }

        DbSet<Item> Items { get; set; }

        DbSet<Repair> Repairs { get; set; }

        int SaveChanges();
    }
}
