using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;

namespace RunGroupWebApp.Controllers
{
	public class ClubController : Controller
	{
		private readonly ApplicationDbContext context;

		public ClubController(ApplicationDbContext context)
		{
			this.context = context;
		}

		public IActionResult Index()
		{
			var clubs = context.Clubs.ToList();
			return View(clubs);
		}


		public IActionResult Detail(int id)
		{
			var club = context.Clubs.FirstOrDefault(x => x.Id == id);
			return View(club);
		}
	}
}
