namespace RefregeratorRepairSystem.Models.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using RefregeratorRepairSystem.Models.EntityModels.ModelValidators;

    public class Employee
    {
        private string firstName;
        private string lastName;
        private string address;
        private decimal salary;

        public Employee()
        {
            this.Repairs = new HashSet<Repair>();
        }

       
        [Key]
        public int Id { get; set; }

        public string FirstName
        {
            get
            {
                return this.firstName;
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

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
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

                this.lastName = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(value, "Your address can not be null");
                }

                if (!ModelValidator.CheckIfAddressIsValid(value))
                {
                    throw new ArgumentException("Your address must be  at least 5 symbols long");
                }

                this.address = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {

                if (!ModelValidator.ChekIfPriceIsValid(value))
                {
                    throw new ArgumentException("Your salary must be a positive number");
                }

                this.salary = value;
            }
        }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Repair> Repairs { get; set; }
    }
}
