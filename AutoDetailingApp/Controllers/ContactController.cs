
namespace AutoDetailingApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

	using AutoDetailingApp.Models;
	using AutoDetailingApp.Data;
    using AutoDetailingApp.Web.ViewModels;
    using AutoDetailingApp.Services.Data.Interfaces;

    public class ContactController : Controller
    {
        private readonly IContactService contactService;

		public ContactController(IContactService contactService)
		{
            this.contactService = contactService;
		}

		[HttpGet]
        public async  Task<IActionResult> Contact()
        {
            return  this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactFormModel model)
        {
            if(!ModelState.IsValid)
            {
                return this.View(model);
            }

            try
            {
                await contactService.SubmitContactRequestAsync(model);
                TempData["SuccessMessage"] = "Вашето запитване е изпратено успешно. Очаквайте отговор!";

            }
            catch
            {
                TempData["ErrorMessage"] = "Възникна грешка при изпращането на запитването.Опитайте отново!";
                return this.View(model);
            }


            return this.RedirectToAction(nameof(Contact));           
        }
    }
}
