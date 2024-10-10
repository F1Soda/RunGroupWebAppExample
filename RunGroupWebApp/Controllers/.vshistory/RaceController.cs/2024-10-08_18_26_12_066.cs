using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Models;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.Repository;

namespace RunGroupWebApp.Controllers
{
	public class RaceController : Controller
	{
		private readonly IRaceRepository raceRepository;

		public RaceController(ApplicationDbContext context, IRaceRepository raceRepository)
		{
			this.raceRepository = raceRepository;
		}

		public async Task<IActionResult> Index()
		{
			var races = await raceRepository.GetAll();
			return View(races);
		}

        public async Task<IActionResult> Detail(int id)
        {
            var race = await raceRepository.GetById(id); 
            return View(race);
        }

		[HttpPost]
		public async Task<IActionResult> Create(Club club)
		{
			if (!ModelState.IsValid)
			{
				return View(club);
			}
			clubRepository.Add(club);
			return RedirectToAction("Index");
		}
	}
}
