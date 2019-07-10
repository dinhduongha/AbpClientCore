using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AbpHelper.Accounts.Dto
{
    public class RegisterInput : IValidatableObject
    {
        [Required]
        [StringLength(AbpUserBaseConst.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBaseConst.MaxSurnameLength)]
        public string Surname { get; set; }

        [Required]
        [StringLength(AbpUserBaseConst.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBaseConst.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(AbpUserBaseConst.MaxPlainPasswordLength)]

        public string Password { get; set; }

        public string CaptchaResponse { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(UserName))
            {
                if (!UserName.Equals(EmailAddress) && ValidationHelper.IsEmail(UserName))
                {
                    yield return new ValidationResult("Username cannot be an email address unless it's the same as your email address!");
                }
            }
        }
    }
}
