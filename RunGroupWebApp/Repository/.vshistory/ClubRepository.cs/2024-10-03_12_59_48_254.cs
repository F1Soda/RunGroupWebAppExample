﻿using RunGroopWebApp.Models;
using RunGroupWebApp.Data;
using RunGroupWebApp.Interfaces;

namespace RunGroupWebApp.Repository
{
	public class ClubRepository : IClubRepository
	{
		private readonly ApplicationDbContext context;

		public ClubRepository(ApplicationDbContext context)
		{

		}

		public bool Add(Club club)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Club club)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Club>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<Club> GetById(int id)
		{
			throw new NotImplementedException();
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