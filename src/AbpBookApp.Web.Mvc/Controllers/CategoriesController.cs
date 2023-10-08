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
        [HttpPost]
        public async Task<IActionResult> Remove(int inputID)
        {
            await _categoryAppService.DeleteCategoryId(inputID);
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Index(PagedCategoryResultRequestDto input)
        {
            var categories = await _categoryAppService.GetAllAsync(input);
            return View(Task.FromResult(categories));
        }
        public async Task<ActionResult> CreateModal(CreateCategoryDto categoryDto)
        {
           await _categoryAppService.CreateAsync(categoryDto);
            return RedirectToAction("Index");
        }
    }
}
