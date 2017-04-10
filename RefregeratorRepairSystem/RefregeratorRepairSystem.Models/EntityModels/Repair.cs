namespace RefregeratorRepairSystem.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;

    public class Repair
    {
        [Key]
        public int Id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee EmployeeInCharge { get; set; }

        public virtual Item Item { get; set; }

        public decimal Price { get; set; }

        public string ActionsTaken { get; set; }
    }
}
