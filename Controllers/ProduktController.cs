using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using VAII_Semestralka.Data;
using VAII_Semestralka.Models;

namespace VAII_Semestralka.Controllers
{
    public class ProduktController : Controller
    {

        private readonly AppDbContext _context;

        public ProduktController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Produkty()
        {
            var produkty = _context.Produkty.ToList();
            return View(produkty);
        }

        [HttpGet]
        public IActionResult Vytvor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Vytvor(Produkt produkt)
        {
			string upravenyObrazok = "images/" + produkt.Typ + "/" + produkt.Obrazok;
			produkt.Obrazok = upravenyObrazok;
			if (ModelState.IsValid)
	        {
		        _context.Produkty.Add(produkt);
		        _context.SaveChanges();
		        return RedirectToAction("Produkty");
	        }

	        return View();
        }
		[HttpGet]
		public IActionResult Vymaz(int id)
		{
			 var produkt = _context.Produkty.FirstOrDefault(p => p.Id == id);

			 if (produkt == null)
			 {
			     return NotFound();
			 }

			 _context.Produkty.Remove(produkt);
			 _context.SaveChanges();

			return RedirectToAction("Produkty");
		}

		[HttpGet]
		public IActionResult Najdi(int id)
		{
			var produkt = _context.Produkty.FirstOrDefault(p => p.Id == id);
			if (produkt == null)
			{
				return RedirectToAction("Produkty");
			}

			return Redirect(produkt.Obrazok);
		}

		
		[HttpGet]
		public IActionResult Uprav(int id)
		{
			var produkt = _context.Produkty.FirstOrDefault(p => p.Id == id);
			if (produkt == null) return NotFound();
			var produktModel = new Produkt
			{
				Typ = produkt.Typ,
				Opis = produkt.Opis,
				Obrazok = produkt.Obrazok,
				MaterialID = produkt.MaterialID,

			};
			return View(produktModel);
		}


	}
}
