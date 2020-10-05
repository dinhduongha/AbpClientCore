using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

using AbpHelper.Roles.Dto;
using AbpHelper.Users.Dto;

namespace AbpHelper.User
{
    public interface IUserAppService : IApplicationService
    {
        Task<UserDto> Create(CreateUserDto input);
        Task<bool> Delete(long Id);
        Task<UserDto> Update(UserDto input);
        Task<ListResultDto<RoleListDto>> GetRoles();
    }
}
