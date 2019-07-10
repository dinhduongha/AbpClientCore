
namespace AbpHelper
{
    public class AbpUserBaseConst
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
    }
    public class AbpRoleBaseConst
    {
        //
        // Summary:
        //     Maximum length of the Abp.Authorization.Roles.AbpRoleBase.DisplayName property.
        public const int MaxDisplayNameLength = 64;
        //
        // Summary:
        //     Maximum length of the Abp.Authorization.Roles.AbpRoleBase.Name property.
        public const int MaxNameLength = 32;
        public const int MaxDescriptionLength = 5000;
    }

    public class AbpTenantBaseConst
    {
        //
        // Summary:
        //     Max length of the Abp.MultiTenancy.AbpTenantBase.TenancyName property.
        public const int MaxTenancyNameLength = 64;
        //
        // Summary:
        //     Max length of the Abp.MultiTenancy.AbpTenantBase.ConnectionString property.
        public const int MaxConnectionStringLength = 1024;
        //
        // Summary:
        //     "Default".
        public const string DefaultTenantName = "Default";
        //
        // Summary:
        //     "^[a-zA-Z][a-zA-Z0-9_-]{1,}$".
        public const string TenancyNameRegex = "^[a-zA-Z][a-zA-Z0-9_-]{1,}$";
        //
        // Summary:
        //     Max length of the Abp.MultiTenancy.AbpTenantBase.Name property.
        public const int MaxNameLength = 128;
    }

}