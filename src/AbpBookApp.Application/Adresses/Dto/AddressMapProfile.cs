using AbpBookApp.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Adresses.Dto
{
    public class AddressMapProfile : Profile
    {
        public AddressMapProfile()
        {
            CreateMap<CreateAddressDto, Address>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();

        }
    }
}
