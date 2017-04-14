namespace RefregeratorRepairSystem.Models.ViewModels.Parts
{
    using System.Collections.Generic;
    using RefregeratorRepairSystem.Models.ViewModels.Items;

    public class DetailedPartViewModel
    {
        public DetailedPartViewModel()
        {
            this.Items = new HashSet<ItemForPartViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<ItemForPartViewModel> Items { get; set; }
    }
}
