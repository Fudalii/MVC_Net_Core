using BookList.Models;
using Microsoft.EntityFrameworkCore;

namespace BookList.DATA
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options) 
       {

       }

        public DbSet<Book> Books {get; set;}


    }
}