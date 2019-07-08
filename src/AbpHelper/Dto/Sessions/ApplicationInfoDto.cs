using System;
using System.Collections.Generic;

namespace Bamboo.AbpSessions.Dto
{
    [Serializable]
    public class ApplicationInfoDto
    {
        public string Version { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Dictionary<string, bool> Features { get; set; }
    }
}
