using System;
namespace Bamboo.AbpSessions.Dto
{
    [Serializable]
    public class TenantLoginInfoDto
    {
        public long Id { get; set; }

        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
