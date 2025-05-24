namespace AutoDetailingApp.Services.Data.Interfaces
{
	using Microsoft.AspNetCore.Mvc.Rendering;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using AutoDetailingApp.Web.ViewModels.Reservation;

    public interface IReservationService
    {
        Task<List<SelectListItem>> GetAvailableServicesAsync();

        List<SelectListItem> GetAvailableHours();

		Task<bool> TryCreateReservationAsync(ReservationFormModel model, string userId);

		Task<bool> IsDateBookedAsync(DateTime date);
	}
}
