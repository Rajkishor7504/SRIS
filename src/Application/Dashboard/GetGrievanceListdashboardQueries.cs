using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Dashboard
{
    public class GetGrievanceListdashboardQueries : IRequest<DashGrievanceListVM>
    {
        public string action { get; set; }
        public int id { get; set; }
        public string yeargv { get; set; }
        public string yearga { get; set; }
        public int locationId { get; set; }
        public int committeeId { get; set; }
    }
    public class GetGrievanceListdashboardQueriesHandler : IRequestHandler<GetGrievanceListdashboardQueries, DashGrievanceListVM>
    {
        private readonly IDashboardService _idashboardService;

        public GetGrievanceListdashboardQueriesHandler(IDashboardService idashboardService)
        {
            _idashboardService = idashboardService;
           
        }

        public async Task<DashGrievanceListVM> Handle(GetGrievanceListdashboardQueries request, CancellationToken cancellationToken)
        {
            var entity = new DashboardDto();
            entity.action = request.action;
            entity.id = request.id;
            entity.yeargv = request.yeargv;
            entity.yearga = request.yearga;
            if (request.action == "bgs")
            {
                return new DashGrievanceListVM
                {
                    Lists = await _idashboardService.GetGrievanceGraphLists(entity)

                };
            }
            else if(request.action == "ga" || request.action == "hus" || request.action == "par" || request.action == "dr" 
                    || request.action == "uo" || request.action == "sm" || request.action == "qo" || request.action == "qs"
                    || request.action == "drp" || request.action == "gvl")
            {
                return new DashGrievanceListVM
                {
                    Lists = await _idashboardService.GetFilterNonGraphList(entity,request.committeeId,request.locationId)

                };
            }
            else if(request.action=="v"|| request.action == "fv")
            {
                return new DashGrievanceListVM
                {
                    Lists = await _idashboardService.GetFilterPmtList(entity)

                };
            }
            else
            {
                return new DashGrievanceListVM
                {
                    Lists = await _idashboardService.GetdashboardGrievanceList(entity)

                };
            }


        }
    }
}
