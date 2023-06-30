/*
* File Name : GetAccessLinkMasterQuery.cs
* class Name : GetAccessLinkMasterQuery, GetAccessLinkQueryHandler
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : Query to return the User Access Link
*/

using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.GlobalLinkMasters.Queries.GetGlobalLinkMaster;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AccessLinkMasters.Queries.GetAccessLinkMaster
{
    public class GetAccessLinkMasterQuery : IRequest<AccessLinkMasterVM>
    {
        public int linkaccessid { get; set; }
        public int userid { get; set; }
    }    
    public class GetAccessLinkQueryHandler : IRequestHandler<GetAccessLinkMasterQuery, AccessLinkMasterVM>
    {
        private readonly IAccessLinkService _iAccessLinkService;
        private readonly IMapper _mapper;

        public GetAccessLinkQueryHandler(IAccessLinkService iAccessLinkService, IMapper mapper)
        {
            _iAccessLinkService = iAccessLinkService;
            _mapper = mapper;
        }

        #region "To Get User Access Link"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of GetAccessLinkMasterQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To Get User Access Link</remarks>
        public async Task<AccessLinkMasterVM> Handle(GetAccessLinkMasterQuery request, CancellationToken cancellationToken)
        {
            var list = await _iAccessLinkService.GetUserAccessLinks(request.userid);
            var glist = list.Where(u => u.linkaccessid != 0).Select(p => new GlobalLinkMasterDto()
                            {
                                glinkname = p.glinkname,
                                glinkid = p.glinkId
                            }).ToList();
            return new AccessLinkMasterVM
            {
                Lists = list.OrderBy(g => g.glinkId).ToList(),
                GLLists = glist.GroupBy(x => x.glinkid).Select(x => x.FirstOrDefault()).OrderBy(g => g.glinkid).ToList()
            };
        }
        #endregion
    }
}
