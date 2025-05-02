
namespace AutoDetailingApp.Web.ViewModels
{
	using System.ComponentModel.DataAnnotations;

	using AutoDetailingApp.Common;

	public class ContactFormModel
	{
		[Required(ErrorMessage = EntityValidationMessages.Contact.NameRequiredMessage)]
		[MinLength(EntityValidationConstants.ContactRequest.NameMinLength, ErrorMessage = EntityValidationMessages.Contact.NameMinMessage)]
		[MaxLength(EntityValidationConstants.ContactRequest.NameMaxLength, ErrorMessage = EntityValidationMessages.Contact.NameMaxMessage)]
		public string Name { get; set; }

		[Required]
		[Phone(ErrorMessage = EntityValidationMessages.Contact.PhoneNumberRequiredMessage)]
		[MinLength(EntityValidationConstants.ContactRequest.PhonenumberMinLength, ErrorMessage = EntityValidationMessages.Contact.PhoneNumberMinMessage)]
		[MaxLength(EntityValidationConstants.ContactRequest.PhoneNumberMaxLength, ErrorMessage = EntityValidationMessages.Contact.PhoneNumberMaxMessage)]
		public string PhoneNumber { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = EntityValidationMessages.Contact.EmailRequiredMessage)]
		[MinLength(EntityValidationConstants.ContactRequest.EmailMinLength, ErrorMessage = EntityValidationMessages.Contact.EmailMinMessage)]
		[MaxLength(EntityValidationConstants.ContactRequest.EmailMaxLength, ErrorMessage = EntityValidationMessages.Contact.EmailMaxMessage)]
		public string Email { get; set; }

		[Required(ErrorMessage = EntityValidationMessages.Contact.NameRequiredMessage)]
		[MinLength(EntityValidationConstants.ContactRequest.QuestionMinLength, ErrorMessage = EntityValidationMessages.Contact.QuestionMinMessage)]
		[MaxLength(EntityValidationConstants.ContactRequest.QuestionMaxLength, ErrorMessage = EntityValidationMessages.Contact.QuestionMaxMessage)]
		public string Question { get; set; }


		public DateTime CreatedAt { get; set; }
	}
}
