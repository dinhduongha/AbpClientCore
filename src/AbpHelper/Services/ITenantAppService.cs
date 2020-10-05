using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

using AbpHelper.MultiTenancy.Dto;

namespace AbpHelper.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        Task<TenantDto> Create(CreateTenantDto input);
    }
}
