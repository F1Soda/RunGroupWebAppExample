using Microsoft.AspNetCore.Mvc;
using RunGroopWebApp.Models;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;
using RunGroupWebApp.ViewModels;

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

		public async Task<IActionResult> Edit(int id)
		{
			var club = await clubRepository.GetById(id);
			if (club == null) return View("Error");
			var clubVM = new EditClubViewModel
			{
				Title = club.Title,
				Description = club.Description,
				AddressId = club.AddressId.Value,
				Address = club.Address,
				Image = club.Image
			};
			return View(clubVM);
		}
	}
}
