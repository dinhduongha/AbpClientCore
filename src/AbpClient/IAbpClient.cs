using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AbpHelper.Authenticate;
using AbpHelper.Accounts.Dto;
using AbpHelper.Users.Dto;
using AbpClient.Core.Model;

namespace Bamboo.AbpClient
{
    public interface IAbpClient
    {
        HttpClient HttpClient { get; }
        string BaseUrl { get; set; }
        #region Account
        void SetToken(string token);
        void ClearToken();
        CurrentUserInfo Login(AuthenticateModel user);
        Task<CurrentUserInfo> LoginAsync(AuthenticateModel user);
        Task Logout();
        bool IsLoggedIn();
        UserDto Register(RegisterInput model);
        Task<UserDto> RegisterAsync(RegisterInput model);
        #endregion

        // Return json object
        #region Json
        Task<T> GetJsonAsync<T>(string apiEndPoint);
        Task PostJsonAsync(string apiEndPoint, object content);
        Task<T> PostJsonAsync<T>(string apiEndPoint, object content);
        Task PutJsonAsync(string apiEndPoint, object content);
        Task<T> PutJsonAsync<T>(string apiEndPoint, object content);
        Task DeleteJsonAsync(string apiEndPoint);
        Task<T> DeleteJsonAsync<T>(string apiEndPoint);
        Task<T> SendJsonAsync<T>(HttpMethod method, string apiEndPoint, object content);
        Task<T> SendContentAsync<T>(HttpMethod method, string apiEndPoint, HttpContent content);

        #endregion

        byte[] SendBytes(HttpMethod method, string apiEndPoint, HttpContent content);
        Task<byte[]> SendBytesAsync(HttpMethod method, string apiEndPoint, HttpContent content);

        /// <summary>
        /// Data response in Ajax format
        /// </summary>        
        #region AjaxHelper
        T ReadAll<T>(string apiEndPoint);
        Task<T> ReadAllAsync<T>(string apiEndPoint);
        T Filter<T>(string apiEndPoint, object filter);
        Task<T> FilterAsync<T>(string apiEndPoint, object filter);
        T Create<T>(string apiEndPoint, object obj);
        Task<T> CreateAsync<T>(string apiEndPoint, object obj);        
        T Read<T>(string apiEndPoint);
        Task<T> ReadAsync<T>(string apiEndPoint);
        T Read<T>(string apiEndPoint, long id);
        Task<T> ReadAsync<T>(string apiEndPoint, long id);
        T Update<T>(string apiEndPoint, object obj);
        Task<T> UpdateAsync<T>(string apiEndPoint, object obj);
        T Delete<T>(string apiEndPoint);
        Task<T> DeleteAsync<T>(string apiEndPoint);
        T Delete<T>(string apiEndPoint, long id);
        Task<T> DeleteAsync<T>(string apiEndPoint, long id);
        T Send<T>(HttpMethod method, string apiEndPoint, HttpContent content);
        Task<T> SendAsync<T>(HttpMethod method, string apiEndPoint, HttpContent content);
        #endregion
    }
}
