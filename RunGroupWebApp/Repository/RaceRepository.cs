using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Models;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;

namespace RunGroupWebApp.Repository
{
	public class RaceRepository : IRaceRepository
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
			return await context.Races.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Race> GetByIdNoTracking(int id)
		{
			return await context.Races.Include(x => x.Address).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<Race>> GetAllRacesByCity(string city)
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
