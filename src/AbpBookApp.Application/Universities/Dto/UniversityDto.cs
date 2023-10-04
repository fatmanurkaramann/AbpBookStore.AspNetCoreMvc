using Abp.AutoMapper;
using AbpBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Universities.Dto
{
    [AutoMapFrom(typeof(University))]
    public class UniversityDto
    {
        public string UniversityName { get; set; }
    }
}
