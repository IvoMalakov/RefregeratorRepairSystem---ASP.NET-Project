using System.ComponentModel.DataAnnotations;

namespace RefregeratorRepairSystem.Models.EntityModels
{
    public class Employee
    {
       
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public decimal Salary { get; set; }
    }
}
