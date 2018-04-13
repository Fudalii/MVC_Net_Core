using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.DATA;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookList.Controllers
{
    public class BooksController : Controller

    {
        private readonly DataContext _db;

        public BooksController(DataContext db)
        {
            _db = db;
        }
        
        public DataContext DbContext { get; }

        //Get: Index
        public IActionResult Index()
        {
            return View(_db.Books.ToList());
        }

        // Get: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if(ModelState.IsValid)
            {
                _db.Add(book);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

           var book = await _db.Books.SingleOrDefaultAsync(m => m.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);

        }

        // Edit

        public async Task<IActionResult> Edit(int? Id)
        {
            if(Id == null)
                return NotFound();

            var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == Id);
       
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book book)
        {
            var getBook = await _db.Books.FirstOrDefaultAsync(b => b.Id == book.Id);

            if (getBook == null)
                return NotFound();

            getBook.Name = book.Name;

            _db.Update(getBook);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var book = await _db.Books.SingleOrDefaultAsync(m => m.Id == Id);

            if (book == null)
            {
                return NotFound();
            }

            _db.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

    }
}