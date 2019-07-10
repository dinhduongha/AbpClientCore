using System;
using AbpHelper;
using AbpHelper.Authenticate;
using AbpHelper.Sessions.Dto;

namespace AbpClientCore.Model
{
    public class CurrentUserInfo
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public string Encryted_token { get; set; }
        public long Expire { get; set; }
        public CurrentLoginInformations Info { get; set; }
        public AuthenticateResultModel LoginResult { get; set; }
        public CurrentUserInfo Clone()
        {
            return new CurrentUserInfo
            {
                // Password and token will not be cloned.                
                Id = Id,
                Email = Email,
                Username = Username,
                Bio = Bio,
                Image = Image,
                Expire = Expire,
                Info = Info,
                LoginResult = LoginResult,
            };
        }
    }    
}
