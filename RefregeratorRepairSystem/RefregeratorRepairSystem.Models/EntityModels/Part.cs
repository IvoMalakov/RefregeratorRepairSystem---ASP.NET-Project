﻿namespace RefregeratorRepairSystem.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    using RefregeratorRepairSystem.Models.Enums;

    public class Part
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Model { get; set; }

        [Required]
        public ItemType PatrType { get; set; }

        public int? Quantity { get; set; }
    }
}
