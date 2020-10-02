using System.Collections.Generic;

namespace AbpHelper.Roles.Dto
{
    public class RoleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string DisplayName { get; set; }

        public string NormalizedName { get; set; }
        
        public string Description { get; set; }

        public List<string> GrantedPermissions { get; set; }
    }
}