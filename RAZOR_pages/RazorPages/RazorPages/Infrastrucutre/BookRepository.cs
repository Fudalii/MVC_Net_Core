using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Infrastrucutre
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddBooks(Book book)
        {
            _db.Add(book);
            await _db.SaveChangesAsync();
        }

        public async Task<Book> EditBook(Book book)
        {
            var Book = await _db.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
        
            _db.Update(book);
            await _db.SaveChangesAsync();

            return book;
        }

        public async Task<Book> GetBook(int Id)
        {
            var Books = await _db.Books.FirstOrDefaultAsync(x => x.Id == Id);

            return Books;
        }

        public async Task<IList<Book>> GetBooks()
        {
            var Books = await _db.Books.ToListAsync();

            return Books;
        }

        public async Task RemoveBook(int Id)
        {
            var Books = await _db.Books.FirstOrDefaultAsync(x => x.Id == Id);

            _db.Remove(Books);
            await _db.SaveChangesAsync();

        }
    }
}
