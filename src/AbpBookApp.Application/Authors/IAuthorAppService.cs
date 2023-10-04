using Abp.Application.Services;
using AbpBookApp.Authors.Dto;
using AbpBookApp.Books.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Authors
{
    public interface IAuthorAppService : IAsyncCrudAppService<AuthorDto, int, PagedAuthorResultRequestDto, CreateAuthorDto, AuthorDto>
    {
        List<AuthorDto> GetAllAuthors();
    }
}
