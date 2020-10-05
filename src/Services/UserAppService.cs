using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Abp.Application.Services.Dto;

using AbpHelper;
using AbpHelper.Roles.Dto;
using AbpHelper.Users.Dto;
using AbpHelper.MultiTenancy.Dto;
using AbpHelper.User;

namespace Bamboo.AbpClient.Services
{
    public partial class UserClientAppService: AbpCoreAppService, IUserAppService
    {

        public UserClientAppService(IAbpClient apiClient)
            :base(apiClient)
        {

        }
        #region User

        public async Task<UserDto> Create(CreateUserDto newUser)
        {
            try
            {
                var response = api.Create<UserDto>("/api/services/app/User/Create", newUser);
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
        public async Task<UserDto> UserCreateAsync(CreateUserDto newUser)
        {
            try
            {
                var response = await api.CreateAsync<UserDto>("/api/services/app/User/Create", newUser);
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

        public List<UserDto> UserGetAll()
        {
            try
            {
                var response = api.ReadAll<PagedResultDto<UserDto>>("/api/services/app/User/GetAll");
                return (List<UserDto>)response.Items;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public async Task<List<UserDto>> UserGetAllAsync()
        {
            try
            {
                var response = await api.ReadAllAsync<PagedResultDto<UserDto>>("/api/services/app/User/GetAll");
                return (List<UserDto>)response.Items;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public UserDto UserGet(long id)
        {
            try
            {
                var user = api.Read<UserDto>("/api/services/app/User/Get", id);
                return user;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public async Task<UserDto> UserGetAsync(long id)
        {
            try
            {
                var user = await api.ReadAsync<UserDto>("/api/services/app/User/Get", id);
                return user;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public async Task<UserDto> Update(UserDto user)
        {
            try
            {
                var response = api.Update<UserDto>("/api/services/app/User/Update", user);
                if (response != null)
                {
                    return response;
                }
            }
            catch (Exception e)
            {
				throw;
            }
            await Task.CompletedTask;
            return null;
        }
        public async Task<UserDto> UserUpdateAsync(UserDto user)
        {
            try
            {
                var response = await api.UpdateAsync<UserDto>("/api/services/app/User/Update", user);
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
        public async Task<bool> Delete(long id)
        {
            try
            {
                var response = api.Delete<bool>($"/api/services/app/User/Delete?Id={id}");
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return false;
        }
        public async Task<bool> UserDeleteAsync(long id)
        {
            try
            {
                var response = await api.DeleteAsync<bool>($"/api/services/app/User/Delete?Id={id}");
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return false;
        }

        public async Task<ListResultDto<RoleListDto>> GetRoles()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
        #endregion
    }
}

