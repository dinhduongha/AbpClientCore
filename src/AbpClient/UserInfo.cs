using System;
using AbpHelper;
using AbpHelper.Authenticate;
using AbpHelper.Sessions.Dto;

namespace AbpClientCore.Model
{
    public class UserInfo
    {
        public long id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string bio { get; set; }
        public string image { get; set; }
        public string token { get; set; }
        public string password { get; set; }
        public string encryted_token { get; set; }
        public long expire { get; set; }
        public CurrentLoginInformations info { get; set; }
        public AuthenticateResultModel loginResult { get; set; }
        public UserInfo Clone()
        {
            return new UserInfo
            {
                // Password and token will not be cloned.                
                id = id,
                email = email,
                username = username,
                bio = bio,
                image = image,
                expire = expire,
                info = info,
                loginResult = loginResult,
            };
        }
    }    
}
