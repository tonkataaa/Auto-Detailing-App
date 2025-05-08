namespace AutoDetailingApp.Web.ViewModels.Reservation
{

	using AutoDetailingApp.Common;
	using static AutoDetailingApp.Common.EntityValidationMessages.Reservation;
	using static AutoDetailingApp.Common.EntityValidationConstants.Reservation;

	using System.ComponentModel.DataAnnotations;
	using Microsoft.AspNetCore.Mvc.Rendering;

	public class ReservationFormModel
    {
		[Required(ErrorMessage = NameRequiredMessage)]
		[MinLength(NameMinLength, ErrorMessage = NameMinMessage)]
		[MaxLength(NameMaxLength, ErrorMessage = NameMaxMessage)]
		public string FullName { get; set; }

		[Required]
		[Phone(ErrorMessage = PhoneNumberRequiredMessage)]
		[MinLength(PhonenumberMinLength, ErrorMessage = PhoneNumberMinMessage)]
		[MaxLength(PhoneNumberMaxLength, ErrorMessage = PhoneNumberMaxMessage)]
		public string PhoneNumber { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = EmailRequiredMessage)]
		[MinLength(EmailMinLength, ErrorMessage = EmailMinMessage)]
		[MaxLength(EmailMaxLength, ErrorMessage = EmailMaxMessage)]
		public string Email { get; set; }

		public DateTime DateForReservation { get; set; }

		[Required(ErrorMessage = ServiceRequiredMessage)]
		public Guid ServiceId { get; set; }

		public IEnumerable<SelectListItem> AvailableServices { get; set; } = new List<SelectListItem>();

		public bool Status { get; set; }

		[MinLength(CommentMinLength, ErrorMessage = CommentMinMessage)]
		[MaxLength(CommentMaxLength, ErrorMessage = CommentMaxMessage)]
		public string Comment { get; set; }

		public DateTime CreatedAt { get; set; } 
	}
}
