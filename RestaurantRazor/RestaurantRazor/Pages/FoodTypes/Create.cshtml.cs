using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantRazor.Data;
using RestaurantRazor.Models;

namespace RestaurantRazor.Pages.FoodTypes
{
    public class CreateModel : PageModel
    {
        private readonly RestaurantRazor.Data.ApplicationDbContext _context;

        public CreateModel(RestaurantRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FoodType FoodType { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FoodType.Add(FoodType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}