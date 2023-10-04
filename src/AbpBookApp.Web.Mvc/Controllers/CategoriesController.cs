using AbpBookApp.Authors.Dto;
using AbpBookApp.Categories;
using AbpBookApp.Categories.Dto;
using AbpBookApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AbpBookApp.Web.Controllers
{
    public class CategoriesController : AbpBookAppControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoriesController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public async Task<ActionResult> Index(PagedCategoryResultRequestDto input)
        {
            var categories = await _categoryAppService.GetAllAsync(input);
            return View(Task.FromResult(categories));
        }
    }
}
