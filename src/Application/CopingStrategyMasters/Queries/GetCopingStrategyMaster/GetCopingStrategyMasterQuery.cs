using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.CopingStrategyMasters.Queries.GetCopingStrategyMaster
{
   public class GetCopingStrategyMasterQuery : IRequest<CopingStrategyMasterVM>
    {
        public string action { get; set; }
    }
    public class GetCopingStrategyMasterQueryHandler : IRequestHandler<GetCopingStrategyMasterQuery, CopingStrategyMasterVM>
    {
        private readonly ICopingStrategyMasterService _iCopingStaregy;
        private readonly IMapper _mapper;

        public GetCopingStrategyMasterQueryHandler(ICopingStrategyMasterService iCopingStaregy, IMapper mapper)
        {
            _iCopingStaregy = iCopingStaregy;
            _mapper = mapper;
        }


        public async Task<CopingStrategyMasterVM> Handle(GetCopingStrategyMasterQuery request, CancellationToken cancellationToken)
        {

            return new CopingStrategyMasterVM
            {
                Lists = await _iCopingStaregy.GetCopingStartegyMaster(request.action),
            };
        }
    }
}
