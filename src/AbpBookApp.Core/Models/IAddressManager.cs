using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Models
{
    public interface IAddressManager:IDomainService
    {
        Task<Address> CreateAsync(Address address);
    }
}
