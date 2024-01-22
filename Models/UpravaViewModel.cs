using System.ComponentModel.DataAnnotations;

namespace VAII_Semestralka.Models
{
	public class UpravaViewModel
	{
		[Required]
		public string Meno { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string StareHeslo { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string NoveHeslo { get; set; }

	}
}
