using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Abp.Application.Services.Dto;

using AbpHelper.Roles.Dto;
using AbpHelper.Role;

namespace Bamboo.AbpClient.Services
{
    public partial class RoleClientAppService : AbpCoreAppService, IRoleAppService
    {
        public RoleClientAppService(IAbpClient apiClient)
            : base(apiClient)
        {

        }
        #region Role
        public async Task<RoleDto> Create(CreateRoleDto role)
        {
            try
            {
                var response = api.Create<RoleDto>("/api/services/app/Role/Create", role);
                await Task.CompletedTask;
                return response;
            }
            catch (Exception e)
            {
                throw;
            }
            return null;
        }
        public async Task<RoleDto> CreateAsync(CreateRoleDto role)
        {
            try
            {
                var response = await api.CreateAsync<RoleDto>("/api/services/app/Role/Create", role);
                await Task.CompletedTask;
                return response;
            }
            catch (Exception e)
            {
                throw;
            }
            return null;
        }

        public Task<ListResultDto<RoleListDto>> GetRoles()
        {
            throw new NotImplementedException();
        }
        public Task<ListResultDto<PermissionDto>> GetAllPermissions()
        {
            throw new NotImplementedException();
        }
        public Task<GetRoleForEditOutput> GetRoleForEdit(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResultDto<RoleDto>> GetAll(PagedRoleResultRequestDto input)
        {
            try
            {
                var response = api.ReadAll<PagedResultDto<RoleDto>>("/api/services/app/Role/GetAll");
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public async Task<List<RoleDto>> GetAllAsync()
        {
            try
            {
                var response = await api.ReadAllAsync<PagedResultDto<RoleDto>>("/api/services/app/Role/GetAll");
                return (List<RoleDto>)response.Items;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public async Task<RoleDto> Get(int id)
        {
            try
            {
                var response = api.Read<RoleDto>("/api/services/app/Role/Get", id);
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public async Task<RoleDto> GetAsync(long id)
        {
            try
            {
                var response = await api.ReadAsync<RoleDto>("/api/services/app/Role/Get", id);
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public async Task<RoleDto> Update(RoleDto role)
        {
            try
            {
                var response = api.Update<RoleDto>("/api/services/app/Role/Update", role);
                if (response != null)
                {
                    return response;
                }
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public async Task<RoleDto> UpdateAsync(RoleDto role)
        {
            try
            {
                var response = await api.UpdateAsync<RoleDto>("/api/services/app/Role/Update", role);
                if (response != null)
                {
                    return response;
                }
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var response = api.Delete<bool>($"/api/services/app/Role/Delete?Id={id}");
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return false;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            try
            {
                var response = await api.DeleteAsync<bool>($"/api/services/app/Role/Delete?Id={id}");
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return false;
        }
        #endregion
    }

}

