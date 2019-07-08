using System;
namespace Bamboo.AbpSessions.Dto
{
    [Serializable]
    public class UserLoginInfoDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
