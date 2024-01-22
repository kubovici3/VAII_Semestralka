using System.ComponentModel.DataAnnotations;

namespace VAII_Semestralka.Models
{
	public class PrihlasenieViewModel
	{
		[Required]
		public string Meno { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Heslo { get; set; }
	}
}
