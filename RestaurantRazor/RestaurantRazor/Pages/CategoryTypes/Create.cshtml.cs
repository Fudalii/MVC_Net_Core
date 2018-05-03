using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantRazor.Data;
using RestaurantRazor.Mapper;
using RestaurantRazor.Services;
using RestaurantRazor.Utility;

namespace RestaurantRazor.Pages.CategoryTypes
{
    [Authorize(Roles = SD.AdminEndUser)]
    public class CreateModel : PageModel
    {
       // private readonly ApplicationDbContext _db;

        private readonly ICategoryTypeData _repo;


        //Konstruktor
        public CreateModel(ApplicationDbContext db, ICategoryTypeData repo)
        {
            _repo = repo;
        }

        [BindProperty]
        public CategoryTypeDTO CategoryTypeDTO { get; set; }


        public IActionResult OnGet()
        {
            return Page();
        }

       

        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            await _repo.CreateCatType(CategoryTypeDTO);

            return RedirectToPage("./Index");

        }

    }
}