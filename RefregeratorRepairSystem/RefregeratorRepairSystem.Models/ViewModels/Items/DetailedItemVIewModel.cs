namespace RefregeratorRepairSystem.Models.ViewModels.Items
{
    using System.Collections.Generic;
    using RefregeratorRepairSystem.Models.Enums;
    using RefregeratorRepairSystem.Models.ViewModels.Parts;

    public class DetailedItemViewModel
    {
        public DetailedItemViewModel()
        {
            this.Parts = new HashSet<PartForItemViewModel>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public ItemType Type { get; set; }

        public virtual ICollection<PartForItemViewModel> Parts { get; set; }
    }
}
