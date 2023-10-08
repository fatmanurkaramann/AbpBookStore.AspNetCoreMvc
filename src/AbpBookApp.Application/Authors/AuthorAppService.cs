using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Extensions;
using AbpBookApp.Authors.Dto;
using AbpBookApp.Books.Dto;
using AbpBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Authors
{
    public class AuthorAppService : AsyncCrudAppService<Author, AuthorDto, int, PagedAuthorResultRequestDto, CreateAuthorDto, AuthorDto>
        ,IAuthorAppService
    {
        private readonly IAuthorManager _authorManager;
        private readonly IBookManager _bookManager;
        public AuthorAppService(IRepository<Author, int> repository, IAuthorManager authorManager, IBookManager bookManager) : base(repository)
        {
            _authorManager = authorManager;
            _bookManager = bookManager;
        }

        public List<AuthorDto> GetAllAuthors()
        {
            var authors = _authorManager.GetAll();
            var authorDtos = ObjectMapper.Map<List<AuthorDto>>(authors);
            return authorDtos;
        }
        public override async Task<AuthorDto> CreateAsync(CreateAuthorDto input)
        {

            var author = ObjectMapper.Map<Author>(input);
            var addedAuthor = await _authorManager.CreateAsync(author);
            await CurrentUnitOfWork.SaveChangesAsync();
            int authorId = addedAuthor.Id;
            var newAuthor = await _authorManager.GetById(authorId);
            var book = await _bookManager.GetByIdAsync(input.BookId);
            book.Author = newAuthor;
            await _bookManager.Update(book);
            return new AuthorDto { Id = authorId, Firstname = input.Firstname, Lastname = input.Lastname };
        }
        public override async Task<AuthorDto> UpdateAsync(AuthorDto input)
        {
            var author = await _authorManager.GetById(input.Id);
            ObjectMapper.Map(input, author);
            await _authorManager.UpdateAsync(author);
            return MapToEntityDto(author);
        }

        protected override IQueryable<Author> CreateFilteredQuery(PagedAuthorResultRequestDto input)
        {
            var query = Repository.GetAllIncluding(b => b.Addresses, a => a.Universities);

            if (!input.Keyword.IsNullOrWhiteSpace())
            {
                query = query.Where(x => x.Firstname.Contains(input.Keyword) || x.Lastname.Contains(input.Keyword));
            }

            return query;
        }

        public async Task DeleteAuthor(int Id)
        {
           await _authorManager.Delete(Id); ;
        }
    }
}
