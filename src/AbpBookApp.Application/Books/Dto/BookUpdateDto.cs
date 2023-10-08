using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using AbpBookApp.Authors.Dto;
using AbpBookApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Books.Dto
{
    [AutoMapFrom(typeof(Book))]
    public class BookUpdateDto : EntityDto<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int PageCount { get; set; }
        public string ImagePath { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public AuthorDto Author { get; set; }

        public int CategoryId { get; set; }
    }
}
