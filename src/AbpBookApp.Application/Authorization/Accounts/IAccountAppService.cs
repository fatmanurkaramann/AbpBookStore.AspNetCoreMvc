using System.Threading.Tasks;
using Abp.Application.Services;
using AbpBookApp.Authorization.Accounts.Dto;

namespace AbpBookApp.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
