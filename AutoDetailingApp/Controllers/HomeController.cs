using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AutoDetailingApp.Models;
using AutoDetailingApp.Web.ViewModels.Reservation;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutoDetailingApp.Data;
using System.Data.Entity;
using AutoDetailingApp.Services.Data;
using AutoDetailingApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;

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
        ViewData["Title"] = "Начало | VivoDetailing";
        ViewData["MetaDescription"] = "Професионално авто детайлиране в Огняново. Полиране, вътрешно и външно почистване, керамична защита.";
        ViewData["MetaKeywords"] = "авто детайлиране, полиране, външно, вътрешно почистване, Огняново, Пазарджик, Пловдив";

        return View();
    }

    public IActionResult Services()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        ViewData["Title"] = "За Нас | VivoDetailing";
        ViewData["MetaDescription"] = "Научете повече за екипа на Vivo Detailing, нашата мисия и страстта ни към професионалното авто детайлиране.";
        ViewData["MetaKeywords"] = "за нас, екип, Vivo Detailing, авто детайлиране, мисия";

        return View();
    }

    public async Task<IActionResult> Contact()
    {
        return this.View();
    }

    [HttpGet]
    [Authorize]
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
