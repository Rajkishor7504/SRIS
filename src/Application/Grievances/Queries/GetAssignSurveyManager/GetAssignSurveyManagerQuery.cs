using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Grievances.Queries.GetAssignSurveyManager
{
    public class GetAssignSurveyManagerQuery: IRequest<AssignSurveyManagerVM>
    {
        public int UserId { get; set; }
        public int Pkid { get; set; }
        public string action { get; set; }
    }
    public class GetAssignSurveyManagerQueryHandler : IRequestHandler<GetAssignSurveyManagerQuery, AssignSurveyManagerVM>
    {
        private readonly IGrievanceService _igrivService;
        private readonly IMapper _mapper;

        public GetAssignSurveyManagerQueryHandler(IGrievanceService igrivService, IMapper mapper)
        {
            _igrivService = igrivService;
            _mapper = mapper;
        }

        public async Task<AssignSurveyManagerVM> Handle(GetAssignSurveyManagerQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.action == "VT")
                {
                    return new AssignSurveyManagerVM
                    {
                        Lists = await _igrivService.ViewTaggedSurveyManager(request.Pkid)
                    };
                }
                else
                {
                    return new AssignSurveyManagerVM
                    {
                        Lists = await _igrivService.GetGrievanceBySurveyManagerId(request.UserId)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
