using AutoDetailingApp.Models;
using AutoDetailingApp.Web.ViewModels;
using AutoDetailingApp.Web.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDetailingApp.Services.Data.Interfaces
{
    public interface IAdminService
    {
        Task<IEnumerable> Details();

        Task<IEnumerable> ContactDetails();

		Task DeleteReservationAsync(ReservationFormModel model);

        Task DeleteContactAsync(ContactFormModel model);

        Task<IEnumerable<Appointment>> DetailsWithServices();
    }
}
