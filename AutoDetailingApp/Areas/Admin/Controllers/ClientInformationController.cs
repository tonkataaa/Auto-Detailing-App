namespace AutoDetailingApp.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using AutoDetailingApp.Data.Repository.Interfaces;
	using AutoDetailingApp.Models;
	using AutoDetailingApp.Web.ViewModels;
	using AutoDetailingApp.Web.ViewModels.Reservation;

	using static Common.ApplicationConstants;
	using AutoDetailingApp.Services.Data.Interfaces;
    using AutoDetailingApp.Data;

    [Area(AdminRoleName)]
    public class ClientInformationController : Controller
    {
		private readonly IAdminService _adminService;
        private readonly AutoDetailingDbContext _context;

        public ClientInformationController(IAdminService adminService, AutoDetailingDbContext dbContext)
		{
			this._adminService = adminService;
			this._context = dbContext;
        }

		[HttpGet]
		public async Task<IActionResult> Details()
        {
            var reservations = await _adminService.DetailsWithServices();
            return View(reservations);
        }


		[HttpGet]
		public async Task<IActionResult> ContactDetails()
        {
			var contactRequest = await _adminService.ContactDetails();

            return View(contactRequest);
        }

		[HttpPost]
		public async Task<IActionResult> DeleteReservation(ReservationFormModel model)
		{
			await _adminService.DeleteReservationAsync(model);

			return RedirectToAction("Details");
		}

		[HttpPost]
		public async Task<IActionResult> DeleteContactForm (ContactFormModel model)
		{
			await _adminService.DeleteContactAsync(model);
			return RedirectToAction("ContactDetails");
		}
    }
}
