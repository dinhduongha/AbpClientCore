using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AbpHelper.Roles.Dto
{
    public class CreateRoleDto
    {
        [Required]
        [StringLength(AbpRoleBaseConst.MaxNameLength)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(AbpRoleBaseConst.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        public string NormalizedName { get; set; }
        
        [StringLength(AbpRoleBaseConst.MaxDescriptionLength)]
        public string Description { get; set; }

        public List<string> Permissions { get; set; }
    }
}
