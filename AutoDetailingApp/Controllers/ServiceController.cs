using Microsoft.AspNetCore.Mvc;

namespace AutoDetailingApp.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
			return View("~/Views/Service/Service.cshtml");
		}


    }
}
