using System.Threading.Tasks;
using Abp.Application.Services;
using AbpBookApp.Sessions.Dto;

namespace AbpBookApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
