using SRIS.Application.Userlogin_lgouttime.Queries.Userlogin_logouttimeQuery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IUserloginlogouttimeServices
    {
        Task<int> Updateduser(Userlogin_logouttimeDto obj);
    }
}
