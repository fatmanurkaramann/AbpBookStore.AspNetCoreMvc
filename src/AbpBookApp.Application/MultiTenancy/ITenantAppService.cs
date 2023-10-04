using Abp.Application.Services;
using AbpBookApp.MultiTenancy.Dto;

namespace AbpBookApp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

