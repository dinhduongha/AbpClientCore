
using AbpHelper.Ajax.Dto;

namespace AbpHelper.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultDto<RoleDto>
    {
        public string Keyword { get; set; }
    }
}

