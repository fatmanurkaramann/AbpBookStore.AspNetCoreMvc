using AbpBookApp.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Categories.Dto
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<CreateCategoryDto, Category>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();

        }
    }
}
