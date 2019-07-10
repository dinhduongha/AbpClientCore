
namespace AbpHelper.Authenticate
{
    public class AuthenticateModel
    {
        public string UserNameOrEmailAddress { get; set; }

        public string Password { get; set; }

        public bool RememberClient { get; set; }
    }
    public class AuthenticateResultModel
    {
        public string AccessToken { get; set; }

        public string EncryptedAccessToken { get; set; }

        public int ExpireInSeconds { get; set; }

        public long UserId { get; set; }
    }
}
