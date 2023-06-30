using System.Collections.Generic;

namespace SRIS.Application.ConfigureCommiteeMasterItems.Queries.GetConfigureCommitee
{
    public class ConfigureCommiteeVM
    {
        public IList<ConfigureCommiteeDto> Lists { get; set; }
        public int configureid { get; set; }
        public string commiteename { get; set; }
        public int noofcommiteemembers { get; set; }
        public int createdby { get; set; }

    }
}
