using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Models
{
    public class BookManager : DomainService, IBookManager
    {
        private readonly IRepository<Book,int> _bookRepository;

        public BookManager(IRepository<Book, int> bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public async Task<Book> CreateAsync(Book entity)
        {
            return await _bookRepository.InsertAsync(entity);
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAllIncluding(a=>a.Author,b=>b.Category).ToList();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookRepository.GetAsync(id);
        }

        public async Task<Book> Update(Book entity)
        {
            return await _bookRepository.UpdateAsync(entity);
        }
    }
}
