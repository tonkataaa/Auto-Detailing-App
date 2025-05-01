
namespace AutoDetailingApp.Web.ViewModels
{
	using System.ComponentModel.DataAnnotations;

	using AutoDetailingApp.Common;

	public class ContactFormModel
	{
		[Required]
		[MinLength(EntityValidationConstants.ContactRequest.NameMinLength)]
		[MaxLength(EntityValidationConstants.ContactRequest.NameMaxLength)]
		public string Name { get; set; }

		[Required]
		public string PhoneNumber { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		[MinLength(EntityValidationConstants.ContactRequest.QuestionMinLength)]
		[MaxLength(EntityValidationConstants.ContactRequest.QuestionMaxLength)]
		public string Question { get; set; }
	}
}
