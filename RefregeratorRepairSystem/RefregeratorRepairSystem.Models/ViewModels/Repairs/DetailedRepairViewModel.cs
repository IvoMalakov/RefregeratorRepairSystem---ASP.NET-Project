namespace RefregeratorRepairSystem.Models.ViewModels.Repairs
{
    public class DetailedRepairViewModel
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public string EmployeeInCharge { get; set; }

        public string RepairItem { get; set; }

        public decimal Price { get; set; }

        public string ActionsTaken { get; set; }
    }
}
