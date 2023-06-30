using SRIS.Application.UMUserLocationMasterItem.Queries.GetUMUserLocationMasterItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IUserLocationService
    {
        Task<List<UMUserLocationDto>> Getuserlocation(UMUserLocationDto userloc);
        Task<List<UMUserLocationDto>> GetuserlocationByID(int userid);
        Task<int> adduserloca(UMUserLocationDto obj);
        Task<int> deleteloc(int? ulocid);
    }
}
