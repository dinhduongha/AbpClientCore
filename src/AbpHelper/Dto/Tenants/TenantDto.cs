using System.ComponentModel.DataAnnotations;

namespace AbpHelper.MultiTenancy.Dto
{
    public class TenantDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(AbpTenantBaseConst.MaxTenancyNameLength)]
        [RegularExpression(AbpTenantBaseConst.TenancyNameRegex)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(AbpTenantBaseConst.MaxNameLength)]
        public string Name { get; set; }        
        
        public bool IsActive {get; set;}
    }
}
