using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Models
{
    public interface IAuthorManager : IDomainService
    {
        List<Author> GetAll();
        Task<Author> GetById(int id);
        Task<Author> CreateAsync(Author author);
        Task<Author> UpdateAsync(Author author);
        Task Delete(int Id);
    }
}
