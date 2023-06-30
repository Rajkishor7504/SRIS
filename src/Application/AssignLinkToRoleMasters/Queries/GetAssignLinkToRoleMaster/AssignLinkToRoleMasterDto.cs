using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;

namespace SRIS.Application.AssignLinkToRoleMasters.Queries.GetAssignLinkToRoleMaster
{
    public class AssignLinkToRoleMasterDto : IMapFrom<AssignLinkToRoleMaster>
    {
        public AssignLinkToRoleMasterDto()
        {
        }
        public int plinkid { get; set; }
        public int userid { get; set; }
        public int roleid { get; set; }
       // public int userid { get; set; }
        public AssignLinkToRoleType accesstype { get; set; }
        public int linkaccessid { get; set; }
        //  public int assignlinkid { get; set; }
       // public bool deletedflag { get; set; }
        public string plinkname { get; set; }
        public string glinkname { get; set; }
        public int glinkId { get; set; }
        public bool ViewValue
        {
            get
            {
                if (accesstype == AssignLinkToRoleType.View)
                    return true;
                return false;
            }
        }
        public bool AddValue
        {
            get
            {
                if (accesstype == AssignLinkToRoleType.Add)
                    return true;
                return false;
            }
        }
        public bool ManageValue
        {
            get
            {
                if (accesstype == AssignLinkToRoleType.Manage)
                    return true;
                return false;
            }
        }
        public bool deletedflag { get; set; }
    }
}