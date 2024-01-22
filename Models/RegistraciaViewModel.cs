using System.ComponentModel.DataAnnotations;

namespace VAII_Semestralka.Models
{
	public class RegistraciaViewModel
	{
		[Required]
		
		public string Meno { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Heslo { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare("Heslo", ErrorMessage = "Heslá sa nezhodujú")]
		public string PotvrdenieHesla { get; set; }
	}
}
