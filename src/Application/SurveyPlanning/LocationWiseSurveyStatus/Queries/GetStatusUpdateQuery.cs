using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.LocationWiseSurveyStatus.Queries
{
   public class GetStatusUpdateQuery : IRequest<StatusUpdateVM>
    {
        public string action { get; set; }
        public int searchid { get; set; }
    }
    public class GetStatusUpdateQueryHandler : IRequestHandler<GetStatusUpdateQuery, StatusUpdateVM>
    {
        private readonly ILocationStatusUpdateService _iLocationStatusUpdateService;
        private readonly IMapper _mapper;

        public GetStatusUpdateQueryHandler(ILocationStatusUpdateService iLocationStatusUpdateService, IMapper mapper)
        {
            _iLocationStatusUpdateService = iLocationStatusUpdateService;
            _mapper = mapper;
        }

        public async Task<StatusUpdateVM> Handle(GetStatusUpdateQuery request, CancellationToken cancellationToken)
        {
            var entity = new StatusUpdateDto();
            entity.action = request.action;
            entity.searchid = request.searchid;
            return new StatusUpdateVM
            {
                Lists = await _iLocationStatusUpdateService.GetStatus(entity)
            };
        }
    }
}
