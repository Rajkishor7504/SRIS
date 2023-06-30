using SRIS.Application.UpdateHousehold.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
   public interface IUpdateHouseholdService
    {
        Task<List<UpdateHouseholdDto>> GetHouseholdDetails(UpdateHouseholdDto objUpdateHouseholdDto);
        Task<int> UpdateHousehold(UpdateHouseholdDto objUpdateHouseholdDto);
       // Task<int> UpdateHouseholdstatus(UpdateHouseholdDto objUpdateHouseholdstatus);
    }
}
