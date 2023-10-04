using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Models
{
    public interface IBookManager:IDomainService
    {
        List<Book> GetAll();
        Task<Book> CreateAsync(Book entity);
        Task<Book> Update(Book entity);
        Task<Book> GetByIdAsync(int id);
        Task Delete(int Id);
    }
}
