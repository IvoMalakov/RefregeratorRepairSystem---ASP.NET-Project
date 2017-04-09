using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefregeratorRepairSystem.Models.EntityModels
{
    public class Repair
    {
        public Repair()
        {
            this.Items = new HashSet<Item>();
        }

        [Key]
        public int Id { get; set; }

        public virtual Customer Customer { get; set; }

        public decimal Price { get; set; }

        public double Discount { get; set; }

        public string ActionsTaken { get; set; }

        public virtual ICollection<Item> Items { get; set; }

    }
}
