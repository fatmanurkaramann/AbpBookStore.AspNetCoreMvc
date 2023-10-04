using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AbpBookApp.Models
{
    public class Address : FullAuditedEntity<int>
    {
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
