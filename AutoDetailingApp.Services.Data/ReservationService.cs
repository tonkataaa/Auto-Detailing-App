

namespace AutoDetailingApp.Services.Data
{
	using Microsoft.AspNetCore.Mvc.Rendering;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Query;
	using AutoDetailingApp.Data;
	using AutoDetailingApp.Data.Repository.Interfaces;
	using AutoDetailingApp.Models;
	using AutoDetailingApp.Services.Data.Interfaces;
	using AutoDetailingApp.Web.ViewModels.Reservation;

	public class ReservationService : IReservationService
    {
		private readonly IRepository<Appointment, Guid> reservationRepository;
		private readonly IRepository<Service, Guid> serviceRepository;

		public ReservationService(IRepository<Appointment, Guid> reservationRepository, IRepository<Service, Guid> serviceRepository)
		{
			this.reservationRepository = reservationRepository;
			this.serviceRepository = serviceRepository;
		}

		public List<SelectListItem> GetAvailableHours()
		{
			var hours = new List<string> { "8:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
			return hours.Select(h => new SelectListItem { Value = h, Text = h }).ToList();
		}

		public async Task<List<SelectListItem>> GetAvailableServicesAsync()
		{
			var services = await serviceRepository.GetAllAsync();

			return services.Select(s => new SelectListItem
			{
				Value = s.Id.ToString(),
				Text = s.Name
			}).ToList();
		}

		public async Task<bool> IsDateBookedAsync(DateTime date)
		{
			return await reservationRepository
				.ExistsAsync(a => a.DateTime.Date == date.Date);
		}

		public async Task<bool> TryCreateReservationAsync(ReservationFormModel model, string userId)
		{
			try
			{
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
					UserId = Guid.Parse(userId)
				};

				await reservationRepository.AddAsync(appointment);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
