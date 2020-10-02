using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AbpHelper;
using AbpHelper.Ajax;
using AbpHelper.Ajax.Dto;
using AbpHelper.Roles.Dto;
using AbpHelper.Users.Dto;
using AbpHelper.MultiTenancy.Dto;

namespace Bamboo.AbpClient
{
    public partial class AbpCoreService
    {
        #region Role
        public RoleDto RoleCreate(CreateRoleDto role)
        {
            try
            {
                var response = api.Create<RoleDto>("/api/services/app/Role/Create", role);
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public async Task<RoleDto> RoleCreateAsync(CreateRoleDto role)
        {
            try
            {
                var response = await api.CreateAsync<RoleDto>("/api/services/app/Role/Create", role);
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public List<RoleDto> RoleGetAll()
        {
            try
            {
                var response = api.ReadAll<PagedResultDto<RoleDto>>("/api/services/app/Role/GetAll");
                return (List<RoleDto>)response.Items;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public async Task<List<RoleDto>> RoleGetAllAsync()
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
        public RoleDto RoleGet(long id)
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
        public async Task<RoleDto> RoleGetAsync(long id)
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
        public RoleDto RoleUpdate(RoleDto role)
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
        public async Task<RoleDto> RoleUpdateAsync(RoleDto role)
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

        public bool RoleDelete(long id)
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
        public async Task<bool> RoleDeleteAsync(long id)
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

