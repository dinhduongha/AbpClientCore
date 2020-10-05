using AbpHelper.Authenticate;
using AbpHelper.Sessions.Dto;
using Bamboo.AbpClient.Model;

namespace Bamboo.AbpClient
{
    public class AccessTokenContext: IAccessTokenContext
    {
        public string Token { get; set; }
        public AuthenticateModel AuthenticateModel { get; set; }
        public AuthenticateResultModel AuthenticateResult { get; set; }
    }
}