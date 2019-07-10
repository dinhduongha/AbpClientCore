using System;
namespace AbpHelper.Accounts.Dto
{
    [Serializable]
    public class IsTenantAvailableInput
    {
        public string TenancyName { get; set; }
    }
}
