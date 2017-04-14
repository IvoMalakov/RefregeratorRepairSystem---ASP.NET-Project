namespace RefregeratorRepairSystem.Models.BindingModels
{
    public class AddPartBindingModel
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int ItemId { get; set; }
    }
}
