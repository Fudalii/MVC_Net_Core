using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RestaurantMVC.Models;

namespace RestaurantMVC.Mapper
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
