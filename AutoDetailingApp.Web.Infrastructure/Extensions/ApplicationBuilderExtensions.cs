namespace AutoDetailingApp.Web.Infrastructure.Extensions
{
	using Microsoft.Extensions.DependencyInjection;

	using AutoDetailingApp.Data.Repository.Interfaces;
	using AutoDetailingApp.Data.Repository;
	using AutoDetailingApp.Models;
	using AutoDetailingApp.Services.Data.Interfaces;
	using AutoDetailingApp.Services.Data;

	public static class ApplicationBuilderExtensions
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));

			services.AddScoped<IRepository<Service, Guid>, BaseRepository<Service, Guid>>();
			services.AddScoped<IAdminService, AdminService>();
			services.AddScoped<IContactService, ContactService>();
			services.AddScoped<IReservationService, ReservationService>();

			return services;
		}
	}
}
