using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Abp.Application.Services.Dto;

using AbpHelper;
using AbpHelper.Roles.Dto;
using AbpHelper.Users.Dto;
using AbpHelper.MultiTenancy.Dto;
using AbpHelper.Sessions.Dto;
using AbpHelper.Session;

namespace Bamboo.AbpClient.Services
{
    public partial class SessionClientAppService : AbpCoreAppService, ISessionAppService
    {
        public SessionClientAppService(IAbpClient apiClient)
            : base(apiClient)
        {

        }
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations() 
        {
            throw new NotImplementedException();
        }
    }

}

