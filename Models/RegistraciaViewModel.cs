using System.ComponentModel.DataAnnotations;

namespace VAII_Semestralka.Models
{
	public class RegistraciaViewModel
	{
		[Required]
		[MinLength(5, ErrorMessage = "Meno musí mať aspoň 5 znakov.")]
		public string Meno { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[MinLength(8, ErrorMessage = "Heslo musí mať aspoň 8 znakov.")]

		public string Heslo { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare("Heslo", ErrorMessage = "Heslá sa nezhodujú")]
		public string PotvrdenieHesla { get; set; }
	}
}
