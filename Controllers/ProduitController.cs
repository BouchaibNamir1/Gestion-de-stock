using Microsoft.AspNetCore.Mvc;
using Gestion_de_stock.Models;
using System.Linq;

namespace Gestion_de_stock.Controllers
{
    public class ProduitController : Controller
    {
        private readonly StockContext _context;

        public ProduitController(StockContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produits = _context.Produits.ToList();
            return View(produits);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Produit produit)
        {
            if (ModelState.IsValid)
            {
                _context.Produits.Add(produit);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produit);
        }

        public IActionResult Edit(int id)
        {
            var produit = _context.Produits.Find(id);
            if (produit == null)
                return NotFound();

            return View(produit);
        }

        [HttpPost]
        public IActionResult Edit(Produit produit)
        {
            if (ModelState.IsValid)
            {
                _context.Produits.Update(produit);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produit);
        }

        public IActionResult Delete(int id)
        {
            var produit = _context.Produits.Find(id);
            if (produit == null)
                return NotFound();

            _context.Produits.Remove(produit);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
