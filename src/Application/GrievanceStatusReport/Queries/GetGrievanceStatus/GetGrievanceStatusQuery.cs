using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GrievanceStatusReport.Queries.GetGrievanceStatus
{
  public  class GetGrievanceStatusQuery: IRequest<GrievanceStatusVM>
    {
        public string p_action { get; set; }
        public int searchid { get; set; }
        public int rgnid { get; set; }
        public int Grievanceid { get; set; }
        public int distid { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
    }
    public class GetGrievanceStatusQueryHandler : IRequestHandler<GetGrievanceStatusQuery, GrievanceStatusVM>
    {
        private readonly IGrievanceStatusReportService _iIGrievanceStatusReportService;
        private readonly IMapper _mapper;

        public GetGrievanceStatusQueryHandler(IGrievanceStatusReportService iGrievanceStatusReportService, IMapper mapper)
        {
            _iIGrievanceStatusReportService = iGrievanceStatusReportService;
            _mapper = mapper;
        }

        public async Task<GrievanceStatusVM> Handle(GetGrievanceStatusQuery request, CancellationToken cancellationToken)
        {
            var entity = new GrievanceStatusDto();
            entity.p_action = request.p_action;
            entity.searchid = request.searchid;
            entity.rgnid = request.rgnid;
            entity.distid = request.distid;
            entity.Grievanceid = request.Grievanceid;
            entity.fromdate = request.fromdate;
            entity.todate = request.todate;
            return new GrievanceStatusVM
            {
                Lists = await _iIGrievanceStatusReportService.GetGrievanceStatusReport(entity)
            };
        }
    }
}
