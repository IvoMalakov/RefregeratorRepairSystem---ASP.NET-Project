namespace RefregeratorRepairSystem.Models.ViewModels.Items
{
    using RefregeratorRepairSystem.Models.Enums;

    public class EditItemViewModel
    { 
        public int Id { get; set; }

        public string Make { get; set; }

        public ItemType Type { get; set; }

        public string Model { get; set; }
    }
}
