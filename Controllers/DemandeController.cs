using Microsoft.AspNetCore.Mvc;
using Gestion_de_stock.Models;
using System.Linq;

namespace Gestion_de_stock.Controllers
{
    public class DemandeController : Controller
    {
        private readonly StockContext _context;

        public DemandeController(StockContext context)
        {
            _context = context;
        }

        // Afficher la liste des demandes
        public IActionResult Index()
        {
            var demandes = _context.Demandes.ToList();
            return View("~/Views/Clinique/Demandes.cshtml", demandes);
            // ⚠️ Adapter le chemin si la vue est ailleurs
        }

        // Formulaire pour créer une demande
        public IActionResult Create()
        {
            return View("~/Views/Clinique/FaireDemande.cshtml");
            // ⚠️ Adapter selon ton vrai chemin de vue
        }

        // Envoi du formulaire
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Demande demande)
        {
            if (ModelState.IsValid)
            {
                _context.Demandes.Add(demande);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Clinique/FaireDemande.cshtml", demande);
        }
    }
}
