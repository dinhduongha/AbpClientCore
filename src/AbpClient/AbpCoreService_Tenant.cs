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

        #region Tenant
        public TenantDto TenantCreate(CreateTenantDto tenant)
        {
            try
            {
                var response = api.Create<TenantDto>("/api/services/app/Tenant/Create", tenant);
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public async Task<TenantDto> TenantCreateAsync(CreateTenantDto tenant)
        {
            try
            {
                var response = await api.CreateAsync<TenantDto>("/api/services/app/Tenant/Create", tenant);
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public List<TenantDto> TenantGetAll()
        {
            try
            {
                var response = api.ReadAll<PagedResultDto<TenantDto>>("/api/services/app/Tenant/GetAll");
                return (List<TenantDto>)response.Items;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public async Task<List<TenantDto>> TenantGetAllAsync()
        {
            try
            {
                var response = await api.ReadAllAsync<PagedResultDto<TenantDto>>("/api/services/app/Tenant/GetAll");
                return (List<TenantDto>)response.Items;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public TenantDto TenantGet(long id)
        {
            try
            {
                var response = api.Read<TenantDto>("/api/services/app/Tenant/Get", id);
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public async Task<TenantDto> TenantGetAsync(long id)
        {
            try
            {
                var response = await api.ReadAsync<TenantDto>("/api/services/app/Tenant/Get", id);
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return null;
        }
        public TenantDto TenantUpdate(TenantDto tenant)
        {
            try
            {
                var response = api.Update<TenantDto>("/api/services/app/Tenant/Update", tenant);
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
        public async Task<TenantDto> TenantUpdateAsync(TenantDto tenant)
        {
            try
            {
                var response = await api.UpdateAsync<TenantDto>("/api/services/app/Tenant/Update", tenant);
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
        public bool TenantDelete(long id)
        {
            try
            {
                var response = api.Delete<bool>($"/api/services/app/Tenant/Delete?Id={id}");
                return response;
            }
            catch (Exception e)
            {
				throw;
            }
            return false;
        }
        public async Task<bool> TenantDeleteAsync(long id)
        {
            try
            {
                var response = await api.DeleteAsync<bool>($"/api/services/app/Tenant/Delete?Id={id}");
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

