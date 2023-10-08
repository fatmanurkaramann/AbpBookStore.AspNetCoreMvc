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
using Abp.Application.Services.Dto;

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
        public async Task<ActionResult> Edit(int Id)
        {
            var categories = _categoryAppService.GetAllCategories();
            ViewBag.Categories = categories;
            var bookDto = await _bookAppService.GetAsync(new EntityDto(Id));
            var updateDto = new BookUpdateDto
            {
                Author = bookDto.Author,
                CategoryId = bookDto.Category.Id,
                Description = bookDto.Description,
                Id = bookDto.Id,
                ImagePath = bookDto.ImagePath,
                ISBN = bookDto.ISBN,
                Name = bookDto.Name,
                PageCount = bookDto.PageCount,
                Price = bookDto.Price,
                PublishDate = bookDto.PublishDate
            };
            return View(updateDto);
        }
     
        [HttpPost]
        public async Task<IActionResult> Remove(int inputID)
        {
            await _bookAppService.DeleteBookId(inputID);
            return RedirectToAction("Index");
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
        [HttpPost]
        public async Task<ActionResult> UpdateBook(BookUpdateDto book, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFile != null && imageFile.Length > 0)
                    {
                        var root = _fileProvider.GetDirectoryContents("wwwroot");
                        var images = root.First(x => x.Name == "img");

                        var randomImageName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);

                        var path = Path.Combine(images.PhysicalPath, randomImageName);

                        using (var stream = new FileStream(path, FileMode.Create))
                            await imageFile.CopyToAsync(stream);

                        book.ImagePath = randomImageName;
                    }
                    else
                    {
                        // If imageFile is null, keep the existing ImagePath value.
                        var existingBook = await _bookAppService.GetAsync(new EntityDto(book.Id));
                        if (existingBook != null)
                        {
                            book.ImagePath = existingBook.ImagePath;
                        }
                    }

                    await _bookAppService.UpdateAsync(book);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Handle exceptions here, log them, and return an appropriate response.
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the book.");
                    // Optionally log the exception
                    // _logger.LogError(ex, "An error occurred while updating the book.");
                }
            }

            // If ModelState is not valid, return to the update page with validation errors.
            var categories = _categoryAppService.GetAllCategories();
            ViewBag.Categories = categories;
            return View("GetUpdatePage", book);
        }


    }
}
