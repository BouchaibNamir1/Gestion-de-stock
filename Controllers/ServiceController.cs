using Microsoft.AspNetCore.Mvc;
using Gestion_de_stock.Models;
using System.Linq;

namespace Gestion_de_stock.Controllers
{
    public class ServiceController : Controller
    {
        private readonly StockContext _context;

        public ServiceController(StockContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View(services);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Add(service);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        public IActionResult Edit(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
                return NotFound();

            return View(service);
        }

        [HttpPost]
        public IActionResult Edit(Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Services.Update(service);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service);
        }

        public IActionResult Delete(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null)
                return NotFound();

            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
