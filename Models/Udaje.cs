using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VAII_Semestralka.Models
{
	public class Udaje
	{
		[Key]
		public int Id { get; set; }
		public DateTime CasVytvorenia { get; set; }
		public DateTime CasPoslednejZmeny { get; set; }
	}

}
