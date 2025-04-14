using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDetailingApp.Models
{
    public class Service
    {
        public Service()
        {
            this.Id = Guid.NewGuid();
			this.Appointments = new HashSet<Appointment>();
			this.Pricings = new HashSet<Pricing>();
		}

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int DurationMinutes { get; set; }

        public DateTime CreatedAt { get; set; }

		public ICollection<Appointment> Appointments { get; set; }
		public ICollection<Pricing> Pricings { get; set; }

	}
}
