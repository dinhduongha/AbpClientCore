using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using AbpHelper.Accounts.Dto;
using AbpHelper.Authorization;

namespace Bamboo.AbpClient.Services
{
    public partial class AccountClientAppService : AbpCoreAppService, IAccountAppService
    {
        public AccountClientAppService(IAbpClient apiClient)
            : base(apiClient)
        {

        }
        public async Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public async Task<RegisterOutput> Register(RegisterInput input)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }

}

