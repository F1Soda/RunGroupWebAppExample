﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;

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

        public IActionResult Detail(int id)
        {
            var race = 
            return View(race);
        }
    }
}