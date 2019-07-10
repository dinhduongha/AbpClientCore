using System.ComponentModel.DataAnnotations;

namespace AbpHelper.Roles.Dto
{
    public class RoleEditDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(AbpRoleBaseConst.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpRoleBaseConst.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        [StringLength(AbpRoleBaseConst.MaxDescriptionLength)]
        public string Description { get; set; }

        public bool IsStatic { get; set; }
    }
}