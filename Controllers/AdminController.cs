// ✅ AdminController.cs

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gestion_de_stock.Models;
using Microsoft.AspNetCore.Authorization;

namespace Gestion_de_stock.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly StockContext _context;
        public AdminController(StockContext context) => _context = context;

        public IActionResult Dashboard()
        {
            ViewBag.TotalProduits = _context.Produits.Count();
            ViewBag.TotalServices = _context.Services.Count();
            ViewBag.TotalDemandes = _context.Demandes.Count();
            ViewBag.DemandesNonTraitees = _context.Demandes.Count(d => d.Statut == "Non Traité");
            return View();
        }

        public IActionResult Produits() => View(_context.Produits.ToList());
        public IActionResult AjouterProduit() => View();
        [HttpPost]
        public IActionResult AjouterProduit(Produit p)
        {
            if (ModelState.IsValid)
            {
                _context.Produits.Add(p);
                _context.SaveChanges();
                return RedirectToAction("Produits");
            }
            return View(p);
        }

        public IActionResult Services() => View(_context.Services.ToList());
        public IActionResult AjouterService() => View();
        [HttpPost]
        public IActionResult AjouterService(Service s)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(s);
                _context.SaveChanges();
                return RedirectToAction("Services");
            }
            return View(s);
        }

        public IActionResult Demandes() => View(_context.Demandes.OrderByDescending(d => d.DateDemande).ToList());
        public IActionResult TraiterDemande(int id)
        {
            var demande = _context.Demandes.Find(id);
            if (demande == null) return NotFound();
            return View(demande);
        }
        [HttpPost]
        public IActionResult TraiterDemande(int id, string statut)
        {
            var demande = _context.Demandes.Find(id);
            if (demande != null)
            {
                demande.Statut = statut;
                _context.SaveChanges();
                return RedirectToAction("Demandes");
            }
            return NotFound();
        }
        // GET : Admin/Edit/5
        public IActionResult Edit(int id)
        {
            var produit = _context.Produits.Find(id);
            if (produit == null) return NotFound();
            return View("Edit", produit); // Vue Edit.cshtml
        }

        [HttpPost]
        public IActionResult Edit(Produit p)
        {
            if (ModelState.IsValid)
            {
                _context.Produits.Update(p);
                _context.SaveChanges();
                return RedirectToAction("Produits");
            }
            return View("Edit", p);
        }

        // GET : Admin/Delete/5
        public IActionResult Delete(int id)
        {
            var produit = _context.Produits.Find(id);
            if (produit == null) return NotFound();
            return View("Delete", produit); // Vue Delete.cshtml
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var produit = _context.Produits.Find(id);
            if (produit == null) return NotFound();

            _context.Produits.Remove(produit);
            _context.SaveChanges();
            return RedirectToAction("Produits");
        }
        // GET : Admin/EditService/5
        public IActionResult EditService(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null) return NotFound();
            return View(service); // Va chercher EditService.cshtml
        }

        [HttpPost]
        public IActionResult EditService(Service s)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Update(s);
                _context.SaveChanges();
                return RedirectToAction("Services");
            }
            return View(s);
        }

        // GET : Admin/DeleteService/5
        public IActionResult DeleteService(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null) return NotFound();
            return View(service); // Va chercher DeleteService.cshtml
        }

        [HttpPost, ActionName("DeleteService")]
        public IActionResult DeleteServiceConfirmed(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null) return NotFound();

            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("Services");
        }

    }
}