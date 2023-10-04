using AbpBookApp.Books;
using AbpBookApp.Books.Dto;
using AbpBookApp.Controllers;
using AbpBookApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;
using System;
using System.Threading.Tasks;
using AbpBookApp.Authors;
using System.Linq;
using AbpBookApp.Categories;

namespace AbpBookApp.Web.Controllers
{
    public class BooksController: AbpBookAppControllerBase
    {
        private readonly IBookAppService _bookAppService;
        private readonly IAuthorAppService _authorAppService;
        private readonly ICategoryAppService _categoryAppService;

        private readonly IFileProvider _fileProvider;
        public BooksController(IBookAppService bookAppService, IAuthorAppService authorAppService, IFileProvider fileProvider, ICategoryAppService categoryAppService)
        {
            _bookAppService = bookAppService;
            _authorAppService = authorAppService;
            _fileProvider = fileProvider;
            _categoryAppService = categoryAppService;
        }
        public async Task<ActionResult> Index(PagedBookResultRequestDto input)
        {
            var books = await _bookAppService.GetAllAsync(input);
            var authors = _authorAppService.GetAllAuthors();
            var categories = _categoryAppService.GetAllCategories();
            ViewBag.Authors = authors;
            ViewBag.Categories = categories;

            return View(Task.FromResult(books));
        }
        public IActionResult _CreateModal()
        {
            var authors = _authorAppService.GetAllAuthors();

            var categories = _categoryAppService.GetAllCategories();
            ViewBag.Authors = authors;
            ViewBag.Categories = categories;

            return View();

        }
        [HttpPost]
        public async Task<ActionResult> CreateModal(CreateBookDto input, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var root = _fileProvider.GetDirectoryContents("wwwroot");
                    var images = root.First(x => x.Name == "img");

                    var randomImageName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);

                    var path = Path.Combine(images.PhysicalPath, randomImageName);

                    using (var stream = new FileStream(path, FileMode.Create))
                        imageFile.CopyTo(stream);

                    input.ImagePath = randomImageName;
                }

                await _bookAppService.CreateAsync(input);
                return RedirectToAction("Index");
            }
            else
            {
                var authors = _authorAppService.GetAllAuthors();
                ViewBag.Authors = authors;
                var categories = _categoryAppService.GetAllCategories();
                ViewBag.Categories = categories;
                return View("Index");
            }
        }
    }
}
