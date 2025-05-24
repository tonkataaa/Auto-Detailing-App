using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AutoDetailingApp.Models;
using AutoDetailingApp.Web.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoDetailingApp.Data;
using System.Data.Entity;
using AutoDetailingApp.Services.Data;
using AutoDetailingApp.Services.Data.Interfaces;

namespace AutoDetailingApp.Controllers;

public class HomeController : Controller
{
    private readonly IReservationService reservationService;

	private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IReservationService reservationService)
    {
        _logger = logger;
        this.reservationService = reservationService;
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
            AvailableServices = await reservationService.GetAvailableServicesAsync(),
            AvailableHours = reservationService.GetAvailableHours()
        };

        return View("~/Views/Reservation/Reservation.cshtml",model);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
