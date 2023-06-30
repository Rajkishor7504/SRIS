/*
* File Name : GlobalLinkMasterDto.cs
* class Name : GlobalLinkMasterDto
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : Global Link Master DTO
*/

using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities;

namespace SRIS.Application.GlobalLinkMasters.Queries.GetGlobalLinkMaster
{
    public class GlobalLinkMasterDto : IMapFrom<GlobalLinkMaster>
    {
        public string glinkname { get; set; }
        public int glinkid { get; set; }
        public int MenuOrder { get; set; }
    }
}
