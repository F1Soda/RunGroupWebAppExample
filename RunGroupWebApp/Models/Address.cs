using System.ComponentModel.DataAnnotations;

namespace RunGroupWebApp.Models
{
	public class Address
	{
		// Че такое?
		[Key]
		public int Id { get; set; }
        public string Street { get; set; }
		public string City { get; set; }
		public string State { get; set; }
    }
}
