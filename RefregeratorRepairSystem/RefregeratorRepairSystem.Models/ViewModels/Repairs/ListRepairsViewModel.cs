namespace RefregeratorRepairSystem.Models.ViewModels.Repairs
{
    public class ListRepairsViewModel
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public string Employee { get; set; }

        public string Item { get; set; }

        public decimal Price { get; set; }

        public string ActionsTaken { get; set; }

        public double Discount { get; set; }
    }
}
