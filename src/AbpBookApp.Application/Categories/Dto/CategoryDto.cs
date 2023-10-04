using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AbpBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Categories.Dto
{
    [AutoMapFrom(typeof(Category))]
    public class CategoryDto : EntityDto<int>
    {
        public string CategoryName { get; set; }
    }
}
