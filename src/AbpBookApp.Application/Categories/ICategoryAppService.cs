using Abp.Application.Services;
using AbpBookApp.Authors.Dto;
using AbpBookApp.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Categories
{
    public interface ICategoryAppService : IAsyncCrudAppService<CategoryDto, int, PagedCategoryResultRequestDto, CreateCategoryDto, CategoryDto>
    {
      List<CategoryDto> GetAllCategories();
    }
}
