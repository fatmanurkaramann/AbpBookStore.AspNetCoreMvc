using AbpBookApp.Authors;
using AbpBookApp.Authors.Dto;
using AbpBookApp.Books;
using AbpBookApp.Books.Dto;
using AbpBookApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AbpBookApp.Web.Controllers
{
    public class AuthorsController: AbpBookAppControllerBase
    {
        private readonly IAuthorAppService _authorAppService;
        private readonly IBookAppService _bookAppService;
        public AuthorsController(IAuthorAppService authorAppService, IBookAppService bookAppService)
        {
            _authorAppService = authorAppService;
            _bookAppService = bookAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int inputID)
        {
            await _authorAppService.DeleteAuthor(inputID);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Index(PagedAuthorResultRequestDto input)
        {
            var authors = await _authorAppService.GetAllAsync(input);
            var books = _bookAppService.GetAllBooksAsync();
            ViewBag.Books = books;
            return View(Task.FromResult(authors));
        }
        public async Task<ActionResult> CreateModal(CreateAuthorDto authorDto)
        {
            if(ModelState.IsValid)
            {
                await _authorAppService.CreateAsync(authorDto);
                return RedirectToAction("Index", "Books");
            }
            else
            {
                var books = _bookAppService.GetAllBooksAsync();
                ViewBag.Books = books;
                return View("Index");

            }
        }
    }
}
