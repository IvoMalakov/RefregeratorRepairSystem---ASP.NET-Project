namespace RefregeratorRepairSystem.Models.BindingModels
{
    public class AddRepairBindingModel
    {
        public decimal Price { get; set; }

        public string ActionsTaken { get; set; }

        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }

        public int ItemId { get; set; }
    }
}
