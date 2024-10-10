using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Models;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;

namespace RunGroupWebApp.Controllers
{
	public class ClubController : Controller
	{
		private readonly IClubRepository clubRepository;

		public ClubController(ApplicationDbContext context, IClubRepository clubRepository)
		{
			this.clubRepository = clubRepository;
		}

		public async Task<IActionResult> Index()
		{
			var clubs = await clubRepository.GetAll();
			return View(clubs);
		}


		public async Task<IActionResult> Detail(int id)
		{
			var club = await clubRepository.GetById(id);
			return View(club);
		}

		public IActionResult Create()
		{
			return View();
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
