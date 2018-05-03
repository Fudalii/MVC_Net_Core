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
    public class DetailsModel : PageModel
    {
        private readonly RestaurantRazor.Data.ApplicationDbContext _context;

        public DetailsModel(RestaurantRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
