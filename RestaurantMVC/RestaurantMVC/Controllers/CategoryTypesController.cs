using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantMVC.Data;
using RestaurantMVC.Mapper;
using RestaurantMVC.Models;
using RestaurantMVC.Services;

namespace RestaurantMVC.Controllers
{
    public class CategoryTypesController : Controller
    {


        public ICategoryTypeData _repo { get; }
        public IMapper _mapper { get; }

        public CategoryTypesController(ICategoryTypeData repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: CategoryTypes
        public async Task<IActionResult> Index()
        {
            var Items = await _repo.GetCatTypes();

            var ItemsToReturn = _mapper.Map<List<CategoryTypeDTO>>(Items);

            return View(ItemsToReturn);
        }

        // GET: CategoryTypes/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var categoryType = await _context.CategoryTypes
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (categoryType == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(categoryType);
        //}



        // GET: CategoryTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: CategoryTypes/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind] CategoryTypeDTO categoryType)
        {
            if (ModelState.IsValid)
            {
                var ItemsToReturn = _mapper.Map<CategoryType>(categoryType);

                _repo.CreateCatType(ItemsToReturn);
       
                return RedirectToAction(nameof(Index));
            }
            return View(categoryType);
        }

        // GET: CategoryTypes/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    var categoryType = await _context.CategoryTypes.SingleOrDefaultAsync(m => m.Id == id);

        //    var ItemsToReturn = _mapper.Map<CategoryTypeDTO>(categoryType);

        //    if (categoryType == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(ItemsToReturn);
        //}

        // POST: CategoryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DisplayOrder")] CategoryType categoryType)
        //{
        //    if (id != categoryType.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(categoryType);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CategoryTypeExists(categoryType.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(categoryType);
        //}

        //// GET: CategoryTypes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var categoryType = await _context.CategoryTypes
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (categoryType == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(categoryType);
        //}

        //// POST: CategoryTypes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var categoryType = await _context.CategoryTypes.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.CategoryTypes.Remove(categoryType);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CategoryTypeExists(int id)
        //{
        //    return _context.CategoryTypes.Any(e => e.Id == id);
        //}
    }
}
