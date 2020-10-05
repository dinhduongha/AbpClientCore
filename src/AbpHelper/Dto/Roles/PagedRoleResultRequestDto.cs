
using Abp.Application.Services.Dto;

namespace AbpHelper.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto // PagedResultDto<RoleDto>
    {
        public string Keyword { get; set; }
    }
}

