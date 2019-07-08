using System;
using System.Collections.Generic;
using System.Text;

using Bamboo.AbpHelper.Ajax;
using Bamboo.AbpSessions.Dto;

namespace Bamboo.AbpHelper
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
