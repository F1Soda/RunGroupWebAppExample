using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Models;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;

namespace RunGroupWebApp.Repository
{
	public class ClubRepository : IClubRepository
	{
		private readonly ApplicationDbContext context;

		public ClubRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public bool Add(Club club)
		{
			context.Add(club);
			return Save();
		}

		public bool Delete(Club club)
		{
			context.Remove(club);
			return Save();
		}

		public async Task<IEnumerable<Club>> GetAll()
		{
			return await context.Clubs.ToListAsync();
		}

		public async Task<Club> GetById(int id)
		{
			return await context.Clubs.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Club> GetByIdNoTracking(int id)
		{
			return await context.Clubs.Include(x => x.Address).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IEnumerable<Club>> GetClubByCity(string city)
		{
			return await context.Clubs.Where(x => x.Address.City.Contains(city)).ToListAsync();
		}

		public bool Save()
		{
			var saved = context.SaveChanges();
			return saved > 0 ? true : false;
		}

		public bool Update(Club club)
		{
			context.Update(club);
			return Save();
		}
	}
}
