using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using AbpBookApp.Books.Dto;
using AbpBookApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbpBookApp.Books
{
    public class BookAppService : AsyncCrudAppService<Book, BookDto, int, PagedBookResultRequestDto, CreateBookDto, BookDto>, IBookAppService
    {
        private readonly IBookManager _bookManager;
        public BookAppService(IRepository<Book, int> repository, IBookManager bookManager) : base(repository)
        {
            _bookManager = bookManager;
        }
        public override async Task<BookDto> CreateAsync(CreateBookDto input)
        {
            var book = new Book
            {
                Name = input.Name,
                ISBN = input.ISBN,
                AuthorId = input.AuthorId,
                Price = input.Price,
                PageCount = input.PageCount,
                ImagePath = input.ImagePath,
                PublishDate = input.PublishDate,
                Description = input.Description,
                CategoryId = input.CategoryId
            };
            await _bookManager.CreateAsync(book);
            return MapToEntityDto(book);
        }
        public async Task DeleteBookId(int Id)
        {
             await _bookManager.Delete(Id);
        }

        public List<BookDto> GetAllBooksAsync()
        {
            var books = _bookManager.GetAll();
            var bookDtos = ObjectMapper.Map<List<BookDto>>(books);
            return bookDtos;
        }

        public override async Task<BookDto> UpdateAsync(BookDto input)
        {
            var book = await _bookManager.GetByIdAsync(input.Id);
            ObjectMapper.Map(input, book);
            await _bookManager.Update(book);
            return MapToEntityDto(book);
        }

     
        protected override IQueryable<Book> CreateFilteredQuery(PagedBookResultRequestDto input)
        {
            var query = Repository.GetAllIncluding(x => x.Author, async => async.Category);

            if (!input.Keyword.IsNullOrWhiteSpace())
            {
                query = query.Where(x => x.Name.Contains(input.Keyword));
            }

            return query;
        }

       
    }
}
