using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Models
{
    public class AuthorManager : DomainService, IAuthorManager
    {
        private readonly IRepository<Author, int> _authorRepository;

        public AuthorManager(IRepository<Author, int> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<Author> GetAll()
        {
           return _authorRepository.GetAllList();
        }
        public async Task<Author> CreateAsync(Author author)
        {
            return await _authorRepository.InsertAsync(author);
        }
        public async Task<Author> GetById(int id)
        {
            return await _authorRepository.GetAsync(id);
        }
        public async Task<Author> UpdateAsync(Author author)
        {
            return await _authorRepository.UpdateAsync(author);
        }

        public async Task Delete(int Id)
        {
            var author =await _authorRepository.GetAsync(Id);
            await _authorRepository.DeleteAsync(author);
        }
    }
}
