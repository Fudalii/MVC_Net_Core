using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RestaurantRazor.Data;
using RestaurantRazor.Mapper;
using RestaurantRazor.Models;
using RestaurantRazor.Services;

namespace RestaurantRazor.Pages.CategoryTypes
{
    public class EditModel : PageModel
    {
        private readonly ICategoryTypeData _repo;


        //Konstruktor
        public EditModel(ICategoryTypeData repo)
        {
            _repo = repo;

        }

        [BindProperty]
        public CategoryTypeDTO CategoryTypeDTO { get; set; }
        public int EditId {get; set;}


        public async Task<IActionResult> OnGet(int id)
        {
            
            CategoryTypeDTO = await _repo.GetCatType(id);
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repo.EditCatType(CategoryTypeDTO);
  

            return RedirectToPage("./Index");
        }

    }
}