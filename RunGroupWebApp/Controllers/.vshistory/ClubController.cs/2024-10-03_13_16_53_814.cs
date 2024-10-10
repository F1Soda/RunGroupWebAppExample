using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;

namespace RunGroupWebApp.Controllers
{
	public class ClubController : Controller
	{
		private readonly IClubRepository clubRepository;

		public ClubController(ApplicationDbContext context, IClubRepository clubRepository)
		{
			this.context = context;
			this.clubRepository = clubRepository;
		}

		public IActionResult Index()
		{
			var clubs = context.Clubs.ToList();
			return View(clubs);
		}


		public IActionResult Detail(int id)
		{
			var club = context.Clubs.Include(a => a.Address).FirstOrDefault(x => x.Id == id);
			return View(club);
		}
	}
}
