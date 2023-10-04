using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Models
{
    public class CategoryManager : DomainService, ICategoryManager
    {
        private readonly IRepository<Category, int> _repository;

        public CategoryManager(IRepository<Category, int> repository)
        {
            _repository = repository;
        }

        public List<Category> GetAll()
        {
           return _repository.GetAllList();
        }
    }
}
