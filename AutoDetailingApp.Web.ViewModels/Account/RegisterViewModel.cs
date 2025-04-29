using System.ComponentModel.DataAnnotations;

namespace AutoDetailingApp.Web.ViewModels.Account
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Потребителското име е задължително!")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Паролата е задължителна!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Полето е задължително!")]
		[Compare("Password", ErrorMessage = "Паролите не съвпадат.")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Имейлът е задължителен!")]
		[EmailAddress(ErrorMessage = "Невалиден имейл.")]
		public string Email { get; set; }



		[Required(ErrorMessage = "Телфонът е задължителен")]
		[Phone(ErrorMessage = "Невалиден телефон")]
		public string PhoneNumber { get; set; }
	}
}
