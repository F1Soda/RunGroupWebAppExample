using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Models;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.Repository;
using RunGroupWebApp.ViewModels;

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

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Race race)
		{
			if (!ModelState.IsValid)
			{
				return View(race);
			}
			raceRepository.Add(race);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Edit(int id)
		{
			var race = await raceRepository.GetById(id);
			if (race == null) return View("Error");
			var raceVM = new EditRaceViewModel
			{
				Title = race.Title,
				Description = race.Description,
				AddressId = race.AddressId,
				RaceCategory = race.RaceCategory,
				Address = race.Address,
				Image = race.Image
			};
			return View(raceVM);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, EditRaceViewModel raceVM)
		{
			if (!ModelState.IsValid)
			{
				// ???AddModelError???
				ModelState.AddModelError("", "Failed to edit race");
				return View("Error");
			}
			// Так нельзя из-за отслеживания нескольких контекстов
			//var userClub = await clubRepository.GetById(id);

			var userClub = await raceRepository.GetByIdNoTracking(id);

			var race = new Race
			{
				Id = id,
				Title = raceVM.Title,
				Description = raceVM.Description,
				Image = raceVM.Image,
				AddressId = raceVM.AddressId,
				Address = raceVM.Address,
				RaceCategory= raceVM.RaceCategory,
			};

			raceRepository.Update(race);

			return RedirectToAction("Index");
		}
	}
}
