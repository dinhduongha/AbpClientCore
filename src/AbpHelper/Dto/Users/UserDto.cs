using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bamboo.AbpHelper.Dto
{
    [Serializable]
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class UserDto
    {
        //
        // Summary:
        //     Maximum length of the Abp.Authorization.Users.AbpUserBase.UserName property.
        public const int MaxUserNameLength = 256;
        //
        // Summary:
        //     Maximum length of the Abp.Authorization.Users.AbpUserBase.EmailAddress property.
        public const int MaxEmailAddressLength = 256;
        //
        // Summary:
        //     Maximum length of the Abp.Authorization.Users.AbpUserBase.Name property.
        public const int MaxNameLength = 64;
        //
        // Summary:
        //     Maximum length of the Abp.Authorization.Users.AbpUserBase.Surname property.
        public const int MaxSurnameLength = 64;
        //
        // Summary:
        //     Maximum length of the Abp.Authorization.Users.AbpUserBase.AuthenticationSource
        //     property.
        public const int MaxAuthenticationSourceLength = 64;
        //
        // Summary:
        //     UserName of the admin. admin can not be deleted and UserName of the admin can
        //     not be changed.
        public const string AdminUserName = "admin";
        //
        // Summary:
        //     Maximum length of the Abp.Authorization.Users.AbpUserBase.Password property.
        public const int MaxPasswordLength = 128;
        //
        // Summary:
        //     Maximum length of the Abp.Authorization.Users.AbpUserBase.Password without hashed.
        public const int MaxPlainPasswordLength = 32;
        //
        // Summary:
        //     Maximum length of the Abp.Authorization.Users.AbpUserBase.EmailConfirmationCode
        //     property.
        public const int MaxEmailConfirmationCodeLength = 328;
        //
        // Summary:
        //     Maximum length of the Abp.Authorization.Users.AbpUserBase.PasswordResetCode property.
        public const int MaxPasswordResetCodeLength = 328;
        //
        // Summary:
        //     Maximum length of the Abp.Authorization.Users.AbpUserBase.PhoneNumber property.
        public const int MaxPhoneNumberLength = 32;
        //
        // Summary:
        //     Maximum length of the Abp.Authorization.Users.AbpUserBase.SecurityStamp property.
        public const int MaxSecurityStampLength = 128;

        public long Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public string FullName { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime CreationTime { get; set; }

        public string[] RoleNames { get; set; }

        [JsonProperty("guid", NullValueHandling = NullValueHandling.Ignore)]
        public Guid Guid { get; set; }
    }
}
