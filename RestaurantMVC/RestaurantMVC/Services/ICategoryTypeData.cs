using RestaurantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMVC.Services
{
    public interface ICategoryTypeData
    {
        void CreateCatType(CategoryType catType);

        //Get Al Category
        Task<List<CategoryType>> GetCatTypes();

        //Get One Categroy by Id
        Task<CategoryType> GetCatType(int id);

        //Edit Categrory by Id
        Task<CategoryType> EditCatType();

        // Delete Category by ID
        Task<CategoryType> RemoveCatType();



    }
}
