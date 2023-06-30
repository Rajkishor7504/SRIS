using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.AssignEA.Queries
{
   public class GetAssignEAQuery : IRequest<AssignEaVM>
    {
        public string action { get; set; }
        public int id { get; set; }
        public int planid { get; set; }
        public int rid { get; set; }
        public int wid { get; set; }
        public int sid { get; set; }
    }
    public class GetAssignEAQueryHandler : IRequestHandler<GetAssignEAQuery, AssignEaVM>
    {
        private readonly IAssignEAService _iAssignEAService;
        private readonly IMapper _mapper;

        public GetAssignEAQueryHandler(IAssignEAService iAssignEAService, IMapper mapper)
        {
            _iAssignEAService = iAssignEAService;
            _mapper = mapper;
        }

        public async Task<AssignEaVM> Handle(GetAssignEAQuery request, CancellationToken cancellationToken)
        {
            var entity = new AssignEADto();
            entity.action = request.action;
            entity.levelid = request.id;
            entity.planid = request.planid;
            entity.regionid = request.rid;
            entity.wardid = request.wid;
            entity.settlementid = request.sid;
            return new AssignEaVM
            {
                Lists = await _iAssignEAService.GetAssignEA(entity)
            };
        }
    }

}
