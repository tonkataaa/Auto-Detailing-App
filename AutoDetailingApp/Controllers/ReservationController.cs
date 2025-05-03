using AutoDetailingApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace AutoDetailingApp.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AutoDetailingDbContext dbContext;

		public ReservationController(AutoDetailingDbContext dbContext)
		{
            this.dbContext = dbContext;
		}

		[HttpGet]
        public async Task<IActionResult> Reservation()
        {
            return this.View();
        }
    }
}
