using Microsoft.AspNetCore.Mvc;
using VAII_Semestralka.Data;

namespace VAII_Semestralka.Controllers
{
    public class Plosny_materialController : Controller
    {
        private readonly AppDbContext _context;
        public Plosny_materialController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Plosne_materialy()
        {
            var materlialy = _context.Materialy.ToList();
            return View(materlialy);
        }
    }
}
