using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantRazor.Data;
using RestaurantRazor.Mapper;
using RestaurantRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRazor.Services
{
    
        public class CategoryTypesData : ICategoryTypeData
        {


         private readonly ApplicationDbContext _db;

         private readonly IMapper _mapper;

        public CategoryTypesData(ApplicationDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }



            public async Task CreateCatType(CategoryTypeDTO catType)
            {
                var catTypeMap = _mapper.Map<CategoryType>(catType);
                _db.CategoryTypes.Add(catTypeMap);
                await _db.SaveChangesAsync();
            }



            //Get All CategoryTypes
            public async Task<List<CategoryTypeDTO>> GetCatTypes()
            {
                var Items = await _db.CategoryTypes.ToListAsync();
                var forReturn = _mapper.Map<List<CategoryTypeDTO>>(Items);

                return forReturn;

            }


            //Get One CategroyType 
            public async Task<CategoryTypeDTO> GetCatType(int id)
            {
                var CarType = await _db.CategoryTypes.SingleOrDefaultAsync(x => x.Id == id);
                var forReturn = _mapper.Map<CategoryTypeDTO>(CarType);

                return forReturn;

            }


            public async Task EditCatType(CategoryTypeDTO catType)
            {
                 var catTypeMap = _mapper.Map<CategoryType>(catType);

            _db.CategoryTypes.Update(catTypeMap);

                 await _db.SaveChangesAsync();
            }







            public async void RemoveCatType(int Id)
            {
                    var Item = _db.CategoryTypes.SingleOrDefault(x => x.Id == Id);
                    if (Item != null)
                    {
                      _db.CategoryTypes.Remove(Item);
                      await _db.SaveChangesAsync();
                    };
            }


        }
  
}
