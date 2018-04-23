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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        private readonly IBookRepository _booksRepo;

        [TempData]
        public string Message { get; set; }

        public CreateModel(ApplicationDbContext db, IBookRepository booksRepo)
        {
            _db = db;
            _booksRepo = booksRepo;
        }

        [BindProperty]
        public Book Book { get; set; }


        public void OnGetAcync()
        {

        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _booksRepo.AddBooks(Book);
            Message = "Dodano pomyślnie";
            return RedirectToPage("Index");
        }

    }
}