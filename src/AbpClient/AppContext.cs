using Bamboo.AbpClient.Model;
using AbpHelper.Sessions.Dto;

namespace Bamboo.AbpClient
{
    public class AppContext: IAppContext
    {
        public GetCurrentLoginInformationsOutput CurrentLoginInfo { get; set; }
        public CurrentUserInfo CurrentUserInfo { get; set; }
    }
}