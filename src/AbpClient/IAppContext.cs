using Bamboo.AbpClient.Model;
using AbpHelper.Sessions.Dto;

namespace Bamboo.AbpClient
{
    public interface IAppContext
    {
        GetCurrentLoginInformationsOutput CurrentLoginInfo { get; set; }
        CurrentUserInfo CurrentUserInfo { get; set; }
    }
}