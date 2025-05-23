
namespace AutoDetailingApp.Web.ViewModels
{
	using System.ComponentModel.DataAnnotations;

	using AutoDetailingApp.Common;
	using static AutoDetailingApp.Common.EntityValidationMessages.Contact;
	using static AutoDetailingApp.Common.EntityValidationConstants.ContactRequest;
	using AutoDetailingApp.Services.Mapping;
	using AutoDetailingApp.Models;

	public class ContactFormModel : IMapTo<ContactRequest>
	{
		[Required(ErrorMessage = NameRequiredMessage)]
		[MinLength(NameMinLength, ErrorMessage = NameMinMessage)]
		[MaxLength(NameMaxLength, ErrorMessage = NameMaxMessage)]
		public string Name { get; set; }

		[Required]
		[Phone(ErrorMessage = PhoneNumberRequiredMessage)]
		[MinLength(PhonenumberMinLength, ErrorMessage = PhoneNumberMinMessage)]
		[MaxLength(PhoneNumberMaxLength, ErrorMessage = PhoneNumberMaxMessage)]
		public string PhoneNumber { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = EntityValidationMessages.Contact.EmailRequiredMessage)]
		[MinLength(EmailMinLength, ErrorMessage = EmailMinMessage)]
		[MaxLength(EmailMaxLength, ErrorMessage = EmailMaxMessage)]
		public string Email { get; set; }

		[Required(ErrorMessage = EntityValidationMessages.Contact.NameRequiredMessage)]
		[MinLength(QuestionMinLength, ErrorMessage = QuestionMinMessage)]
		[MaxLength(QuestionMaxLength, ErrorMessage = QuestionMaxMessage)]
		public string Question { get; set; }


		public DateTime CreatedAt { get; set; }
	}
}
