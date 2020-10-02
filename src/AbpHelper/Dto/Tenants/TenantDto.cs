
namespace AbpHelper.MultiTenancy.Dto
{
    public class TenantDto
    {
        public int Id { get; set; }

        public string TenancyName { get; set; }

        public string Name { get; set; }        
        
        public bool IsActive {get; set;}
    }
}
