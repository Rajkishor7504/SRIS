using SRIS.Application.Common.Dropdown.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface ICommonService
    {
        Task<List<FillDropdownDto>> GetDropdownData(FillDrodownQuery obj);
    }
}
