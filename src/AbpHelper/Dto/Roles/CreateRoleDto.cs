using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

namespace Bamboo.AbpHelper.Dto
{
    [Serializable]
    public class CreateRoleDto
    {
        public string Name { get; set; }
        
        public string DisplayName { get; set; }

        public string NormalizedName { get; set; }
        
        public string Description { get; set; }

        public bool IsStatic { get; set; }

        public List<string> Permissions { get; set; }
    }
}
