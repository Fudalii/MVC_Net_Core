using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantRazor.Data;
using RestaurantRazor.Models;

namespace RestaurantRazor.Pages.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly RestaurantRazor.Data.ApplicationDbContext _context;

        public IndexModel(RestaurantRazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FoodType> FoodType { get;set; }

        public async Task OnGetAsync()
        {
            FoodType = await _context.FoodType.ToListAsync();
        }
    }
}
