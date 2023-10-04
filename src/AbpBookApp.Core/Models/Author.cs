using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Models
{
    public class Author : FullAuditedEntity<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<University> Universities { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
