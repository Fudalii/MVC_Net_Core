using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantMVC.Data;
using RestaurantMVC.Models;

namespace RestaurantMVC.Services
{
    public class CategoryTypesData : ICategoryTypeData
    {


        private readonly ApplicationDbContext _db;

        public CategoryTypesData(ApplicationDbContext db)
        {
            _db = db;
        }


        public void CreateCatType(CategoryType catType)
        {
             _db.CategoryTypes.Add(catType);
             _db.SaveChanges();
         
        }



        //Get All CategoryTypes
        public async Task<List<CategoryType>> GetCatTypes()
        {
            var Items = await _db.CategoryTypes.ToListAsync();

            return Items;

        }
        
        
        //Get One CategroyType 
        public Task<CategoryType> GetCatType(int id)
        {
            throw new NotImplementedException();
        }


        public Task<CategoryType> EditCatType()
        {
            throw new NotImplementedException();
        }

       


        


        public Task<CategoryType> RemoveCatType()
        {
            throw new NotImplementedException();
        }

       
    }
}
