using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.AssignSurvey.Queries
{
  public class GetAssignSurveyQuery : IRequest<AssignSurveyVM>
    {
        public string action { get; set; }
        public int searchid { get; set; }

    }
    public class GetAssignSurveyQueryHandler : IRequestHandler<GetAssignSurveyQuery, AssignSurveyVM>
    {
        private readonly IAssignSurveyService _iAssignSurveyService;
        private readonly IMapper _mapper;

        public GetAssignSurveyQueryHandler(IAssignSurveyService iAssignSurveyService, IMapper mapper)
        {
            _iAssignSurveyService = iAssignSurveyService;
            _mapper = mapper;
        }

        public async Task<AssignSurveyVM> Handle(GetAssignSurveyQuery request, CancellationToken cancellationToken)
        {
            var entity = new AssignSurveyDto();
            entity.action = request.action;
            entity.searchid = request.searchid;
            return new AssignSurveyVM
            {
                Lists = await _iAssignSurveyService.GetAssignedSurvey(entity)
            };
        }
    }

}
