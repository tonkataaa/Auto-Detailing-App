using Microsoft.AspNetCore.Mvc;

namespace AutoDetailingApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
