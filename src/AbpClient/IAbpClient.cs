using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bamboo.AbpClient.Model;
using Bamboo.AbpHelper;

namespace Bamboo.AbpClient
{
    public interface IAbpClient
    {
        void SetToken(string token);
        void ClearToken();
        Task<UserInfo> SignInAsync(AuthenticateModel user);
        Task SignOut();
        bool IsLogin();

        Task<T> GetJsonAsync<T>(string apiEndPoint);
        Task PostJsonAsync(string apiEndPoint, object content);
        Task<T> PostJsonAsync<T>(string apiEndPoint, object content);
        Task PutJsonAsync(string apiEndPoint, object content);
        Task<T> PutJsonAsync<T>(string apiEndPoint, object content);
        Task DeleteJsonAsync(string apiEndPoint);
        Task<T> DeleteJsonAsync<T>(string apiEndPoint);
        Task<T> SendJsonAsync<T>(HttpMethod method, string apiEndPoint, object content);
        
        #region AjaxHelper
        Task<T> Create<T>(string apiEndPoint, object obj);
       Task<List<T>> ReadAll<T>(string apiEndPoint);
        Task<T> Read<T>(string apiEndPoint);
        Task<T> Read<T>(string apiEndPoint, long id);
        Task<T> Update<T>(string apiEndPoint, object obj);
        Task<T> Update<T>(string apiEndPoint, long id, object obj);
        Task<T> Delete<T>(string apiEndPoint);
        Task<T> Delete<T>(string apiEndPoint, long id);
        Task<T> SendAsync<T>(HttpMethod method, string apiEndPoint, HttpContent content);
        #endregion

        Task<T> SendContentAsync<T>(HttpMethod method, string apiEndPoint, HttpContent content);
    }
}
