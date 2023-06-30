using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.MasterEntities;

namespace SRIS.Application.ConfigureCommiteeMasterItems.Queries.GetConfigureCommitee
{
    public class ConfigureCommiteeDto:IMapFrom<ConfigureCommitee>
    {
        public int configureid { get; set; }
        public string commiteename { get; set; }
        public int noofcommiteemembers { get; set; }
        
    }
}
