using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AbpHelper.Ajax;
using AbpHelper.Ajax.Dto;
using AbpHelper.Authenticate;
using AbpHelper.Sessions.Dto;
using AbpHelper.Users.Dto;
using AbpHelper.Accounts.Dto;

using AbpClient.Core.Model;
using AbpHelper.Roles.Dto;

namespace Bamboo.AbpClient
{
    public class AbpClientCore : IAbpClient
    {
        public string BaseUrl { get; set; } = "http://localhost:21021";
        protected readonly HttpClient _httpClient ;
        private string token = "";
        private CurrentUserInfo currentUserInfo { get; set; } = null;
        public AbpClientCore(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public HttpClient HttpClient { get { return _httpClient; } }
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

        public CurrentUserInfo SignIn(AuthenticateModel model)
        {
            try
            {
                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = _httpClient.PostAsync($"{BaseUrl}/api/TokenAuth/Authenticate", stringContent).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var jsonObject = JsonConvert.DeserializeObject<AjaxResponse<AuthenticateResultModel>>(data);
                    if (jsonObject != null && jsonObject.Success)
                    {
                        var loginInfo = jsonObject.Result;
                        if (loginInfo != null)
                        {
                            currentUserInfo = new CurrentUserInfo()
                            {
                                Token = loginInfo.AccessToken,
                                Encryted_token = loginInfo.EncryptedAccessToken,
                                Id = loginInfo.UserId,
                                LoginResult = loginInfo,
                            };
                            SetToken(loginInfo.AccessToken);
                            GetUserInfo();

                            return currentUserInfo;
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
				throw;
            }
            return null;
        }
        public async Task<CurrentUserInfo> SignInAsync(AuthenticateModel model)
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
                            currentUserInfo = new CurrentUserInfo()
                            {
                                Token = loginInfo.AccessToken,
                                Encryted_token = loginInfo.EncryptedAccessToken,
                                Id = loginInfo.UserId,
                                LoginResult = loginInfo,
                            };
                            SetToken(loginInfo.AccessToken);
                            await GetUserInfoAsync();

                            return currentUserInfo;
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
				throw;
            }
            return null;
        }

        public CurrentUserInfo Login(AuthenticateModel model)
        {
            return SignIn(model);
        }
        public async Task<CurrentUserInfo> LoginAsync(AuthenticateModel model)
        {
            return await SignInAsync(model);
        }
        public async Task Logout()
        {
            ClearToken();
            currentUserInfo = null;
            await Task.CompletedTask;
        }

        public bool IsLoggedIn()
        {
            return currentUserInfo != null;
        }

        public UserDto Register(RegisterInput model)
        {
            return null;
        }
        public async Task<UserDto> RegisterAsync(RegisterInput model)
        {
            await Task.CompletedTask;
            return null;
        }

        public CurrentUserInfo GetUserInfo()
        {
            try
            {
                var response = _httpClient.GetAsync($"{BaseUrl}/api/services/app/Session/GetCurrentLoginInformations").GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var currentInfo = JsonConvert.DeserializeObject<AjaxResponse<CurrentLoginInformations>>(data);
                    if (currentInfo != null && currentInfo.Success)
                    {
                        CurrentLoginInformations info = currentInfo.Result;
                        if (info != null)
                        {
                            var jUser = info.User;
                            if (jUser != null)
                            {
                                currentUserInfo.Email = jUser.EmailAddress;
                                currentUserInfo.Username = jUser.UserName;
                                currentUserInfo.Surname = jUser.Surname;
                                currentUserInfo.Name = jUser.Name;
                                //currentUserInfo.Id = jUser.Id;
                            }
                        }
                        currentUserInfo.Info = info;
                    }
                }
                var roleResponse = _httpClient.GetAsync($"{BaseUrl}/api/services/app/User/GetRoles").GetAwaiter().GetResult();
                if (roleResponse.IsSuccessStatusCode)
                {
                    string data = roleResponse.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    var roleInfo = JsonConvert.DeserializeObject<AjaxResponse<ListResultDto<RoleDto>>>(data);
                    if (roleInfo != null && roleInfo.Success)
                    {
                        var roles = roleInfo.Result;
                        currentUserInfo.Roles = new List<RoleDto>();
                        currentUserInfo.Roles.AddRange(roles.Items);
                    }
                }
            }
            catch (Exception e)
            {
				throw;
            }
            return currentUserInfo;
        }
        public async Task<CurrentUserInfo> GetUserInfoAsync()
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
                                currentUserInfo.Email = jUser.EmailAddress;
                                currentUserInfo.Username = jUser.UserName;
                            }
                        }
                        currentUserInfo.Info = info;                        
                    }
                }
                //var roleResponse = await _httpClient.GetAsync($"{BaseUrl}/api/services/app/User/GetRoles");
                //if (roleResponse.IsSuccessStatusCode)
                //{
                //    string data = await roleResponse.Content.ReadAsStringAsync();
                //    //var roleInfo = JsonConvert.DeserializeObject<AjaxResponse<ListResultDto<RoleDto>>>(data);
                //    //if (roleInfo != null && roleInfo.Success)
                //    //{
                //    //    var roles = roleInfo.Result;
                //    //    currentUserInfo.Roles = new List<RoleDto>();
                //    //    currentUserInfo.Roles.AddRange(roles.Items);
                //    //}
                //}
            }
            catch (Exception e)
            {
				throw;
            }
            await Task.CompletedTask;
            return currentUserInfo;
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
        public async Task PostJsonAsync(string apiEndPoint, object content)
        { 
            await SendJsonAsync(HttpMethod.Post, apiEndPoint, content);
        }
        /// <summary>
        /// Sends a POST request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public async Task<T> PostJsonAsync<T>(string apiEndPoint, object content)
        { 
            return await SendJsonAsync<T>(HttpMethod.Post, apiEndPoint, content);
        }

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
        public async Task PutJsonAsync(string apiEndPoint, object content)
        { 
            await SendJsonAsync(HttpMethod.Put, apiEndPoint, content);
        }
        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public async Task<T> PutJsonAsync<T>(string apiEndPoint, object content)
        { 
            return await SendJsonAsync<T>(HttpMethod.Put, apiEndPoint, content);
        }
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
        public async Task SendJsonAsync(HttpMethod method, string apiEndPoint, object content)
        { 
            await SendJsonAsync<IgnoreResponse>(method, apiEndPoint, content);
        }
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
            // response.EnsureSuccessStatusCode();

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
        public T Create<T>(string apiEndPoint, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync($"{BaseUrl}{apiEndPoint}", stringContent).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var jsonObject = JsonConvert.DeserializeObject<AjaxResponse<T>>(data);
                return jsonObject.Result;
            }
            else
            {
                var data = response.Content.ReadAsStringAsync().Result;
            }
            return default(T);
        }
        public async Task<T> CreateAsync<T>(string apiEndPoint, object obj)
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
        public T ReadAll<T>(string apiEndPoint)
        {
            var response = _httpClient.GetAsync($"{BaseUrl}{apiEndPoint}").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;
            }
            return default(T);
        }
        public async Task<T> ReadAllAsync<T>(string apiEndPoint) 
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}{apiEndPoint}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;                
            }
            return default(T);
        }

        public T Filter<T>(string apiEndPoint, object filter)
        {
            var json = JsonConvert.SerializeObject(filter);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync($"{BaseUrl}{apiEndPoint}", stringContent).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var jsonObject = JsonConvert.DeserializeObject<AjaxResponse<T>>(data);
                return jsonObject.Result;
            }
            else
            {
                var data = response.Content.ReadAsStringAsync().Result;
            }
            return default(T);
        }
        public async Task<T> FilterAsync<T>(string apiEndPoint, object filter)
        {
            var json = JsonConvert.SerializeObject(filter);
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

        public T Read<T>(string apiEndPoint)
        {
            var response = _httpClient.GetAsync($"{BaseUrl}{apiEndPoint}").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;
            }
            return default(T);
        }
        public async Task<T> ReadAsync<T>(string apiEndPoint)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}{apiEndPoint}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;                
            }
            return default(T);
        }

        public T Read<T>(string apiEndPoint, long id)
        {
            var response = _httpClient.GetAsync($"{BaseUrl}{apiEndPoint}/{id}").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;
            }
            return default(T);
        }
        public async Task<T> ReadAsync<T>(string apiEndPoint, long id)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}{apiEndPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;                
            }
            return default(T);
        }

        public T Update<T>(string apiEndPoint, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = _httpClient.PutAsync($"{BaseUrl}{apiEndPoint}", stringContent).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;                
            }
            return default(T);
        }
        public async Task<T> UpdateAsync<T>(string apiEndPoint, object obj)
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
        public T Delete<T>(string apiEndPoint)
        {
            var response = _httpClient.DeleteAsync($"{BaseUrl}{apiEndPoint}").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;
            }
            return default(T);
        }
        public async Task<T> DeleteAsync<T>(string apiEndPoint)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}{apiEndPoint}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;
            }
            return default(T);
        }
        public T Delete<T>(string apiEndPoint, long id)
        {
            var response = _httpClient.DeleteAsync($"{BaseUrl}{apiEndPoint}/{id}").GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;
            }
            return default(T);
        }
        public async Task<T> DeleteAsync<T>(string apiEndPoint, long id)
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}{apiEndPoint}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AjaxResponse<T>>(data).Result;
            }
            return default(T);
        }

        public T Send<T>(HttpMethod method, string apiEndPoint, HttpContent content)
        {
            var response = _httpClient.SendAsync(new HttpRequestMessage(method, $"{BaseUrl}{apiEndPoint}")
            {
                Content = content
            }).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
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

        public byte[] SendBytes(HttpMethod method, string apiEndPoint, HttpContent content)
        {
            var response = _httpClient.SendAsync(new HttpRequestMessage(method, $"{BaseUrl}{apiEndPoint}")
            {
                Content = content
            }).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                return data;
            }
            return null;
        }
        public async Task<byte[]> SendBytesAsync(HttpMethod method, string apiEndPoint, HttpContent content)
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(method, $"{BaseUrl}{apiEndPoint}")
            {
                Content = content
            });
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsByteArrayAsync();
                return data;
            }
            return null;
        }

        public T PostBinary<T>(string apiEndPoint, HttpContent content)
        {
            var response = _httpClient.PostAsync($"{BaseUrl}/{apiEndPoint}", content).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                return JsonConvert.DeserializeObject<T>(data);
            }
            return default(T);
        }
        public byte[] PostBinary(string apiEndPoint, HttpContent content)
        {
            var response = _httpClient.PostAsync($"{BaseUrl}/{apiEndPoint}", content).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();
                return (data);
            }
            return null;
        }
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


    }
    public class IgnoreResponse { }
}
