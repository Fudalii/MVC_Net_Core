using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantRazor.Data;
using RestaurantRazor.Models;
using RestaurantRazor.ViewModels;

namespace RestaurantRazor.Pages.MenuItems
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CreateModel(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public MenuItemVM MenuItemVM { get; set; }

        public IActionResult OnGet()
        {

            MenuItemVM = new MenuItemVM
            {
                MenuItem = new MenuItem(),
                FoodType = _context.FoodType.ToList(),
                GetCategoryType = _context.CategoryTypes.ToList()
            };

            ViewData["CategoryTypeId"] = new SelectList(_context.CategoryTypes, "Id", "Name");
            ViewData["FoodTypeId"] = new SelectList(_context.FoodTypes, "Id", "Name");

            return Page();

        }

 
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var image = MenuItemVM.MyImage;
            var imageCaption = "PodpisFoto";

            _context.MenuItems.Add(MenuItemVM.MenuItem);
            await _context.SaveChangesAsync();


            //Image Begin Save

            string webRootPath = _hostingEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;

            var menuItemFromDb = _context.MenuItems.Find(MenuItemVM.MenuItem.Id);

            // sprawdzamy czy nasz files zawiera wybrane w input foto 
            if (files[0] != null && files[0].Length > 0)
            {
                // wskazuje folder dla uploads 
                var uploads = Path.Combine(webRootPath, "images");

                // Wycięcie nazy wpliku  do kropki z pozostawieniem np .jpg czy .png 
                var extension = files[0].FileName.Substring(
                    files[0].FileName.LastIndexOf("."),
                    files[0].FileName.Length - files[0].FileName.LastIndexOf(".")
                    );

                // zapisanie pod wybraną wcześniej ścieżką uploads oraz wskazanie nazwy jako ID produktu + wycięte wcześniej rozszerzenie 
                using (var fileStream = new FileStream(Path.Combine(uploads, MenuItemVM.MenuItem.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                // string ściezki dla bazy danych 
                menuItemFromDb.Imege = @"\images\" + MenuItemVM.MenuItem.Id + extension;
            }

            // jeśli nie wybrano żadnego pliku 
            else
            {
                menuItemFromDb.Imege = @"\images\default_food.png";
            }

            // zapisujemy w Bazie danych
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");

        }
    }
}