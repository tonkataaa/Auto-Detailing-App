namespace AutoDetailingApp.Areas.Admin.Controllers
{
	using AutoDetailingApp.Data.Repository.Interfaces;
	using AutoDetailingApp.Models;
	using AutoDetailingApp.Web.ViewModels;
	using AutoDetailingApp.Web.ViewModels.Reservation;
	using Microsoft.AspNetCore.Mvc;
	using static Common.ApplicationConstants;

    [Area(AdminRoleName)]
    public class ClientInformationController : Controller
    {
		private readonly IRepository<Appointment, Guid> _reservationRepository;
		private readonly IRepository<ContactRequest, Guid> _contactRepository;

		public ClientInformationController(IRepository<Appointment, Guid> reservationRepository,
			IRepository<ContactRequest, Guid> contactRepository)
		{
			this._reservationRepository = reservationRepository;
			this._contactRepository = contactRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Details()
        {
			var reservations = await _reservationRepository.GetAllAsync();

			return View(reservations);
		}


		[HttpGet]
		public async Task<IActionResult> ContactDetails()
        {
			var contactRequests = await _contactRepository.GetAllAsync();

            return View(contactRequests);
        }

		[HttpPost]
		public async Task<IActionResult> DeleteReservation(ReservationFormModel model)
		{
			if (model.PhoneNumber == null)
			{
				return BadRequest("Невалиден телефон за резервация");
			}

			var reservationEmail = await _reservationRepository.GetByEmailAsync(model.Email);

			if (reservationEmail == null)
			{
				return NotFound("Резервацията не съществува.");
			}

			await this._reservationRepository.DeleteAsync(reservationEmail);

			return RedirectToAction("Details");
		}

		[HttpPost]
		public async Task<IActionResult> DeleteContactForm (ContactFormModel model)
		{
			if (model.Email == null)
			{
				return BadRequest("Имейлът не е намерен");
			}

			var contactEmail = await _contactRepository.GetByContactEmailAsync(model.Email);

			if (contactEmail == null)
			{
				return NotFound("Имейлът не съществува!");
			}

			await _contactRepository.DeleteAsync(contactEmail);

			return RedirectToAction("ContactDetails");
		}
    }
}
