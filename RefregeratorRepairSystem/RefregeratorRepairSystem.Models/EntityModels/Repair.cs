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
            this.AirConditioners = new HashSet<AirConditioner>();
            this.Refregerators = new HashSet<Refregerator>();
        }

        [Key]
        public int Id { get; set; }

        public virtual Customer Customer { get; set; }

        public decimal Price { get; set; }

        public double Discount { get; set; }

        public virtual ICollection<AirConditioner> AirConditioners { get; set; }

        public virtual ICollection<Refregerator> Refregerators { get; set; }

    }
}
