namespace RefregeratorRepairSystem.Models.ViewModels.Employees
{
    using RefregeratorRepairSystem.Models.EntityModels;

    public class EmployeeForFiredViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
