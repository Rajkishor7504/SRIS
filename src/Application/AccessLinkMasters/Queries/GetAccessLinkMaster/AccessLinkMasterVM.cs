/*
* File Name : AccessLinkMasterVM.cs
* class Name : AccessLinkMasterVM
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : Access Link Master View Model
*/

using SRIS.Application.GlobalLinkMasters.Queries.GetGlobalLinkMaster;
using SRIS.Domain.Entities;
using System.Collections.Generic;

namespace SRIS.Application.AccessLinkMasters.Queries.GetAccessLinkMaster
{
    public class AccessLinkMasterVM
    {
        public int plinkid { get; set; }
        public int userid { get; set; }
        public AccessLinkType accesstype { get; set; }
        public int linkaccessid { get; set; }
        public bool deletedflag { get; set; }
        public IList<AccessLinkMasterDto> Lists { get; set; }
        
        public IList<GlobalLinkMasterDto> GLLists { get; set; }
    }
}
