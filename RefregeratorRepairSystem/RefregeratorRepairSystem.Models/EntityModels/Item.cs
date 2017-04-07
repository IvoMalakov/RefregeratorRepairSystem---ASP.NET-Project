using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefregeratorRepairSystem.Models.Enums;

namespace RefregeratorRepairSystem.Models.EntityModels
{
    public class Item
    {
        public Item()
        {
            this.Parts = new HashSet<Part>();
        }

        [Key]
        public int Id { get; set; }

        public ItemType Type { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
