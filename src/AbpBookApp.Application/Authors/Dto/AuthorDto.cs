using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AbpBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Authors.Dto
{
    [AutoMapFrom(typeof(Author))]
    public class AuthorDto : EntityDto<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
