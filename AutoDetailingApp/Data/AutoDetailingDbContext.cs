using AutoDetailingApp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AutoDetailingApp.Data;

public class AutoDetailingDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public AutoDetailingDbContext()
    {

    }

    public AutoDetailingDbContext(DbContextOptions<AutoDetailingDbContext> options)
        : base(options)
    {

    }

    public virtual DbSet<Appointment> Appointments { get; set; } = null!;

    public virtual DbSet<ContactRequest> ContactRequests { get; set; } = null!;

    public virtual DbSet<Pricing> Pricings { get; set; } = null!;

    public virtual DbSet<Service> Services { get; set; } = null!;

    public virtual DbSet<ClientUser> ClientUsers { get; set; } = null!;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=AutoDetailing;Integrated Security=true;TrustServerCertificate=True;");
        }
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}


}
