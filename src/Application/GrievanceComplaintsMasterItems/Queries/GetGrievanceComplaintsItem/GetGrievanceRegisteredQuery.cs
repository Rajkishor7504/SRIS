/*
* File Name : GrievanceRegisteredVM.cs
* class Name : GrievanceRegisteredVM
* Created Date : 26 Aug 2021
* Created By : Spandana Ray
* Description : Grievance Information
*/
using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem
{
    public class GetGrievanceRegisteredQuery : IRequest<GrievanceResolutionMasterVM>
    {
        public int UserId { get; set; }
        public int locationId { get; set; }
        public string action { get; set; }
    }
    public class GetGrievanceRegisteredQueryHandler : IRequestHandler<GetGrievanceRegisteredQuery, GrievanceResolutionMasterVM>
    {
        private readonly IGrievanceService _igrivService;
        private readonly IMapper _mapper;
        public GetGrievanceRegisteredQueryHandler(IGrievanceService igrivService, IMapper mapper)
        {
            _igrivService = igrivService;
            _mapper = mapper;            
        }

        public async Task<GrievanceResolutionMasterVM> Handle(GetGrievanceRegisteredQuery request, CancellationToken cancellationToken)
        {
            var grievanceVM = new GrievanceResolutionMasterVM();
            if (request.action == "SM" || request.action == "PD") // Getting data for Assign Survey Manager Screen
            {
                grievanceVM.AssignSurveyManagerLists = await _igrivService.GetSurveyDetails(request.action, request.locationId, request.UserId);
                grievanceVM.region = grievanceVM.AssignSurveyManagerLists[0].region;
                grievanceVM.dist = grievanceVM.AssignSurveyManagerLists[0].district;
            }
            else
            {
                grievanceVM.GrievanceLists = await _igrivService.GrievanceView(request.action, request.locationId, request.UserId);
            }
            return grievanceVM;
        }
    }
}
