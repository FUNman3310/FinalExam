using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalExam.Models
{
	public class ServicesSection
	{
		public int	Id { get; set; }
		
		[StringLength(maximumLength:20)]
		public string Name { get; set; }
		[StringLength(maximumLength:200)]
		public string Description { get; set; }

		public string Image { get; set; }
		[NotMapped]
		public IFormFile ImageFile { get; set; }
	}
}
