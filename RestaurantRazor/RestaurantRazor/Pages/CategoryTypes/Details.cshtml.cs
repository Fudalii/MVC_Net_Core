using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantRazor.Mapper;
using RestaurantRazor.Services;

namespace RestaurantRazor.Pages.CategoryTypes
{
    public class DetailsModel : PageModel
    {
        private readonly ICategoryTypeData _repo;
   
        //Konstruktor
        public DetailsModel(ICategoryTypeData repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public CategoryTypeDTO CategoryTypeDTO { get; set; }


        public async Task<IActionResult> OnGet(int Id)
        {
            CategoryTypeDTO = await _repo.GetCatType(Id);
            return Page();
        }
    }
}