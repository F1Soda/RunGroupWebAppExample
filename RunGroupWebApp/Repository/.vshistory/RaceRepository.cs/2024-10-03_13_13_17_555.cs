using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Models;
using RunGroupWebApp.Data;

namespace RunGroupWebApp.Repository
{
	public class RaceRepository
	{
		private readonly ApplicationDbContext context;

		public RaceRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public bool Add(Race race)
		{
			context.Add(race);
			return Save();
		}

		public bool Delete(Race race)
		{
			context.Remove(race);
			return Save();
		}

		public async Task<IEnumerable<Race>> GetAll()
		{
			return await context.Races.ToListAsync();
		}

		public async Task<Race> GetById(int id)
		{
			return await context.Races.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<Race>> GetClubByCity(string city)
		{
			return await context.Races.Where(x => x.Address.City.Contains(city)).ToListAsync();
		}

		public bool Save()
		{
			var saved = context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(Race race)
		{
			context.Update(race);
			return Save();
		}
	}
}
