using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDetailingApp.Models
{
    public class User
    {
		public User()
		{
			this.Id = Guid.NewGuid();
			this.Appointments = new HashSet<Appointment>();
		}

		public Guid Id { get; set; }

		public string FullName { get; set; }

		[EmailAddress]
		public string Email { get; set; }

		public string PhoneNumber { get; set; }

		public string PasswordHash { get; set; }

		public string Role { get; set; }

		public DateTime CreatedAt { get; set; }

		public ICollection<Appointment> Appointments { get; set; }
	}
}
