using System;

namespace AbpHelper.Roles.Dto
{
    public class RoleListDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool IsStatic { get; set; }

        public bool IsDefault { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
