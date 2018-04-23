using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj Tytuł")]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Avaibility { get; set; }
        public double Price { get; set; }
    }
}
