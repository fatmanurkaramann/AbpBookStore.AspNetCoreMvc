using Abp.AutoMapper;
using AbpBookApp.Adresses.Dto;
using AbpBookApp.Models;
using AbpBookApp.Universities.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Authors.Dto
{
    [AutoMapFrom(typeof(Author))]
    public class CreateAuthorDto
    {
        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<CreateAddressDto> Addresses { get; set; }
        public ICollection<UniversityDto> Universities { get; set; }
        public int BookId { get; set; }
        public int AddressId { get; set; }
    }
}
