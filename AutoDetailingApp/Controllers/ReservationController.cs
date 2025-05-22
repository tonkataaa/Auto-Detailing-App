using AutoDetailingApp.Data;
using AutoDetailingApp.Models;
using AutoDetailingApp.Web.ViewModels.Reservation;
using CinemaApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AutoDetailingApp.Controllers
{
	public class ReservationController : Controller
	{
		private readonly AutoDetailingDbContext _dbContext;

		public ReservationController(AutoDetailingDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Reservation()
		{
			var model = new ReservationFormModel
			{
				AvailableServices = await GetAvailableServicesAsync(),
				AvailableHours = GetAvailableHours()
			};
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> GetBookedDays()
		{
			var bookedDays = await _dbContext.Appointments
				.Select(a => new { date = a.DateTime.Date.ToString("yyyy-MM-dd") })
				.Distinct()
				.ToListAsync();

			return Ok(bookedDays);
		}

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> ReservationForm(ReservationFormModel model)
		{
			if (!ModelState.IsValid)
			{
				model.AvailableServices = await GetAvailableServicesAsync();
				model.AvailableHours = GetAvailableHours();
				return View("Reservation", model);
			}

			var isDateBooked = await _dbContext.Appointments
				.AnyAsync(a => a.DateTime.Date == model.DateForReservation.Date);

			if (isDateBooked)
			{
				ModelState.AddModelError("DateForReservation", "Избраната дата вече е заета");
				model.AvailableServices = await GetAvailableServicesAsync();
				model.AvailableHours = GetAvailableHours();
				return View("Reservation", model);
			}

			try
			{
				var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

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

				_dbContext.Appointments.Add(appointment);
				await _dbContext.SaveChangesAsync();

				TempData["SuccessMessage"] = "Успешно резервирахте час за " + model.DateForReservation.ToString("dd.MM.yyyy HH:mm");
				return RedirectToAction(nameof(Reservation));
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Грешка при резервация: {ex.Message}");
				TempData["ErrorMessage"] = $"Грешка: {ex.Message}";
				return RedirectToAction(nameof(Reservation));
			}
		}

		private async Task<List<SelectListItem>> GetAvailableServicesAsync()
		{
			return await _dbContext.Services
				.Select(s => new SelectListItem
				{
					Value = s.Id.ToString(),
					Text = s.Name
				})
				.ToListAsync();
		}

		private List<SelectListItem> GetAvailableHours()
		{
			var hours = new List<string> { "8:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
			return hours.Select(h => new SelectListItem { Value = h, Text = h }).ToList();
		}
	}
}