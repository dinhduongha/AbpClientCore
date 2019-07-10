using System;

using AbpHelper.Ajax.Dto;

namespace AbpHelper.Users.Dto
{
    //custom PagedResultRequestDto
    public class PagedUserResultRequestDto : PagedResultDto<UserDto>
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}
