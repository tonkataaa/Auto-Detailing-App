using AutoDetailingApp.Models;
using AutoDetailingApp.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoDetailingApp.Data.Configurations
{
	public class ContactRequestConfiguration : IEntityTypeConfiguration<ContactRequest>
	{
		public void Configure(EntityTypeBuilder<ContactRequest> builder)
		{
			builder
				.HasKey(cr => cr.Id);

			builder
				.Property(cr => cr.FullName)
				.IsRequired()
				.HasMaxLength(EntityValidationConstants.ContactRequest.NameMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.ContactRequest.NameMaxLength})");

			builder
				.Property(cr => cr.Email)
				.IsRequired()
				.HasMaxLength(EntityValidationConstants.ContactRequest.EmailMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.ContactRequest.EmailMaxLength})");

			builder
				.Property(cr => cr.PhoneNumber)
				.IsRequired()
				.HasMaxLength(EntityValidationConstants.ContactRequest.PhoneNumberMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.ContactRequest.PhoneNumberMaxLength})");

			builder
				.Property(cr => cr.Message)
				.IsRequired()
				.HasMaxLength(EntityValidationConstants.ContactRequest.QuestionMinLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.ContactRequest.QuestionMaxLength})");

			builder
				.Property(cr => cr.CreatedAt)
				.HasColumnType("DATETIME2")
				.HasDefaultValueSql("GETDATE()");
		}
	}
}
