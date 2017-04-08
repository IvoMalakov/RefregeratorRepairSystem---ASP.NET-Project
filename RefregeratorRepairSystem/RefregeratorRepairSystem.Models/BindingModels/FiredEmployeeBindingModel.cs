namespace RefregeratorRepairSystem.Models.BindingModels
{
    using RefregeratorRepairSystem.Models.EntityModels;

    public class FiredEmployeeBindingModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
