using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDetailingApp.Models
{
    public class Appointment
    {
        public Appointment()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Guid ServiceId { get; set; }

        public Service Service { get; set; }

        public DateTime DateTime { get; set; }

        public string Comment { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
