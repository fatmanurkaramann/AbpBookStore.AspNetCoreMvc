using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Models
{
    public class Category : FullAuditedEntity<int>
    {
        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
