
using Abp.Application.Services.Dto;

namespace AbpHelper.MultiTenancy.Dto
{
    public class PagedTenantResultRequestDto : PagedResultDto<TenantDto>
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}

