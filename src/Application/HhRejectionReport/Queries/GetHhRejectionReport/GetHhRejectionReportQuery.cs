using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.HhRejectionReport.Queries.GetHhRejectionReport
{
   public class GetHhRejectionReportQuery:IRequest<HhRejectionReportVM>
    {
        public string p_action { get; set; }
        public int splanid { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
    }
    public class GetHhRejectionReportQueryHandler : IRequestHandler<GetHhRejectionReportQuery, HhRejectionReportVM>
    {
        private readonly IHhRejectionReportService _iHhRejectionReportService;
        private readonly IMapper _mapper;

        public GetHhRejectionReportQueryHandler(IHhRejectionReportService iHhRejectionReportService, IMapper mapper)
        {
            _iHhRejectionReportService = iHhRejectionReportService;
            _mapper = mapper;
        }

        public async Task<HhRejectionReportVM> Handle(GetHhRejectionReportQuery request, CancellationToken cancellationToken)
        {
            var entity = new HhRejectionReportDto();
            entity.p_action = request.p_action;
            entity.splanid = request.splanid;
            entity.regionid = request.regionid;
            entity.districtid = request.districtid;
            entity.wardid = request.wardid;
            entity.settlementid = request.settlementid;
            return new HhRejectionReportVM
            {
                Lists = await _iHhRejectionReportService.GetHhRejectionReport(entity)
            };
        }
    }
}
