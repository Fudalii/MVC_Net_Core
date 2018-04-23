using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Infrastrucutre;
using RazorPages.Models;

namespace RazorPages.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        private readonly IBookRepository _booksRepo;

        [TempData]
        public string Message { get; set; }

        public EditModel(ApplicationDbContext db, IBookRepository booksRepo)
        {
            _db = db;
            _booksRepo = booksRepo;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int Id)
        {
            Book = await _booksRepo.GetBook(Id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
          
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _booksRepo.EditBook(Book);

            Message = "Update Ok :) ";
            
            return RedirectToPage("Index");
        }


    }
}