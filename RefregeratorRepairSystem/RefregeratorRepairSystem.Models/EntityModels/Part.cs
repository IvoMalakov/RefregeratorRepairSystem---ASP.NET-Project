namespace RefregeratorRepairSystem.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RefregeratorRepairSystem.Models.Enums;

    public class Part
    {
        public Part()
        {
            this.Items = new HashSet<Item>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Model { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}
