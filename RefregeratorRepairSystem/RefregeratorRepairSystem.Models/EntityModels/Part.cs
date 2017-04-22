using System;
using RefregeratorRepairSystem.Models.EntityModels.ModelValidators;

namespace RefregeratorRepairSystem.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using RefregeratorRepairSystem.Models.Enums;

    public class Part
    {
        private string name;
        private decimal price;
        private string model;
        private int quantity;

        public Part()
        {
            this.Items = new HashSet<Item>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "Your name can not be null");
                }

                if (!ModelValidator.ChekIfNameIsValid(value))
                {
                    throw new ArgumentException("Your name must be between 3 and 50 symbols long");
                }

                this.name = value;
            }
        }

        [Required]
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (!ModelValidator.ChekIfPriceIsValid(value))
                {
                    throw new ArgumentException("Your price must be a positive number");
                }

                this.price = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "Your name can not be null");
                }

                if (!ModelValidator.ChekIfNameIsValid(value))
                {
                    throw new ArgumentException("Your name must be between 3 and 50 symbols long");
                }

                this.model = value;
            }
        }

        public int Quantity
        {
            get
            {
                return this.quantity;
            }

            set
            {
                if (!ModelValidator.ChekIfQuantityIsValid(value))
                {
                    throw new ArgumentException("Your name must be between 3 and 50 symbols long");
                }

                this.quantity = value;
            }
        }

        public virtual ICollection<Item> Items { get; set; }
    }
}
