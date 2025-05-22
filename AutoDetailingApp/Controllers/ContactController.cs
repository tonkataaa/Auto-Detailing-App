
namespace AutoDetailingApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

	using AutoMapper;


	using CinemaApp.Data;
    using AutoDetailingApp.Web.ViewModels;
	using AutoDetailingApp.Models;

	public class ContactController : Controller
    {
        private readonly IMapper mapper;
		private readonly AutoDetailingDbContext dbContext;

		public ContactController(AutoDetailingDbContext dbContext, IMapper mapper)
		{
            this.dbContext = dbContext;
            this.mapper = mapper;
			
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
