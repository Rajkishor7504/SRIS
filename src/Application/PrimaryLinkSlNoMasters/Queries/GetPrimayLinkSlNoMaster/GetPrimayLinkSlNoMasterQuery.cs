using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PrimaryLinkSlNoMasters.Queries.GetPrimayLinkSlNoMaster
{
    public class GetPrimayLinkSlNoMasterQuery:IRequest<PrimayLinkSlNoMasterVM>
    {
        public int plinkid { get; set; }
    }
    public class GetPrimayLinkSlNoMasterQueryHandler:IRequestHandler<GetPrimayLinkSlNoMasterQuery,PrimayLinkSlNoMasterVM>
    {
        private readonly IPrimaryLinkSlNoService _iPrimaryLinkSlNoService;
        private readonly IMapper _mapper;
        public GetPrimayLinkSlNoMasterQueryHandler(IPrimaryLinkSlNoService primaryLinkSlNoService, IMapper mapper)
        {
            _iPrimaryLinkSlNoService= primaryLinkSlNoService;
            _mapper=mapper;
        }
        public async Task<PrimayLinkSlNoMasterVM> Handle(GetPrimayLinkSlNoMasterQuery request, CancellationToken cancellationToken)
        {
            return new PrimayLinkSlNoMasterVM
            {
                Lists = await _iPrimaryLinkSlNoService.GetPrimaryLinks()
            };
        }
    }
}
