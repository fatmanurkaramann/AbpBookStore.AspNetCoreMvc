using AbpBookApp.Authors;
using AbpBookApp.Authors.Dto;
using AbpBookApp.Books.Dto;
using AbpBookApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AbpBookApp.Web.Controllers
{
    public class AuthorsController: AbpBookAppControllerBase
    {
        private readonly IAuthorAppService _authorAppService;

        public AuthorsController(IAuthorAppService authorAppService)
        {
            _authorAppService = authorAppService;
        }



        public async Task<ActionResult> Index(PagedAuthorResultRequestDto input)
        {
            var authors = await _authorAppService.GetAllAsync(input);
            return View(Task.FromResult(authors));
        }
    }
}
