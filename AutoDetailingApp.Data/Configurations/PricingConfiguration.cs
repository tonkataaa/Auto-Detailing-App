using AutoDetailingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDetailingApp.Data.Configurations
{
	public class PricingConfiguration : IEntityTypeConfiguration<Pricing>
	{
		public void Configure(EntityTypeBuilder<Pricing> builder)
		{
			builder
				.HasKey(p => p.Id);

			builder
				.HasOne(p => p.Service)
				.WithMany(s => s.Pricings)
				.HasForeignKey(p => p.ServiceId)
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.Property(p => p.Price)
				.IsRequired()
				.HasColumnType("DECIMAL(18,2)");

			builder
				.Property(p => p.EffectiveFrom)
				.IsRequired()
				.HasColumnType("DATETIME2")
				.HasDefaultValueSql("GETDATE()");
		}
	}
}
