using System;
using System.ComponentModel.DataAnnotations;

namespace AbpHelper.Users.Dto
{
    public class UserDto
    {
        [Required]
        public long Id {get; set;}

        [Required]
        [StringLength(AbpUserBaseConst.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [StringLength(AbpUserBaseConst.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBaseConst.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBaseConst.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public string FullName { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime CreationTime { get; set; }

        public string[] RoleNames { get; set; }
    }
}
