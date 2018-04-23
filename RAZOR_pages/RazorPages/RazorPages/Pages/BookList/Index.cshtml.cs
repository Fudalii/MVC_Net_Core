using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Infrastrucutre;
using RazorPages.Models;

namespace RazorPages.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        private readonly IBookRepository _booksRepo;

        [TempData]
        public string Message { get; set; }

        public IndexModel(ApplicationDbContext db, IBookRepository booksRepo)
        {
            _db = db;
            _booksRepo = booksRepo;
        }

        public IList<Book> Books { get; set;}

        public async Task OnGet()
        {
            Books = await _booksRepo.GetBooks();

        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            //var Book = await _booksRepo.GetBook(Id);
            await _booksRepo.RemoveBook(Id);
            Message = "Remove succesfulllll";

            return RedirectToPage();
        }
    }
}