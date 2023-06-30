using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PrimaryLinkAllMastersMasters.Queries.GetPrimaryLinkAllMastersMaster
{
    public class GetPrimaryLinkAllMastersMasterQuery : IRequest<PrimaryLinkAllMastersMasterVM>
    {
        public int plinkid { get; set; }
    }

    public class GetPrimaryLinkAllMastersMasterQueryHandler : IRequestHandler<GetPrimaryLinkAllMastersMasterQuery, PrimaryLinkAllMastersMasterVM>
    {
        private readonly IPrimaryLinkAllMastersService _IPrimaryLinkAllMastersService;
        private readonly IMapper _mapper;

        public GetPrimaryLinkAllMastersMasterQueryHandler(IPrimaryLinkAllMastersService iPrimaryLinkService, IMapper mapper)
        {
            _IPrimaryLinkAllMastersService = iPrimaryLinkService;
            _mapper = mapper;
        }

        #region "To Get the Primary Link"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of GetPrimaryLinkAllMastersMasterQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To Get the Primary Link</remarks>
        public async Task<PrimaryLinkAllMastersMasterVM> Handle(GetPrimaryLinkAllMastersMasterQuery request, CancellationToken cancellationToken)
        {
            return new PrimaryLinkAllMastersMasterVM
            {
                Lists = await _IPrimaryLinkAllMastersService.GetPrimaryLinks()
            };
        }
        #endregion
    }
}