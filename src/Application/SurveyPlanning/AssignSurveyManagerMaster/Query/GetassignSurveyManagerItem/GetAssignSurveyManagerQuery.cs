using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.AssignSurveyManagerMaster.Query.GetassignSurveyManagerItem
{
    public class GetAssignSurveyManagerQuery : IRequest<AssignSurveyManagerVM>
    {

    }
    public class GetAssignSurveyManagerQueryHandler : IRequestHandler<GetAssignSurveyManagerQuery, AssignSurveyManagerVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAssignSurveyManagerService _iAssignSurveymanagerService;
        public GetAssignSurveyManagerQueryHandler(IApplicationDbContext context, IMapper mapper, IAssignSurveyManagerService iAssignSurveymanagerService)
        {
            _context = context;
            _mapper = mapper;
            _iAssignSurveymanagerService = iAssignSurveymanagerService;

        }

        public async Task<AssignSurveyManagerVM> Handle(GetAssignSurveyManagerQuery request, CancellationToken cancellationToken)
        {
            var entity = new AssignSurveyManagerDto();
            return new AssignSurveyManagerVM
            {
                Lists = await _iAssignSurveymanagerService.Getsurveymanagerdetails(entity)

            };
        }

        
    }
}
