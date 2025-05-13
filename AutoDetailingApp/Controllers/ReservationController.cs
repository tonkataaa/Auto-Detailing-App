using AutoDetailingApp.Data;
using AutoDetailingApp.Models;
using AutoDetailingApp.Web.ViewModels.Reservation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AutoDetailingApp.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AutoDetailingDbContext dbContext;

		public ReservationController(AutoDetailingDbContext dbContext)
		{
            this.dbContext = dbContext;
		}

		[HttpGet]
        [Authorize]
        public async Task<IActionResult> Reservation()
        {
            var servicesFromDb = await dbContext.Services.ToListAsync();

			var serviceItems = servicesFromDb
	            .Select(s => new SelectListItem
	            {
		            Value = s.Id.ToString(),
		            Text = s.Name
	            })
	            .ToList();

			var model = new ReservationFormModel
            {
                AvailableServices = serviceItems,
                DateForReservation = DateTime.Now
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ReservationForm(ReservationFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View("Reservation");
            }

            var selectedSerivce = await dbContext.Services
                .FirstOrDefaultAsync(s => s.Id == model.ServiceId);

			if (selectedSerivce == null)
			{
				ModelState.AddModelError("", "Избраната услуга не е валидна");
				return View("Reservation", model);
			}

            Guid userId = Guid.Parse(User.Identity.GetUserId());
            

			var appointment = new Appointment
            {
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                DateTime = model.DateForReservation,
                ServiceId = model.ServiceId,
                Comment = model.Comment,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                UserId = userId 
            };

            dbContext.Appointments.Add(appointment);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Reservation));
        }
    }
}
