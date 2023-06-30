using SRIS.Application.GlobalLinkMasters.Queries.GetGlobalLinkMaster;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.AssignLinkToRoleMasters.Queries.GetAssignLinkToRoleMaster
{
   public class AssignLinkToRoleMasterVM
    {
        public int assignlinkid { get; set; }
        public int plinkid { get; set; }
        public int userid { get; set; }
        public int roleid { get; set; }
        public AssignLinkToRoleType accesstype { get; set; }
        public int linkaccessid { get; set; }
        public bool deletedflag { get; set; }
        public IList<AssignLinkToRoleMasterDto> Lists { get; set; }

        public IList<GlobalLinkMasterDto> GLLists { get; set; }
    }
}