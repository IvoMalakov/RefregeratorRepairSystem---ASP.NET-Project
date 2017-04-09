namespace RefregeratorRepairSystem.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Customer
    {
        public Customer()
        {
            this.Repairs = new HashSet<Repair>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Address { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Repair> Repairs { get; set; } 
    }
}
