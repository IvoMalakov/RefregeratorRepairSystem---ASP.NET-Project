namespace RefregeratorRepairSystem.Models.BindingModels
{
    public class EditRepairBindingModel
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string ActionsTaken { get; set; }

        public int EmployeeId { get; set; }
    }
}
