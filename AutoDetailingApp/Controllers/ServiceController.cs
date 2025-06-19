using Microsoft.AspNetCore.Mvc;

namespace AutoDetailingApp.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Service()
        {
            ViewData["Title"] = "Услуги | VivoDetailing";
            ViewData["MetaDescription"] = "Виж всички услуги за професионално авто детайлиране – външно и вътрешно почистване, полиране, керамична защита.";
            ViewData["MetaKeywords"] = "услуги, авто детайлиране, полиране, външно почистване, вътрешно почистване, керамична защита";

            return View();
		}


    }
}
