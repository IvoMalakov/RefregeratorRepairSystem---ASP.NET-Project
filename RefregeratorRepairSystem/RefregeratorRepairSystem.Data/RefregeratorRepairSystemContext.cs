namespace RefregeratorRepairSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RefregeratorRepairSystem.Models.EntityModels;
    using RefregeratorRepairSystem.Data.Interfaces;

    public class RefregeratorRepairSystemContext : IdentityDbContext<ApplicationUser>, IRefregeratorRepairSystemContext
    {
     
        public RefregeratorRepairSystemContext()
            : base("name=RefregeratorRepairSystem")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Repair> Repairs { get; set; }

        public DbSet<Part> Parts { get; set; } 

        public static RefregeratorRepairSystemContext Create()
        {
            return new RefregeratorRepairSystemContext();
        }
    }
}