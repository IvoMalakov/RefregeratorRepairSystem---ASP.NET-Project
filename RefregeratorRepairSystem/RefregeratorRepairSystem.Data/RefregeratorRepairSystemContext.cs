namespace RefregeratorRepairSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RefregeratorRepairSystem.Models.EntityModels;

    public class RefregeratorRepairSystemContext : IdentityDbContext<ApplicationUser>
    {
     
        public RefregeratorRepairSystemContext()
            : base("name=RefregeratorRepairSystem")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<AirConditioner> AirConditioners { get; set; }

        public DbSet<Refregerator> Refregerators { get; set; }

        public DbSet<Repair> Repairs { get; set; }

        public static RefregeratorRepairSystemContext Create()
        {
            return new RefregeratorRepairSystemContext();
        }
    }
}