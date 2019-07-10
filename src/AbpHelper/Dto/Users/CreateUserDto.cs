using System.ComponentModel.DataAnnotations;

namespace AbpHelper.Users.Dto
{
    public class CreateUserDto
    {
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

        public string[] RoleNames { get; set; }

        [Required]
        [StringLength(AbpUserBaseConst.MaxPlainPasswordLength)]
        public string Password { get; set; }

        public void Normalize()
        {
            if (RoleNames == null)
            {
                RoleNames = new string[0];
            }
        }
    }
}
