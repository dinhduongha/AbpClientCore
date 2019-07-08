using System;

namespace Bamboo.AbpHelper.Dto
{
    [Serializable]
    public class IsTenantAvailableInput
    {
        public string TenancyName { get; set; }
    }
}
