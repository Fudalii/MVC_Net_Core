using RestaurantRazor.Mapper;
using RestaurantRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRazor.Services
{
    public interface ICategoryTypeData
    {
        Task CreateCatType(CategoryTypeDTO catType);

        //Get Al Category
        Task<List<CategoryTypeDTO>> GetCatTypes();

        //Get One Categroy by Id
        Task<CategoryTypeDTO> GetCatType(int id);

        //Edit Categrory by Id
        Task EditCatType(CategoryTypeDTO catType);

        // Delete Category by ID
        void RemoveCatType(int id);



    }
}
