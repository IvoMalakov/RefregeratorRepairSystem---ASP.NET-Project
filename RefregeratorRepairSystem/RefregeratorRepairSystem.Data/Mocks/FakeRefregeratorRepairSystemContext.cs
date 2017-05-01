using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefregeratorRepairSystem.Data.Interfaces;
using RefregeratorRepairSystem.Models.EntityModels;

namespace RefregeratorRepairSystem.Data.Mocks
{
    public class FakeRefregeratorRepairSystemContext : IRefregeratorRepairSystemContext
    {
        public FakeRefregeratorRepairSystemContext()
        {
            this.Customers = new FakeDbSet<Customer>();
            this.Employees = new FakeDbSet<Employee>();
            this.Items = new FakeDbSet<Item>();
            this.Parts = new FakeDbSet<Part>();
            this.Repairs = new FakeDbSet<Repair>();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public int SaveChanges()
        {
            return 0;
        }
    }
}
