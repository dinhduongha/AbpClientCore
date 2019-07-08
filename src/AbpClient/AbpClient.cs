using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Bamboo.AbpClient.Model;
using Bamboo.AbpHelper;
using Bamboo.AbpHelper.Ajax;
using Bamboo.AbpSessions.Dto;
using Bamboo.AbpHelper.Dto;
using Bamboo.AbpHelper.Ajax.Dto;

namespace Bamboo.AbpClient
{
    public class AbpClient : IAbpClient
    {
        public string BaseUrl { get; set; } = "http://localhost:30304";
        protected readonly HttpClient _httpClient;
        private string token = "";
        private UserInfo UserInfo { get; set; } = null;
        public AbpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void SetToken(string token)
        {
            //_httpClient.DefaultRequestHeaders.Clear();
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            this.token = token;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.token);
        }

        public void ClearToken()
        {
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<UserInfo> SignInAsync(AuthenticateModel model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _httpClient.PostAsync($"{BaseUrl}/api/TokenAuth/Authenticate", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var jsonObject = JsonConvert.DeserializeObject<AjaxResponse<AuthenticateResultModel>>(data);
                    if (jsonObject != null && jsonObject.Success)
                    {
                        var loginInfo = jsonObject.Result;
                        if (loginInfo != null)
                        {
                            UserInfo = new UserInfo()
                            {
                                token = loginInfo.AccessToken,
                                encryted_token = loginInfo.EncryptedAccessToken,
                                id = loginInfo.UserId,
                                loginResult = loginInfo,
                            };
                            SetToken(loginInfo.AccessToken);
                            await GetUserInfo();

                            return UserInfo;
                        }
                    }
                }
                else
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"SignInAsync Exception: {e.Message}");
            }
            return null;
        }

        public async Task SignOut()
        {
            ClearToken();
            UserInfo = null;
            await Task.CompletedTask;
        }

        public bool IsLogin()
        {
            return UserInfo != null;
        }

        public async Task<CurrentLoginInformations> GetUserInfo()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/api/services/app/Session/GetCurrentLoginInformations");
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var currentInfo = JsonConvert.DeserializeObject<AjaxResponse<CurrentLoginInformations>>(data);
                    if (currentInfo != null && currentInfo.Success)
                    {
                        CurrentLoginInformations info = currentInfo.Result;
                        if (info != null)
                        {
                            var jUser = info.User;
                            if (jUser != null)
                            {
                                UserInfo.email = jUser.EmailAddress;
                                UserInfo.username = jUser.UserName;
                            }
                        }
                        UserInfo.info = info;
                        return info;
                    }
                }
            }
            catch
            {

            }
            await Task.CompletedTask;
            return default(CurrentLoginInformations);
        }
        #region JsonAsync
        /// <summary>
        /// Methods for working with JSON APIs.
        /// </summary>

        /// <summary>
        /// Sends a GET request to the specified URI, and parses the JSON response body
        /// to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public async Task<T> GetJsonAsync<T>(string apiEndPoint)
        {
            var responseJson = await _httpClient.GetStringAsync($"{BaseUrl}{apiEndPoint}");
            return JsonConvert.DeserializeObject<T>(responseJson);
        }

        /// <summary>
        /// Sends a POST request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public Task PostJsonAsync(string apiEndPoint, object content)
            => SendJsonAsync(HttpMethod.Post, apiEndPoint, content);

        /// <summary>
        /// Sends a POST request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public Task<T> PostJsonAsync<T>(string apiEndPoint, object content)
            => SendJsonAsync<T>(HttpMethod.Post, apiEndPoint, content);

        public async Task<T> PostJsonAsync<T>(string apiEndPoint, long id, object obj)
        {
            var json = "";
            if (obj != null)
                json = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{BaseUrl}{apiEndPoint}/{id}", stringContent);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }
            return default(T);
        }

        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format.
        /// </summary>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        public Task PutJsonAsync(string apiEndPoint, object content)
            => SendJsonAsync(HttpMethod.Put, apiEndPoint, content);

        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public Task<T> PutJsonAsync<T>(string apiEndPoint, object content)
            => SendJsonAsync<T>(HttpMethod.Put, apiEndPoint, content);

        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format.
        /// </summary>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        public async Task DeleteJsonAsync(string apiEndPoint)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}{apiEndPoint}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
            }
        }
        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public async Task<T> DeleteJsonAsync<T>(string apiEndPoint)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}{apiEndPoint}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }
            return default(T);

        }
        /// <summary>
        /// Sends an HTTP request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format.
        /// </summary>
        /// <param name="method">The HTTP method.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        public Task SendJsonAsync(HttpMethod method, string apiEndPoint, object content)
            => SendJsonAsync<IgnoreResponse>(method, apiEndPoint, content);

        /// <summary>
        /// Sends an HTTP request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="method">The HTTP method.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public async Task<T> SendJsonAsync<T>(HttpMethod method, string apiEndPoint, object content)
        {
            var requestJson = JsonConvert.SerializeObject(content);
            var response = await _httpClient.SendAsync(new HttpRequestMessage(method, $"{BaseUrl}{apiEndPoint}")
            {
                Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
            });

            // Make sure the call was successful before we
            // attempt to process the response content
            //response.EnsureSuccessStatusCode();

            if (typeof(T) == typeof(IgnoreResponse))
            {
                return default(T);
            }
            else
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
        }
        //public async Task<T> SendJsonAsync<T>(HttpMethod method, string requestUri, object content)
        //{
        //    var requestJson = JsonConvert.SerializeObject(content);
        //    var response = await _httpClient.SendAsync(new HttpRequestMessage(method, requestUri)
        //    {
        //        Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        //    });

        //    // Make sure the call was successful before we
        //    // attempt to process the response content
        //    response.EnsureSuccessStatusCode();

        //    if (typeof(T) == typeof(IgnoreResponse))
        //    {
        //        return default(T);
        //    }
        //    else
        //    {
        //        var responseJson = await response.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<T>(responseJson);
        //    }
        //}

        #endregion

        #region AjaxHelper
        /// <summary>
        /// Create object, want server return AjaxResponse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiEndPoint"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<T> Create<T>(string apiEndPoint, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");           
            var response = await _httpClient.PostAsync($"{BaseUrl}{apiEndPoint}", stringContent);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();                    
                var jsonObject = JsonConvert.DeserializeObject<AjaxResponse<T>>(data);
                return jsonObject.Result;
            }
            else
            {
                var data = response.Content.ReadAsStringAsync().Result;
            }            
            return default(T);
        }

        public async Task<List<T>> ReadAll<T>(string apiEndPoint) 
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}{apiEndPoint}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return (List<T>)JsonConvert.DeserializeObject<AjaxResponse<PagedResultDto<T>>>(data).Result.Items;                
            }
            return default(List<T>);
        }

        public async Task<T> Read<T>(string apiEndPoint)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}{apiEndPoint}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;                
            }
            return default(T);
        }

        public async Task<T> Read<T>(string apiEndPoint, long id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}{apiEndPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;                
            }
            return default(T);
        }

        public async Task<T> Update<T>(string apiEndPoint, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{BaseUrl}{apiEndPoint}", stringContent);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;                
            }
            return default(T);
        }

        public async Task<T> Update<T>(string apiEndPoint, long id, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{BaseUrl}{apiEndPoint}/{id}", stringContent);            
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;
            }
            return default(T);
        }

        public async Task<T> Delete<T>(string apiEndPoint)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}{apiEndPoint}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;
            }
            return default(T);
        }

        public async Task<T> Delete<T>(string apiEndPoint, long id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}{apiEndPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;
            }
            return default(T);
        }

        public async Task<T> SendAsync<T>(HttpMethod method, string apiEndPoint, HttpContent content)
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(method, $"{BaseUrl}{apiEndPoint}")
            {
                Content = content
            });
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;
            }
            return default(T);
        }

        #endregion


        public async Task<T> PostBinaryAsync<T>(string apiEndPoint, HttpContent content)
        {
            var response = await _httpClient.PostAsync($"{BaseUrl}/{apiEndPoint}", content);
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            }
            return default(T);
        }

        public async Task<T> SendContentAsync<T>(HttpMethod method, string apiEndPoint, HttpContent content)
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(method, $"{BaseUrl}{apiEndPoint}")
            {
                Content = content
            });
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);                
            }
            return default(T);
        }
    }
    public class IgnoreResponse { }
}
