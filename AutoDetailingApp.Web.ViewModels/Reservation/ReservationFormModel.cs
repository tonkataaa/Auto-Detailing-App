namespace AutoDetailingApp.Web.ViewModels.Reservation
{

	using AutoDetailingApp.Common;
	using static AutoDetailingApp.Common.EntityValidationMessages.Reservation;
	using static AutoDetailingApp.Common.EntityValidationConstants.Reservation;

	using System.ComponentModel.DataAnnotations;

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

		public DateTime DateForReservation { get; set; }

		[Required(ErrorMessage = ServiceRequiredMessage)]
		public string Service { get; set; }


		public bool Status { get; set; }

		[MinLength(CommentMinLength, ErrorMessage = CommentMinMessage)]
		[MaxLength(CommentMaxLength, ErrorMessage = CommentMaxMessage)]
		public string Comment { get; set; }

		public DateTime CreatedAt { get; set; } 
	}
}
