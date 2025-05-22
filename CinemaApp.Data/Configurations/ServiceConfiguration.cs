using AutoDetailingApp.Common;
using AutoDetailingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDetailingApp.Data.Configurations
{
	public class ServiceConfiguration : IEntityTypeConfiguration<Service>
	{
		public void Configure(EntityTypeBuilder<Service> builder)
		{
			builder
				.HasKey(t => t.Id);

			builder
				.Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(EntityValidationConstants.Service.NameMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.Service.NameMaxLength})");

			builder
				.Property(t => t.Description)
				.HasMaxLength(EntityValidationConstants.Service.DescriptionMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.Service.DescriptionMaxLength})");

			builder
				.Property(t => t.Price)
				.IsRequired()
				.HasColumnType("DECIMAL(18,2)");

			builder
				.Property(t => t.DurationMinutes)
				.IsRequired()
				.HasColumnType("INT");

			builder
				.Property(t => t.CreatedAt)
				.HasColumnType("DATETIME2")
				.HasDefaultValueSql("GETDATE()");
		}
	}
}
