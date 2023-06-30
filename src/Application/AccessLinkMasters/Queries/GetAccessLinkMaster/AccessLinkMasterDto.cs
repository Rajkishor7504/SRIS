/*
* File Name : AccessLinkMasterDto.cs
* class Name : AccessLinkMasterDto
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : Access Link Master Data Object
*/

using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;

namespace SRIS.Application.AccessLinkMasters.Queries.GetAccessLinkMaster
{
    public class AccessLinkMasterDto : IMapFrom<AccessLinkMaster>
    {
        public AccessLinkMasterDto()
        {
        }
        public int plinkid { get; set; }      
        public int userid { get; set; }
        public AccessLinkType accesstype { get; set; }
        public int linkaccessid { get; set; }

        public string plinkname { get; set; }
        public string glinkname { get; set; }
        public int glinkId { get; set; }
        public bool ViewValue
        {
            get
            {
                if (accesstype == AccessLinkType.View)
                    return true;
                return false;
            }
        }
        public bool AddValue
        {
            get
            {
                if (accesstype == AccessLinkType.Add)
                    return true;
                return false;
            }
        }
        public bool ManageValue
        {
            get
            {
                if (accesstype == AccessLinkType.Manage)
                    return true;
                return false;
            }
        }
    }
}
