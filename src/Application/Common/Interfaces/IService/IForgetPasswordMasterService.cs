using SRIS.Application.ForgetPasswordMaster.Queries.GetForgetPasswordQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces.IService
{
   public interface IForgetPasswordMasterService
    {
        Task<List<ForgetPasswordMasterDto>> GetDetails(ForgetPasswordMasterDto dtls);
        Task<int> AddForgetMaster(ForgetPasswordMasterDto dtls);
    }
}
