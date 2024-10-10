using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;

namespace RunGroupWebApp.Controllers
{
	public class RaceController : Controller
	{
		private readonly ApplicationDbContext context;

		public RaceController(ApplicationDbContext context)
		{
			this.context = context;
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
