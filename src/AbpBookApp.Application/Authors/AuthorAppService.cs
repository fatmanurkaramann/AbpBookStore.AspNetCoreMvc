using Abp.Application.Services;
using Abp.Domain.Repositories;
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
        public AuthorAppService(IRepository<Author, int> repository, IAuthorManager authorManager) : base(repository)
        {
            _authorManager = authorManager;
        }

        public List<AuthorDto> GetAllAuthors()
        {
            var authors = _authorManager.GetAll();
            var authorDtos = ObjectMapper.Map<List<AuthorDto>>(authors);
            return authorDtos;
        }
    }
}
