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

        #region User

        public UserDto UserCreate(CreateUserDto newUser)
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
        public UserDto UserUpdate(UserDto user)
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
        public bool UserDelete(long id)
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
        #endregion
    }
}

