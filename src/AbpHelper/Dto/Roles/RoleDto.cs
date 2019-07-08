using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bamboo.AbpHelper.Dto
{
    [Serializable]
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class RoleDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string DisplayName { get; set; }

        public string NormalizedName { get; set; }
        
        public string Description { get; set; }

        public bool IsStatic { get; set; }

        public List<string> Permissions { get; set; }
    }
}