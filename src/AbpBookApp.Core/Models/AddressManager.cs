using Abp.Domain.Repositories;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpBookApp.Models
{
    public class AddressManager : DomainService, IAddressManager
    {
        private readonly IRepository<Address, int> _addressRepository;

        public AddressManager(IRepository<Address, int> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Address> CreateAsync(Address address)
        {
            return await _addressRepository.InsertAsync(address);
        }
    }
}
