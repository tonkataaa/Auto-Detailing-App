namespace AutoDetailingApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using System.Security.Claims;

    using AutoDetailingApp.Web.ViewModels.Reservation;
    using AutoDetailingApp.Services.Data.Interfaces;

    public class ReservationController : Controller
	{
        private readonly IReservationService reservationService;

		public ReservationController(IReservationService reservationService)
		{
            this.reservationService = reservationService;
		}

		[HttpGet]
		[Authorize]
		//T0D0 ADD CUSTOM ERROR PAGE
		public async Task<IActionResult> Reservation()
		{
            ViewData["Title"] = "Резервирай час | VivoDetailing";
            ViewData["MetaDescription"] = "Запази час за професионално авто детайлиране при Vivo Detailing. Лесна онлайн резервация на достъпни услуги.";
            ViewData["MetaKeywords"] = "резервация, авто детайлиране, час, почистване, керамика, полиране";

            var model = new ReservationFormModel
			{
				AvailableServices = await reservationService.GetAvailableServicesAsync(),
				AvailableHours = reservationService.GetAvailableHours()
			};

			return View(model);
		}

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ReservationForm(ReservationFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model.AvailableServices = await reservationService.GetAvailableServicesAsync();
				model.AvailableHours = reservationService.GetAvailableHours();
				return View("Reservation", model);
			}

            if (await reservationService.IsDateBookedAsync(model.DateForReservation))
            {
                ModelState.AddModelError("DateForReservation", "Датата е заета");
                model.AvailableServices = await reservationService.GetAvailableServicesAsync();
                model.AvailableHours = reservationService.GetAvailableHours();
                return View("Reservation", model);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            bool isSuccess = await reservationService.TryCreateReservationAsync(model, userId);

			if (isSuccess)
            {
                TempData["SuccessMessage"] = "Резервацията е успешна!";
                return RedirectToAction(nameof(Reservation));
            }
            else
            {
                TempData["ErrorMessage"] = "Грешка при резервация";
                return RedirectToAction(nameof(Reservation));
            }
		}
	}
}