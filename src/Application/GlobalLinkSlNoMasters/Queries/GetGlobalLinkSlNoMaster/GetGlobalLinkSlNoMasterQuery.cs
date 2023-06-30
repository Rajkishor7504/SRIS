using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GlobalLinkSlNoMasters.Queries.GetGlobalLinkSlNoMaster
{
    public class GetGlobalLinkSlNoMasterQuery : IRequest<GlobalLinkSlNoMasterVM>
    {
        public int glinkid { get; set; }
    }
    public class GetPrimayLinkSlNoMasterQueryHandler : IRequestHandler<GetGlobalLinkSlNoMasterQuery, GlobalLinkSlNoMasterVM>
    {
        private readonly IGlobalLinkSlNoService _iGlobalLinkSlNoService;
        private readonly IMapper _mapper;
        public GetPrimayLinkSlNoMasterQueryHandler(IGlobalLinkSlNoService primaryLinkSlNoService, IMapper mapper)
        {
            _iGlobalLinkSlNoService = primaryLinkSlNoService;
            _mapper = mapper;
        }
        public async Task<GlobalLinkSlNoMasterVM> Handle(GetGlobalLinkSlNoMasterQuery request, CancellationToken cancellationToken)
        {
            return new GlobalLinkSlNoMasterVM
            {
                Lists = await _iGlobalLinkSlNoService.GetGlobalLinks()
            };
        }
    }
}
