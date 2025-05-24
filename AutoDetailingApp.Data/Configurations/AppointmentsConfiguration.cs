
namespace AutoDetailingApp.Data.Configurations
{

	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using AutoDetailingApp.Common;
	using AutoDetailingApp.Models;

	public class AppointmentsConfiguration : IEntityTypeConfiguration<Appointment>
	{
		public void Configure(EntityTypeBuilder<Appointment> builder)
		{
			builder
				.HasKey(ap => ap.Id);

			builder
				.HasOne(ap => ap.User)
				.WithMany(u => u.Appointments)
				.HasForeignKey(ap => ap.UserId)
				.HasConstraintName("FK_Appointments_Users")
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.HasOne(ap => ap.Service)
				.WithMany(u => u.Appointments)
				.HasForeignKey(ap => ap.ServiceId)
				.HasConstraintName("FK_Appointments_Services")
				.OnDelete(DeleteBehavior.Restrict);

			builder
				.Property(ap => ap.FullName)
				.IsRequired()
				.HasMaxLength(EntityValidationConstants.Appointment.FullNameMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.Appointment.FullNameMaxLength})");

			builder
				.Property(ap => ap.PhoneNumber)
				.IsRequired()
				.HasMaxLength(EntityValidationConstants.Appointment.PhoneNumberMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.Appointment.PhoneNumberMaxLength})");

			builder
				.Property(ap => ap.Email)
				.IsRequired()
				.HasMaxLength(EntityValidationConstants.Appointment.EmailMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.Appointment.EmailMaxLength})");


			builder
				.Property(ap => ap.Status)
				.IsRequired()
				.HasMaxLength(EntityValidationConstants.Appointment.StatusMaxLength)
				.HasColumnType($"NVARCHAR({EntityValidationConstants.Appointment.StatusMaxLength})")
				.HasDefaultValue("Pending");

			builder
				.Property(ap => ap.DateTime)
				.HasColumnType("DATETIME2")
				.IsRequired();


			builder
				.Property(ap => ap.CreatedAt)
				.HasColumnType("DATETIME2")
				.HasDefaultValueSql("GETDATE()")
				.ValueGeneratedOnAdd();

			builder.HasIndex(ap => ap.DateTime);
			builder.HasIndex(ap => ap.Status);
		}
	}
}
