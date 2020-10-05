using System.Threading.Tasks;

using Abp.Application.Services;
using AbpHelper.Sessions.Dto;

namespace AbpHelper.Session
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
