using AbpHelper.Authenticate;
using AbpHelper.Sessions.Dto;
using Bamboo.AbpClient.Model;

namespace Bamboo.AbpClient
{
    public interface IAccessTokenContext
    {
        string Token { get; set; }
        AuthenticateModel AuthenticateModel { get; set; }
        AuthenticateResultModel AuthenticateResult { get; set; }
    }
}