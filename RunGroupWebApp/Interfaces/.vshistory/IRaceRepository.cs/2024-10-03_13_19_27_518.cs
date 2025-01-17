﻿using RunGroopWebApp.Models;

namespace RunGroupWebApp.Interfaces
{
	public interface IRaceRepository
	{
		Task<IEnumerable<Race>> GetAll();
		Task<Race> GetById(int id);
		Task<IEnumerable<Race>> GetAllRacesByCity(string city);
		bool Add(Race race);
		bool Update(Race race);
		bool Delete(Race race);
		bool Save();
	}
}
