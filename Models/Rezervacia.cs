using System.ComponentModel.DataAnnotations;

namespace VAII_Semestralka.Models
{
	public class Rezervacia
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Popis { get; set; }
		[Required]
		public string Meno { get; set; }
	}
}
