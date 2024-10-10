﻿using RunGroopWebApp.Data.Enum;
using RunGroupWebApp.Models;

namespace RunGroupWebApp.ViewModels
{
	public class EditClubViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public int AddressId {  get; set; }
		public Address Address { get; set; }
		public ClubCategory MyProperty { get; set; }
	}
}
