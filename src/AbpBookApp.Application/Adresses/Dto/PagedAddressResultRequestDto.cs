using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Adresses.Dto
{
    public class PagedAddressResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
