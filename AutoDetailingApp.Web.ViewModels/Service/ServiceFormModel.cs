
namespace AutoDetailingApp.Web.ViewModels
{
	using System.ComponentModel.DataAnnotations;

	using AutoDetailingApp.Common;

	public class ServiceFormModel
	{
		[Required]
		[MinLength(EntityValidationConstants.Service.NameMinLength)]
		[MaxLength(EntityValidationConstants.Service.NameMaxLength)]
		public string Name { get; set; }

		[Required]
		public string PhoneNumber { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		[MinLength(EntityValidationConstants.Service.QuestionMinLength)]
		[MaxLength(EntityValidationConstants.Service.QuestionMaxLength)]
		public string Question { get; set; }
	}
}
