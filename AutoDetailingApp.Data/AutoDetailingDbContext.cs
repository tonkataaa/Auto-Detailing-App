
namespace AutoDetailingApp.Data
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	using AutoDetailingApp.Models;
	using System.Reflection;
	using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
	using Microsoft.Extensions.Configuration;

	public class AutoDetailingDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
		private readonly IConfiguration _configuration;

		public AutoDetailingDbContext()
		{
			
		}

		public AutoDetailingDbContext(DbContextOptions options, IConfiguration configuration)
			: base(options)
		{
			_configuration = configuration;
		}

		public virtual DbSet<Appointment> Appointments { get; set; } = null!;

		public virtual DbSet<ContactRequest> ContactRequests { get; set; } = null!;

		public virtual DbSet<Pricing> Pricings { get; set; } = null!;

		public virtual DbSet<Service> Services { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{	
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(
					_configuration.GetConnectionString("AutoDetailingDb"),
					b => b.MigrationsAssembly("AutoDetailingApp.Data"));
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Service>(e =>
			{
				e.Property(ent => ent.DurationMinutes)
				.HasColumnType("bigint")
				.HasConversion(new TimeSpanToTicksConverter());
			});

			
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
