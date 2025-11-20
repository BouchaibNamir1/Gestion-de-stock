using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Gestion_de_stock.Models;
using System.Linq;
using System;

namespace Gestion_de_stock.Controllers
{
    [Authorize(Roles = "Clinique")]
    public class CliniqueController : Controller
    {
        private readonly StockContext _context;

        public CliniqueController(StockContext context)
        {
            _context = context;
        }

        // Méthode utilitaire pour récupérer le nom de la clinique depuis les claims
        private string GetCliniqueNom()
        {
            // Remplace "CliniqueNom" par le nom du claim que tu as configuré
            var cliniqueNom = User.Claims.FirstOrDefault(c => c.Type == "CliniqueNom")?.Value;
            return cliniqueNom ?? User.Identity.Name;
        }

        public IActionResult Dashboard()
        {
            string cliniqueNom = GetCliniqueNom();

            ViewBag.Produits = _context.Produits.ToList();
            ViewBag.Services = _context.Services.ToList();
            ViewBag.MesDemandes = _context.Demandes
                .Where(d => d.CliniqueNom == cliniqueNom)
                .OrderByDescending(d => d.DateDemande)
                .ToList();

            return View();
        }

        public IActionResult Produits()
        {
            var produits = _context.Produits.ToList();
            return View(produits);
        }

        public IActionResult Services()
        {
            var services = _context.Services.ToList();
            return View(services);
        }

        public IActionResult Demandes()
        {
            string cliniqueNom = GetCliniqueNom();

            var demandes = _context.Demandes
                .Where(d => d.CliniqueNom == cliniqueNom)
                .OrderByDescending(d => d.DateDemande)
                .ToList();

            return View(demandes);
        }

        [HttpGet]
        public IActionResult FaireDemande()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FaireDemande(Demande d)
        {
            if (ModelState.IsValid)
            {
                d.CliniqueNom = GetCliniqueNom();
                d.DateDemande = DateTime.Now;
                d.Statut = "Non Traité";

                _context.Demandes.Add(d);
                _context.SaveChanges();

                return RedirectToAction("Dashboard");
            }

            return View(d);
        }

        public IActionResult Apropos()
        {
            return View();
        }
    }
}
