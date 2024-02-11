using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Authorize(Roles = "Admin")]
		public IActionResult Vytvor()
		{
			var novyProdukt = new Produkt();
			novyProdukt.Plosne_materialy = _context.Materialy.ToList();
            return View(novyProdukt);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Vytvor(Produkt produkt)
        {

			string upravenyObrazok = "/images/" + produkt.Typ + "/" + produkt.Obrazok;
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
		[Authorize(Roles = "Admin")]
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
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt = await _context.Produkty
                .Include(p => p.UdajeProduktu)
                .Include(p=>p.Plosne_materialy)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        [HttpGet]
        public async Task<IActionResult> Uprav(int id)
        {
	        var produkt = await _context.Produkty.FindAsync(id);

	        if (produkt == null)
	        {
		        return NotFound();
	        }
			
	        return View(produkt);
        }

		[HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Uprav(Produkt produkt)
		{
			if (produkt == null)
			{
				return BadRequest("Dáta produktu nie sú platné.");
			}

			var existujuciProdukt = await _context.Produkty.FindAsync(produkt.Id);

			if (existujuciProdukt == null)
			{
				return NotFound();
			}

			existujuciProdukt.Typ = produkt.Typ;
			existujuciProdukt.Opis = produkt.Opis;
			existujuciProdukt.Obrazok = produkt.Obrazok;

			existujuciProdukt.Plosne_materialy = produkt.Plosne_materialy;

			await _context.SaveChangesAsync();

			return RedirectToAction("Produkty");
		}


	}
}
