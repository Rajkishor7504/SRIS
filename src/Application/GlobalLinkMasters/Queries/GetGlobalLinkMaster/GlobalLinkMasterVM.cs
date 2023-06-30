/*
* File Name : GlobalLinkMasterVM.cs
* class Name : GlobalLinkMasterVM
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : Global Link Master VM
*/

using System.Collections.Generic;

namespace SRIS.Application.GlobalLinkMasters.Queries.GetGlobalLinkMaster
{
    public class GlobalLinkMasterVM
    {
        public IList<GlobalLinkMasterDto> Lists { get; set; }
        public int glinkid { get; set; }
        public string glinkname { get; set; }
        public int MenuOrder { get; set; }
    }
}
