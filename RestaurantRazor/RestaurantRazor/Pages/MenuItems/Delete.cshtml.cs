using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantRazor.Data;
using RestaurantRazor.Models;

namespace RestaurantRazor.Pages.MenuItems
{
    public class DeleteModel : PageModel
    {
        private readonly RestaurantRazor.Data.ApplicationDbContext _context;

        public DeleteModel(RestaurantRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MenuItem MenuItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MenuItem = await _context.MenuItems
                .Include(m => m.CategoryType)
                .Include(m => m.FoodType).SingleOrDefaultAsync(m => m.Id == id);

            if (MenuItem == null)
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

            MenuItem = await _context.MenuItems.FindAsync(id);

            if (MenuItem != null)
            {
                _context.MenuItems.Remove(MenuItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
