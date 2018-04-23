using RazorPages.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Infrastrucutre
{
    // Dependiente Injection.. Logika w BookRepository
    public interface IBookRepository
    {
        Task<IList<Book>> GetBooks();
        Task<Book> GetBook(int Id);
        Task AddBooks(Book book);
        Task<Book> EditBook(Book book);
        Task RemoveBook(int Id);

    }
}
