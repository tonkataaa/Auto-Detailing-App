
namespace AutoDetailingApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using AutoDetailingApp.Web.ViewModels;
	using AutoDetailingApp.Data;
	using AutoDetailingApp.Models;

	public class ContactController : Controller
    {
		private readonly AutoDetailingDbContext dbContext;

		public ContactController(AutoDetailingDbContext dbContext)
		{
            this.dbContext = dbContext;
			
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

            var contactRequest = new ContactRequest()
            {
                FullName = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Message = model.Question,
                CreatedAt = DateTime.Now
            };


            await this.dbContext.ContactRequests.AddAsync(contactRequest);
            await this.dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Вашето запитване е изпратено успешно. Очаквайте отговор!";

            return this.RedirectToAction(nameof(Contact));           
        }
    }
}
