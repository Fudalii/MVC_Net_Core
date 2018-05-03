using AutoMapper;
using RestaurantRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantRazor.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryType, CategoryTypeDTO>();
            CreateMap<CategoryTypeDTO, CategoryType>();
        }

        
   

    }
}
