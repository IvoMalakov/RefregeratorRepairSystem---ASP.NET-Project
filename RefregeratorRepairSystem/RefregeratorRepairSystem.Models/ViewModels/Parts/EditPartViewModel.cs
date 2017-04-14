namespace RefregeratorRepairSystem.Models.ViewModels.Parts
{
    public class EditPartViewModel
    {
        public int Id { get; set; }

        public string PartDescription { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
