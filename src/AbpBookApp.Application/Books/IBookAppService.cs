using Abp.Application.Services;
using AbpBookApp.Books.Dto;
using AbpBookApp.Models;
using AbpBookApp.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Books
{
    public interface IBookAppService : IAsyncCrudAppService<BookDto, int, PagedBookResultRequestDto, CreateBookDto, BookDto>
    {
        List<BookDto> GetAllBooksAsync();
    }
}
