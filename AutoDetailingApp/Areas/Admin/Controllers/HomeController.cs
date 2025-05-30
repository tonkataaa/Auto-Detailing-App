namespace AutoDetailingApp.Areas.Admin.Controllers
{
	using AutoDetailingApp.Models;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;

    using static Common.ApplicationConstants;


    [Area(AdminRoleName)]
    [Authorize(Roles = AdminRoleName)]
    public class HomeController : Controller
    {
		public async Task<IActionResult> Index()
        {
			return this.View();
		}
	}
}
