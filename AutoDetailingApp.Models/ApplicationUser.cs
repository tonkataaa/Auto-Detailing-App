using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AutoDetailingApp.Models
{
	public class ApplicationUser : IdentityUser<Guid>
	{
		public ApplicationUser()
		{
			this.Id = Guid.NewGuid();
			this.CreatedAt = DateTime.UtcNow;
			this.Appointments = new List<Appointment>();
		}

		[Required]
		[MaxLength(200)]
		public string FullName { get; set; } = null!;

		public DateTime CreatedAt { get; set; }

		public ICollection<Appointment> Appointments { get; set; }
	}
}
