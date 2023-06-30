using SRIS.Application.Report;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IReporthhidService
    {
        Task<List<HouseholdcatagoryDto>> Gethhcatagory(HouseholdcatagoryDto hhcatagory);
    }
}
