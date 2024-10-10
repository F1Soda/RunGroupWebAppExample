using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;

namespace RunGroupWebApp.Controllers
{
	public class RaceController : Controller
	{
		private readonly ApplicationDbContext context;
		private readonly IRaceRepository raceRepository;

		public RaceController(ApplicationDbContext context, IRaceRepository raceRepository)
		{
			this.context = context;
			this.raceRepository = raceRepository;
		}

		public IActionResult Index()
		{
			var races = context.Races.ToList();
			return View(races);
		}

        public IActionResult Detail(int id)
        {
            var race = context.Races.Include(a => a.Address).FirstOrDefault(x => x.Id == id);
            return View(race);
        }
    }
}
