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
			return await context.Clubs.FirstOrDefaultAsync(x => x.Id = id);
		}

		public Task<IEnumerable<Club>> GetClubByCity(string city)
		{
			throw new NotImplementedException();
		}

		public bool Save()
		{
			throw new NotImplementedException();
		}

		public bool Update(Club club)
		{
			throw new NotImplementedException();
		}
	}
}
