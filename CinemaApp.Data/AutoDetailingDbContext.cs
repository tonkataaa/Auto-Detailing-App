
namespace CinemaApp.Data
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	using AutoDetailingApp.Models;
	using System.Reflection;

	public class AutoDetailingDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
		public AutoDetailingDbContext()
		{
			
		}

		public AutoDetailingDbContext(DbContextOptions options)
			: base(options)
		{
			
		}

		public virtual DbSet<Appointment> Appointments { get; set; } = null!;

		public virtual DbSet<ContactRequest> ContactRequests { get; set; } = null!;

		public virtual DbSet<Pricing> Pricings { get; set; } = null!;

		public virtual DbSet<Service> Services { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
