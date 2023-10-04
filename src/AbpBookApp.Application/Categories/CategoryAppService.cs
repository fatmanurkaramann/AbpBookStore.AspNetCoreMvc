using Abp.Application.Services;
using Abp.Domain.Repositories;
using AbpBookApp.Books.Dto;
using AbpBookApp.Categories.Dto;
using AbpBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Categories
{
    public class CategoryAppService : AsyncCrudAppService<Category, CategoryDto, int, PagedCategoryResultRequestDto, CreateCategoryDto, CategoryDto>,
        ICategoryAppService
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryAppService(IRepository<Category, int> repository, ICategoryManager categoryManager) : base(repository)
        {
            _categoryManager = categoryManager;
        }

       
        public  List<CategoryDto> GetAllCategories()
        {
            var categories = _categoryManager.GetAll();
            var categoryDtos = ObjectMapper.Map<List<CategoryDto>>(categories);
            return categoryDtos;
        }
    }
}
