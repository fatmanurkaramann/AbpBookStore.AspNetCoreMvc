using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Models
{
    public class University:FullAuditedEntity<int>
    {
        public string UniversityName { get; set; }
        public ICollection<Author> Authors { get; set; }
    }
}
