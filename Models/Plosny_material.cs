using System.ComponentModel.DataAnnotations;

namespace VAII_Semestralka.Models
{
    public class Plosny_material
    {
        [Key] public int Id { get; set; }
        public string Typ { get; set; }
        public string Obrazok { get; set; }
        public Udaje UdajeMaterialu { get; set; }
	}
}
