using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDetailingApp.Web.ViewModels.Account
{
    public class LoginViewModel
    {
		[Required(ErrorMessage = "Моля въведете имейла си!")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Моля въведете парола!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool RememberMe { get; set; }
	}
}
