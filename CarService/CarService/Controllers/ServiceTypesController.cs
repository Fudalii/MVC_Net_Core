using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Data;
using CarService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Controllers
{
    public class ServiceTypesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ServiceTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        

        // Get: ServiceTypes/Index
        public IActionResult Index()
        {
            var ServiceTypeList = _db.ServiceTypes.ToList();

            return View(ServiceTypeList);
        }

        // C R E A T E 

        //GET: ServiceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: ServiceTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceType serviceType)
        {
            if (ModelState.IsValid)
            {
                _db.ServiceTypes.Add(serviceType);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(serviceType);

        }






        // Dispose to metoda zwalniająca zasoby 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }

    }
}