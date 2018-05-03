using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantRazor.Data;
using RestaurantRazor.Mapper;
using RestaurantRazor.Services;

namespace RestaurantRazor.Pages.CategoryTypes
{
    public class IndexModel : PageModel
    {

        private readonly ICategoryTypeData _repo;


        //Konstruktor
        public IndexModel(ApplicationDbContext db, ICategoryTypeData repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public List<CategoryTypeDTO> CategoryTypeDTO { get; set; }

        // ========================


        public async Task<IActionResult> OnGet()
        {
            CategoryTypeDTO = await _repo.GetCatTypes();

            return Page();
        }

        public async Task<IActionResult> OnGetRemove(int id)
        {
           _repo.RemoveCatType(id);
            return RedirectToPage("Index");

        }
    }
}