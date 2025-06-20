﻿namespace AutoDetailingApp.Services.Data
{
    using AutoDetailingApp.Data;
	using AutoDetailingApp.Data.Repository.Interfaces;
	using AutoDetailingApp.Models;
	using AutoDetailingApp.Services.Data.Interfaces;
	using AutoDetailingApp.Web.ViewModels;
	using AutoDetailingApp.Web.ViewModels.Reservation;
	using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class AdminService : IAdminService
	{
		private readonly IRepository<Appointment, Guid> _reservationRepository;
		private readonly IRepository<ContactRequest, Guid> _contactRepository;
        private readonly AutoDetailingDbContext _context;


        public AdminService(IRepository<Appointment, Guid> reservationRepository,
			IRepository<ContactRequest, Guid> contactRepository,
            AutoDetailingDbContext context)
		{
			this._reservationRepository = reservationRepository;
			this._contactRepository = contactRepository;
			this._context = context;
        }

        public async Task<IEnumerable<Appointment>> DetailsWithServices()
        {
            return await _context.Appointments
                                 .Include(a => a.Service)
                                 .ToListAsync();
        }

        public async Task<IEnumerable> Details()
		{
			return await _reservationRepository.GetAllAsync();
		}

		public async Task<IEnumerable> ContactDetails()
		{
			return await _contactRepository.GetAllAsync();
		}

		public async Task DeleteContactAsync(ContactFormModel model)
		{
			if (string.IsNullOrEmpty(model.Email))
			{
				throw new ArgumentException("Имейлът не е намерен");
			}

			var contact = await _contactRepository.GetByContactEmailAsync(model.Email);
			if (contact == null)
			{
				throw new KeyNotFoundException("Имейлът не съществува!");
			}

			await _contactRepository.DeleteAsync(contact);
		}

		public async Task DeleteReservationAsync(ReservationFormModel model)
		{
			if (string.IsNullOrEmpty(model.Email))
			{
				throw new ArgumentException("Невалиден имейл за резервация");
			}

			var reservation = await _reservationRepository.GetByEmailAsync(model.Email);
			if (reservation == null)
			{
				throw new KeyNotFoundException("Резервацията не съществува.");
			}

			await _reservationRepository.DeleteAsync(reservation);
		}

	}
}
