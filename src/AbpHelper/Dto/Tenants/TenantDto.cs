using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bamboo.AbpHelper.Dto
{
    [Serializable]
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class TenantDto
    {
        // Summary:
        //     Max length of the Abp.MultiTenancy.AbpTenantBase.TenancyName property.
        public const int MaxTenancyNameLength = 64;
        //
        // Summary:
        //     Max length of the Abp.MultiTenancy.AbpTenantBase.ConnectionString property.
        public const int MaxConnectionStringLength = 1024;
        //
        // Summary:
        //     "Default".
        public const string DefaultTenantName = "Default";
        //
        // Summary:
        //     "^[a-zA-Z][a-zA-Z0-9_-]{1,}$".
        public const string TenancyNameRegex = "^[a-zA-Z][a-zA-Z0-9_-]{1,}$";
        //
        // Summary:
        //     Max length of the Abp.MultiTenancy.AbpTenantBase.Name property.
        public const int MaxNameLength = 128;

        public long Id { get; set; }
        
        public string TenancyName { get; set; }

        public string Name { get; set; }        
        
        public bool IsActive {get; set;}

        [JsonProperty("guid", NullValueHandling = NullValueHandling.Ignore)]
        public Guid Guid { get; set; }
    }
}
