using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService.MisReport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.MisReport.DemograpicConsolidateReportMaster.Qureies
{
    public class GetDemograpicConsolidateReportQuery : IRequest<DemograpicConsolidateReportVM>
    {
        public string action { get; set; }
        public int id { get; set; }
        public int parentid { get; set; }
        //public int pageno { get; set; }
        //public int pagesize { get; set; }
        public int consolid { get; set; }
        public int p_settlement { get; set; }

    }
    public class GetDemograpicConsolidateReportQueryHandler : IRequestHandler<GetDemograpicConsolidateReportQuery, DemograpicConsolidateReportVM>
    {
        private readonly IDemograpicConsolidateReportService _iDemograpicConsolidateReportService;
        private readonly IMapper _mapper;

        public GetDemograpicConsolidateReportQueryHandler(IDemograpicConsolidateReportService iDemograpicConsolidateReportService, IMapper mapper)
        {
            _iDemograpicConsolidateReportService = iDemograpicConsolidateReportService;
            _mapper = mapper;
        }

        public async Task<DemograpicConsolidateReportVM> Handle(GetDemograpicConsolidateReportQuery request, CancellationToken cancellationToken)
        {
            var entity = new DemograpicConsolidateReportDto();

            entity.action = request.action;
            entity.p_id = request.parentid;
           // entity.datarequest_id = request.datarequest_id;
            //entity.pageno = request.pageno;
            //entity.pagesize = request.pagesize;
            //entity.datarequest_id = request.datarequest_id;
            entity.town = request.p_settlement;
            return new DemograpicConsolidateReportVM
            {
                Lists = await _iDemograpicConsolidateReportService.DemograpicConsolidateReport(entity)
            };
        }
    }
}
