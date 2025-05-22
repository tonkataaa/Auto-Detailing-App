using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AutoDetailingApp.Models;
using AutoDetailingApp.Web.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoDetailingApp.Data;
using System.Data.Entity;
using CinemaApp.Data;

namespace AutoDetailingApp.Controllers;

public class HomeController : Controller
{
	private readonly AutoDetailingDbContext _dbContext;
	private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, AutoDetailingDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Services()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public async Task<IActionResult> Contacs()
    {
        return this.View();
    }

    [HttpGet]
    public async Task<IActionResult> Reservation()
    {
        var model = new ReservationFormModel
        {
            AvailableHours = GetAvailableHours(),
            AvailableServices = (IEnumerable<SelectListItem>)GetAvailableServicesAsync()
		};



        return View("~/Views/Reservation/Reservation.cshtml",model);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }



	private List<SelectListItem> GetAvailableHours()
	{
		var hours = new List<string> { "8:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00" };
		return hours.Select(h => new SelectListItem { Value = h, Text = h }).ToList();
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
}
