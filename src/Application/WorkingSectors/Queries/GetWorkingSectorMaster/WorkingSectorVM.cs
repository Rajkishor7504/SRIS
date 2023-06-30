using SRIS.Application.WorkingSectors.Commands.CreateWorkingSectorMaster;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRIS.Application.WorkingSectors.Queries.GetWorkingSectorMaster
{
    public class WorkingSectorVM
    {
        public IList<WorkingSectorDto> Lists { get; set; }
        public CreateWorkingSectorCommand command { get; set; }
        public int sectorid { get; set; }
        public string sectorname { get; set; }
        public string description { get; set; }
    }
}
