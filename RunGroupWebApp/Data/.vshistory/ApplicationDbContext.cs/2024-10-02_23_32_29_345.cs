﻿using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Models;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Race> Races {  get; set; }
        public DbSet<Club> Clubs {  get; set; }
        public DbSet<Address> Addresses{  get; set; }
    }
}
