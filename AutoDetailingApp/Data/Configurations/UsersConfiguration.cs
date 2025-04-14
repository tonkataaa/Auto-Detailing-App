using AutoDetailingApp.Common;
using AutoDetailingApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDetailingApp.Data.Configurations
{
	public class UsersConfiguration : IEntityTypeConfiguration<User>
	{

		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder
				.HasKey(t => t.Id);

			builder
				.Property(t => t.FullName)
				.IsRequired()
				.HasMaxLength(EntityValidationConstants.User.FullNameMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.User.FullNameMaxLength})");

			builder
				.Property(t => t.Email)
				.IsRequired()
				.HasMaxLength(EntityValidationConstants.User.EmailMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.User.EmailMaxLength})");

			builder
				.Property(t => t.PhoneNumber)
				.IsRequired()
				.HasMaxLength(EntityValidationConstants.User.PhoneNumberMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.User.PhoneNumberMaxLength})");

			builder
				.Property(t => t.PasswordHash)
				.IsRequired()
				.HasMaxLength(EntityValidationConstants.User.PasswordHashMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.User.PasswordHashMaxLength})");

			builder
				.Property(t => t.Role)
				.HasMaxLength(EntityValidationConstants.User.RoleMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.User.RoleMaxLength})");

			builder
				.Property(t => t.CreatedAt)
				.HasColumnType("DATETIME2")
				.HasDefaultValueSql("GETDATE()");
		}
	}
}
