using AutoDetailingApp.Common;
using AutoDetailingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDetailingApp.Data.Configurations
{
	public class UsersConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{

		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder
				.HasKey(t => t.Id);

			builder
				.Property(t => t.FullName)
				.IsRequired()
				.HasMaxLength(50)
				.HasColumnType($"NVARCHAR({50})");

			builder
				.Property(t => t.Email)
				.IsRequired()
				.HasMaxLength(320)
				.HasColumnType($"NVARCHAR({320})");

			builder
				.Property(t => t.PhoneNumber)
				.IsRequired()
				.HasMaxLength(20)
				.HasColumnType($"NVARCHAR({20})");

			builder
				.Property(t => t.PasswordHash)
				.IsRequired()
				.HasMaxLength(128)
				.HasColumnType($"NVARCHAR({128})");

			builder
				.Property(t => t.Role)
				.HasMaxLength(50)
				.HasColumnType($"NVARCHAR({50})");

			builder
				.Property(t => t.CreatedAt)
				.HasColumnType("DATETIME2")
				.HasDefaultValueSql("GETDATE()");
		}
	}
}
