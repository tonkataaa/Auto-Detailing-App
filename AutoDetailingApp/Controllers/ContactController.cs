
namespace AutoDetailingApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

	using AutoDetailingApp.Models;
	using AutoDetailingApp.Data;
    using AutoDetailingApp.Web.ViewModels;
    using AutoDetailingApp.Services.Data.Interfaces;

    public class ContactController : Controller
    {
		private readonly AutoDetailingDbContext dbContext;
        private readonly IContactService contactService;

		public ContactController(AutoDetailingDbContext dbContext, IContactService contactService)
		{
            this.dbContext = dbContext;
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

            var contactRequest = contactService.SubmitContactRequestAsync(model);

            TempData["SuccessMessage"] = "Вашето запитване е изпратено успешно. Очаквайте отговор!";

            return this.RedirectToAction(nameof(Contact));           
        }
    }
}
