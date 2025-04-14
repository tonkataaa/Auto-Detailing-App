using AutoDetailingApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AutoDetailingApp.Data;

public class AutoDetailingDbContext : IdentityDbContext
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

    public virtual DbSet<User> Users { get; set; } = null!;


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}


}
