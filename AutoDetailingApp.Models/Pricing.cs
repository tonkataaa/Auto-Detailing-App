using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDetailingApp.Models
{
    public class Pricing
    {
        public Pricing()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public Guid ServiceId { get; set; }

        public Service Service { get; set; }

        public decimal Price { get; set; }

        public DateTime EffectiveFrom { get; set; }

    }
}
