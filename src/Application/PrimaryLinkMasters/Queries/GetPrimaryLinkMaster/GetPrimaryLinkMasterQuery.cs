/*
* File Name : GetPrimaryLinkMasterQuery.cs
* class Name : GetPrimaryLinkMasterQuery, GetPrimaryLinkQueryHandler
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : Query to Get the Primary Link
*/

using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PrimaryLinkMasters.Queries.GetPrimaryLinkMaster
{
    public class GetPrimaryLinkMasterQuery : IRequest<PrimaryLinkMasterVM>
    {
        public int plinkid { get; set; }        
    }
    
    public class GetPrimaryLinkQueryHandler : IRequestHandler<GetPrimaryLinkMasterQuery, PrimaryLinkMasterVM>
    {
        private readonly IPrimaryLinkService _iPrimaryLinkService;
        private readonly IMapper _mapper;

        public GetPrimaryLinkQueryHandler(IPrimaryLinkService iPrimaryLinkService, IMapper mapper)
        {
            _iPrimaryLinkService = iPrimaryLinkService;
            _mapper = mapper;
        }

        #region "To Get the Primary Link"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of GetPrimaryLinkMasterQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To Get the Primary Link</remarks>
        public async Task<PrimaryLinkMasterVM> Handle(GetPrimaryLinkMasterQuery request, CancellationToken cancellationToken)
        {
            return new PrimaryLinkMasterVM
            {
                Lists = await _iPrimaryLinkService.GetPrimaryLinks()
            };
        }
        #endregion
    }
}
