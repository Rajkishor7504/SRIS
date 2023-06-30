/*
* File Name : ConfigurePositionDto.cs
* class Name : ConfigurePositionDto
* Created Date : 13th Aug 2021
* Created By : Spandana Ray
* Description : Get Configure Position
*/
using SRIS.Application.Common.Mappings;
using SRIS.Domain.Entities.Grievance;

namespace SRIS.Application.Grievances.Queries.GetConfigurePosition
{
    public class ConfigurePositionDto : IMapFrom<ConfigurePosition>
    {
        public int positionid { get; set; }
        public int committeeid { get; set; }
        public string positionname { get; set; }
        public string description { get; set; }
    }
}
