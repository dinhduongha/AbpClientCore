using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;

using AbpHelper.Roles.Dto;

namespace AbpHelper.Role
{
    public interface IRoleAppService : IApplicationService
    {
        Task<RoleDto> Create(CreateRoleDto input);
        Task<ListResultDto<RoleListDto>> GetRoles();
        Task<RoleDto> Update(RoleDto input);
        Task<bool> Delete(int Id);
        Task<ListResultDto<PermissionDto>> GetAllPermissions();
        Task<GetRoleForEditOutput> GetRoleForEdit(int Id);

        Task<RoleDto> Get(int Id);
        Task<PagedResultDto<RoleDto>> GetAll(PagedRoleResultRequestDto input);

    }
}
