namespace Bamboo.AbpSessions.Dto
{
    public class CurrentLoginInformations
    {
        public ApplicationInfoDto Application { get; set; }

        public UserLoginInfoDto User { get; set; }

        public TenantLoginInfoDto Tenant { get; set; }
    }
}
