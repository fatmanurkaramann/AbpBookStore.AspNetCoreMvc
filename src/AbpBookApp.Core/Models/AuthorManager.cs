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
    }
}
