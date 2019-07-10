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
    public class AbpCoreService
    {
        public readonly IAbpClient api;
        public AbpCoreService(IAbpClient apiClient)
        {
            api = apiClient;
        }
        #region AjaxHelper
        protected async Task<T> Create<T>(string apiEndPoint, object obj)
        {
            return await api.Create<T>(apiEndPoint, obj);
        }
        protected async Task<List<T>> ReadAll<T>(string apiEndPoint)
        {
            return await api.ReadAll<T>(apiEndPoint);
        }
        protected async Task<T> Read<T>(string apiEndPoint)
        {
            return await api.Read<T>(apiEndPoint);
        }
        protected async Task<T> Read<T>(string apiEndPoint, long id)
        {
            return await api.Read<T>(apiEndPoint, id);
        }
        protected async Task<T> Update<T>(string apiEndPoint, object obj)
        {
            return await api.Update<T>(apiEndPoint, obj);
        }
        protected async Task<T> Update<T>(string apiEndPoint, long id, object obj)
        {
            return await api.Update<T>(apiEndPoint, id, obj);
        }
        protected async Task<T> Delete<T>(string apiEndPoint)
        {
            return await api.Delete<T>(apiEndPoint);
        }
        protected async Task<T> Delete<T>(string apiEndPoint, long id)
        {
            return await api.Delete<T>(apiEndPoint, id);
        }
        #endregion

        #region Role
        public async Task<RoleDto> RoleCreateAsync(CreateRoleDto role)
        {
            try
            { 
                var response = await api.Create<RoleDto>("/api/services/app/Role/Create", role);
                return response;
            }
            catch
            {

            }
            return null;
        }
        public async Task<List<RoleDto>> RoleGetAllAsync() 
        {
            try
            {
                var response = await api.Read<PagedResultDto<RoleDto>>("/api/services/app/Role/GetAll");
                return (List<RoleDto>)response.Items;
            }
            catch
            {
            }
            return null;
        }
        public async Task<RoleDto> RoleGetAsync(long id)
        {
            try
            {
                var response = await api.Read<RoleDto>("/api/services/app/Role/Get", id);
                return response;
            }
            catch
            {
            }
            return null;
        }
        public async Task<RoleDto> RoleUpdateAsync(RoleDto role)
        {
            try
            {
                var response = await api.Update<RoleDto>("/api/services/app/Role/Update", role);
                if (response != null)
                {
                    return response;
                }
            }
            catch
            {
            }
            return null;
        }

        public async Task<bool> RoleDeleteAsync(long id)
        {
            try
            {
                var response = await api.Delete<bool>($"/api/services/app/Role/Delete?Id={id}");
                return response;
            }
            catch
            { }
            return false;
        }
        #endregion

        #region Tenant
        public async Task<TenantDto> TenantCreateAsync(CreateTenantDto tenant)
        {
            try
            {
                var response = await api.Create<TenantDto>("/api/services/app/Tenant/Create", tenant);
                return response;
            }
            catch
            {
            }
            return null;
        }
        public async Task<List<TenantDto>> TenantGetAllAsync()
        {
            try
            {
                var response = await api.Read<PagedResultDto<TenantDto>>("/api/services/app/Tenant/GetAll");
                return (List<TenantDto>)response.Items;
            }
            catch
            {
            }
            return null;
        }
        public async Task<TenantDto> TenantGetAsync(long id)
        {
            try
            { 
                var response = await api.Read<TenantDto>("/api/services/app/Tenant/Get", id);
                return response;
            }
            catch
            {
            }
            return null;
        }
        public async Task<TenantDto> TenantUpdateAsync(TenantDto tenant)
        {
            try
            {
                var response = await api.Update<TenantDto>("/api/services/app/Tenant/Update", tenant);
                if (response != null)
                {
                    return response;
                }
            }
            catch
            {
            }
            return null;
        }
        public async Task<bool> TenantDeleteAsync(long id)
        {
            try
            {
                var response = await api.Delete<bool>($"/api/services/app/Tenant/Delete?Id={id}");
                return response;
            }
            catch
            { }
            return false;
        }
        #endregion
        #region User

        public async Task<UserDto> UserCreateAsync(CreateUserDto newUser)
        {            
            try
            {
                var response = await api.Create<UserDto>("/api/services/app/User/Create", newUser);
                if (response != null)
                {
                    return response;
                }
            }
            catch
            {
            }
            return null;
        }        
        public async Task<List<UserDto>> UserGetAllAsync()
        {
            try
            {
                var response = await api.Read<PagedResultDto<UserDto>>("/api/services/app/User/GetAll");
                return (List<UserDto>)response.Items;
            }
            catch (Exception e)
            {
                var str = e.Message;
            }
            return null;
        }
        public async Task<UserDto> UserGetAsync(long id)
        {
            try
            {
                var user = await api.Read<UserDto>("/api/services/app/User/Get", id);
                return user;
            }
            catch
            {
            }
            return null;
        }
        public async Task<UserDto> UserUpdateAsync(UserDto user)
        {
            try
            {
                var response = await api.Update<UserDto>("/api/services/app/User/Update", user);
                if (response != null)
                {
                    return response;
                }
            }
            catch
            {
            }
            return null;
        }        
        public async Task<bool> UserDeleteAsync(long id)
        {
            try
            {
                var response = await api.Delete<bool>($"/api/services/app/User/Delete?Id={id}");
                return response;
            }
            catch
            { }
            return false;
        }
        #endregion
    }    
}

