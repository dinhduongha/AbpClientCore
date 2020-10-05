using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Abp.Dependency;

using AbpHelper;
using AbpHelper.Roles.Dto;
using AbpHelper.Users.Dto;
using AbpHelper.MultiTenancy.Dto;

namespace Bamboo.AbpClient.Services
{
    public partial class AbpCoreAppService: ITransientDependency
    {
        public readonly IAbpClient api;
        public AbpCoreAppService(IAbpClient apiClient)
        {
            api = apiClient;
        }
        public IAbpClient AbpClient
        {
            get { return api; }
        }
        public bool IsLoggedIn { get { return api.IsLoggedIn(); } }

        #region AjaxHelper
        public T AjaxCreate<T>(string apiEndPoint, object obj)
        {
            return api.Create<T>(apiEndPoint, obj);
        }
        public async Task<T> AjaxCreateAsync<T>(string apiEndPoint, object obj)
        {
            return await api.CreateAsync<T>(apiEndPoint, obj);
        }
        public T AjaxReadAll<T>(string apiEndPoint)
        {
            return api.ReadAll<T>(apiEndPoint);
        }
        public async Task<T> AjaxReadAllAsync<T>(string apiEndPoint)
        {
            return await api.ReadAllAsync<T>(apiEndPoint);
        }
        public T AjaxPostFilter<T>(string apiEndPoint, object filter)
        {
            return api.Filter<T>(apiEndPoint, filter);
        }
        public async Task<T> AjaxPostFilterAsync<T>(string apiEndPoint, object filter)
        {
            return await api.FilterAsync<T>(apiEndPoint, filter);
        }

        public T AjaxRead<T>(string apiEndPoint)
        {
            return api.Read<T>(apiEndPoint);
        }
        public async Task<T> AjaxReadAsync<T>(string apiEndPoint)
        {
            return await api.ReadAsync<T>(apiEndPoint);
        }
        public T AjaxRead<T>(string apiEndPoint, long id)
        {
            return api.Read<T>(apiEndPoint, id);
        }
        public async Task<T> AjaxReadAsync<T>(string apiEndPoint, long id)
        {
            return await api.ReadAsync<T>(apiEndPoint, id);
        }
        public T AjaxUpdate<T>(string apiEndPoint, object obj)
        {
            return api.Update<T>(apiEndPoint, obj);
        }
        public async Task<T> AjaxUpdateAsync<T>(string apiEndPoint, object obj)
        {
            return await api.UpdateAsync<T>(apiEndPoint, obj);
        }
        public T AjaxDelete<T>(string apiEndPoint)
        {
            return api.Delete<T>(apiEndPoint);
        }
        public async Task<T> AjaxDeleteAsync<T>(string apiEndPoint)
        {
            return await api.DeleteAsync<T>(apiEndPoint);
        }
        public T AjaxDelete<T>(string apiEndPoint, long id)
        {
            return api.Delete<T>(apiEndPoint, id);
        }
        public async Task<T> AjaxDeleteAsync<T>(string apiEndPoint, long id)
        {
            return await api.DeleteAsync<T>(apiEndPoint, id);
        }
        #endregion


    }    
}

