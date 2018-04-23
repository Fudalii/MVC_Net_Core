using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Data;
using CarService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var Item = await _db.ServiceTypes.FirstOrDefaultAsync(s => s.Id == id);

            if(Item != null)
            {
                return View(Item);
            }

            return RedirectToAction(nameof(Index));

        }



        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var Item = await _db.ServiceTypes.FirstOrDefaultAsync(s => s.Id == id);

            if (Item != null)
            {
                return View(Item);
            }

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceType serviceType)
        {
            if (ModelState.IsValid)
            {
                var Item = await _db.ServiceTypes.FirstOrDefaultAsync();

                _db.ServiceTypes.Update(Item);

                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(serviceType);

        }


        // HTTPPOST: Delete/id
        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> RemoveServiceType(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var Item = await _db.ServiceTypes.FirstOrDefaultAsync(s => s.Id == id);

            if (Item == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _db.ServiceTypes.Remove(Item);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

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