using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VAII_Semestralka.Models
{
    public class Produkt
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public TypProduktu Typ { get; set; }

        [Required]
        public string Opis { get; set; }
        [Required]
        public string Obrazok { get; set; }
        [Required]
        public ICollection<Plosny_material> Plosne_materialy { get; set; }
        public Udaje UdajeProduktu { get; set; }


	}
}
