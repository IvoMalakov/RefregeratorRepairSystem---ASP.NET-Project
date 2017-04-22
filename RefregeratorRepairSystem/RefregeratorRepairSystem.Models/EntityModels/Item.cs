using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefregeratorRepairSystem.Models.EntityModels.ModelValidators;
using RefregeratorRepairSystem.Models.Enums;

namespace RefregeratorRepairSystem.Models.EntityModels
{
    public class Item
    {
        private string make;
        private string model;

        public Item()
        {
            this.Parts = new HashSet<Part>();
        }

        [Key]
        public int Id { get; set; }

        public ItemType Type { get; set; }

        public string Make
        {
            get
            {
                return this.make;
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

                this.make = value;
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

        public virtual ICollection<Part> Parts { get; set; }
    }
}
