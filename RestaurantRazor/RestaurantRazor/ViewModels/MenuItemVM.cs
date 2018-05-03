using Microsoft.AspNetCore.Http;
using RestaurantRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRazor.ViewModels
{
    public class MenuItemVM
    {
        public MenuItem MenuItem { get; set; }
        public IEnumerable<CategoryType> GetCategoryType { get; set; }
        public IEnumerable<FoodType> FoodType { get; set; }
        public IFormFile MyImage { set; get; }
    }
}
