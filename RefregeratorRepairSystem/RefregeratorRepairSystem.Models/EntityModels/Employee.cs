namespace RefregeratorRepairSystem.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Employee
    {
        public Employee()
        {
            this.Repairs = new HashSet<Repair>();
        }

       
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public decimal Salary { get; set; }

        public virtual ICollection<Repair> Repairs { get; set; }
    }
}
