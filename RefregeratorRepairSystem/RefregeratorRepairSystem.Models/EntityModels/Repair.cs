using System;
using RefregeratorRepairSystem.Models.EntityModels.ModelValidators;

namespace RefregeratorRepairSystem.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;

    public class Repair
    {
        private decimal price;
        private string actionsTaken;

        [Key]
        public int Id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee EmployeeInCharge { get; set; }

        public virtual Item Item { get; set; }

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

        public string ActionsTaken
        {
            get
            {
                return this.actionsTaken;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "Your actions can not be null");
                }

                if (!ModelValidator.CheckIfAcctionsIsValid(value))
                {
                    throw new ArgumentException("Your actions must be  at least 3 symbols long");
                }

                this.actionsTaken = value;
            }
        }
    }
}
