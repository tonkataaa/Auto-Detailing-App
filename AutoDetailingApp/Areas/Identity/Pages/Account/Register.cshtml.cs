
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoDetailingApp.Views.Account
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    using AutoDetailingApp.Models;
    using AutoDetailingApp.Common;

    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _userStore = userStore;
            _signInManager = signInManager;
            _logger = logger;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = EntityValidationMessages.User.EmailRequiredMessage)]
            [EmailAddress(ErrorMessage = EntityValidationMessages.User.EmailRequiredMessage)]
            [StringLength(EntityValidationConstants.User.EmailMaxLength, ErrorMessage = "Имейлът трябва да бъде поне {0} и максимум {1} символа.", MinimumLength = EntityValidationConstants.User.EmailMinLength)]
            [Display(Name = "Имейл")]
            public string Email { get; set; }

            [Required(ErrorMessage = EntityValidationMessages.User.NameRequiredMessage)]
            [StringLength(EntityValidationConstants.User.FullNameMaxLength, ErrorMessage = "Името трябва да бъде поне {2} и максимум {1} символа.", MinimumLength = EntityValidationConstants.User.FullNameMinLength)]
            [Display(Name = "Потребителско име")]
            public string FullName { get; set; }



            [Required(ErrorMessage = EntityValidationMessages.User.PhoneNumberRequiredMessage)]
            [Phone(ErrorMessage = EntityValidationMessages.User.PhoneNumberRequiredMessage)]
            [StringLength(EntityValidationConstants.User.PhonenumberMinLength, ErrorMessage = "Телефонният номер трябва да бъде поне 10 и максимум 15 символа.", MinimumLength = EntityValidationConstants.User.PhonenumberMinLength)]
            [Display(Name = "Телефонен номер")]
            public string PhoneNumber { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = EntityValidationMessages.User.PasswordRequiredMessage)]
            [StringLength(EntityValidationConstants.User.PasswordMaxLength, ErrorMessage = "Паролата трябва да бъде поне {2} и максимум {1} символа.", MinimumLength = EntityValidationConstants.User.PasswordMinLength)]
            [DataType(DataType.Password)]
            [Display(Name = "Парола")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Потвърди парола")]
            [Compare("Password", ErrorMessage = "Паролите не съвпадат.")]
            public string ConfirmPassword { get; set; }
        }


#pragma warning disable CS1998
        public async Task OnGetAsync(string returnUrl = null)
#pragma warning restore CS1998
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = CreateUser();
                user.Email = Input.Email;
                user.FullName = Input.Email;
                user.PhoneNumber = Input.PhoneNumber;

                await _userStore.SetUserNameAsync(user, Input.FullName, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor.");
            }
        }
    }
}