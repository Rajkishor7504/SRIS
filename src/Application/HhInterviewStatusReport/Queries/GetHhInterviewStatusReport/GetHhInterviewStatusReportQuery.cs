using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.HhInterviewStatusReport;
using SRIS.Application.LoginForMobile;

namespace SRIS.Application.HhInterviewStatusReport.Queries.GetHhInterviewStatusReport
{
    public class GetHhInterviewStatusReportQuery : IRequest<HhInterviewStatusReportVM>
    {
        public string p_action { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public int searchid { get; set; }
        public int rgnid { get; set; }
        public int distid { get; set; }
        public string enumeratorname { get; set; }
        public string supervisorname { get; set; }
    }
    public class GetHhInterviewStatusReportQueryHandler : IRequestHandler<GetHhInterviewStatusReportQuery, HhInterviewStatusReportVM>
    {
        private readonly IHhInterviewStatusReportService _iHhInterviewStatusReportService;
        private readonly IMapper _mapper;

        public GetHhInterviewStatusReportQueryHandler(IHhInterviewStatusReportService iHhInterviewStatusReportService, IMapper mapper)
        {
            _iHhInterviewStatusReportService = iHhInterviewStatusReportService;
            _mapper = mapper;
        }

        public async Task<HhInterviewStatusReportVM> Handle(GetHhInterviewStatusReportQuery request, CancellationToken cancellationToken)
        {
            var entity = new HhInterviewStatusReportDto();
            entity.p_action = request.p_action;
            entity.fromdate = request.fromdate;
            entity.todate = request.todate;
            entity.searchid = request.searchid;
            entity.rgnid = request.rgnid;
            entity.distid = request.distid;
            entity.enumeratorname = request.enumeratorname;
            entity.supervisorname = request.supervisorname;
            return new HhInterviewStatusReportVM
            {
                Lists = await _iHhInterviewStatusReportService.GetHhInterviewStatusReport(entity)
            };
        }
    }
}
