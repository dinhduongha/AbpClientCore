using System;

using Abp.Application.Services.Dto;

namespace AbpHelper.Users.Dto
{
    public class PagedUserResultRequestDto : PagedResultDto<UserDto>
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
