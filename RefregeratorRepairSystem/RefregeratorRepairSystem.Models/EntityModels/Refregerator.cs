using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefregeratorRepairSystem.Models.EntityModels
{
    public class Refregerator
    {
        public Refregerator()
        {
            this.Parts = new HashSet<Part>();
        }

        [Key]
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
