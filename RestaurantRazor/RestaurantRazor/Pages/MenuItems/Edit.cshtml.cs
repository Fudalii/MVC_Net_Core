using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantRazor.Data;
using RestaurantRazor.Models;

namespace RestaurantRazor.Pages.MenuItems
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EditModel(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public MenuItem MenuItem { get; set; }
        public IHostingEnvironment _HostingEnvironment { get; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MenuItem = await _context.MenuItems
                .Include(m => m.CategoryType)
                .Include(m => m.FoodType)
                .SingleOrDefaultAsync(m => m.Id == id);

            if (MenuItem == null)
            {
                return NotFound();
            }

           ViewData["CategoryTypeId"] = new SelectList(_context.CategoryTypes, "Id", "Name");
           ViewData["FoodTypeId"] = new SelectList(_context.FoodTypes, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MenuItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuItemExists(MenuItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            string webRootPath = _hostingEnvironment.WebRootPath;

            var files = HttpContext.Request.Form.Files;

            var menuItemFromDb = _context.MenuItems.Find(MenuItem.Id);

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
                using (var fileStream = new FileStream(Path.Combine(uploads, MenuItem.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                // string ściezki dla bazy danych 
                menuItemFromDb.Imege = @"\images\" + MenuItem.Id + extension;
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

        private bool MenuItemExists(int id)
        {
            return _context.MenuItems.Any(e => e.Id == id);
        }
    }
}
