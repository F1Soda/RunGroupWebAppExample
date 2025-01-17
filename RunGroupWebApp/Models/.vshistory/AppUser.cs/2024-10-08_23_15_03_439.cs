﻿using Microsoft.AspNetCore.Identity;
using RunGroopWebApp.Models;

namespace RunGroupWebApp.Models
{
	public class AppUser : IdentityUser
	{
		public int? Pace { get; set; }
		public int? Milage { get; set; }
		public Address Address { get; set; }

		public ICollection<Club> Clubs { get; set; }
		public ICollection<Race> Races { get; set; }
	}
}
