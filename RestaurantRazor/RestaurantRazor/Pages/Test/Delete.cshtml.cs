using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantRazor.Data;
using RestaurantRazor.Models;

namespace RestaurantRazor.Pages.Test
{
    public class DeleteModel : PageModel
    {
        private readonly RestaurantRazor.Data.ApplicationDbContext _context;

        public DeleteModel(RestaurantRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryType CategoryType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryType = await _context.CategoryTypes.SingleOrDefaultAsync(m => m.Id == id);

            if (CategoryType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryType = await _context.CategoryTypes.FindAsync(id);

            if (CategoryType != null)
            {
                _context.CategoryTypes.Remove(CategoryType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
