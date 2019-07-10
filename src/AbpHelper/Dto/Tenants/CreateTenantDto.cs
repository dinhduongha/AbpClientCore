using System.ComponentModel.DataAnnotations;

namespace AbpHelper.MultiTenancy.Dto
{
    public class CreateTenantDto
    {
        [Required]
        [StringLength(AbpTenantBaseConst.MaxTenancyNameLength)]
        [RegularExpression(AbpTenantBaseConst.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(AbpTenantBaseConst.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBaseConst.MaxEmailAddressLength)]
        public string AdminEmailAddress { get; set; }

        [StringLength(AbpTenantBaseConst.MaxConnectionStringLength)]
        public string ConnectionString { get; set; }

        public bool IsActive {get; set;}
    }
}
