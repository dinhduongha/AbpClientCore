using System.Threading.Tasks;
using Abp.Application.Services;

using AbpHelper.Accounts.Dto;

namespace AbpHelper.Authorization
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);

    }
}
