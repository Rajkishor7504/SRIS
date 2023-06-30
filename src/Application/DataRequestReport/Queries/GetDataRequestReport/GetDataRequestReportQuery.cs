using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.DataRequestReport.Queries.GetDataRequestReport
{
   public class GetDataRequestReportQuery : IRequest<DataRequestReportVM>
    {
        public string p_action { get; set; }
        public int organisationid { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
    }
    public class GetDataRequestReportQueryHandler : IRequestHandler<GetDataRequestReportQuery, DataRequestReportVM>
    {
        private readonly IDataRequestReportService _iDataRequestReportService;
        private readonly IMapper _mapper;

        public GetDataRequestReportQueryHandler(IDataRequestReportService iDataRequestReportService, IMapper mapper)
        {
            _iDataRequestReportService = iDataRequestReportService;
            _mapper = mapper;
        }

        public async Task<DataRequestReportVM> Handle(GetDataRequestReportQuery request, CancellationToken cancellationToken)
        {
            var entity = new DataRequestReportDto();
            entity.p_action = request.p_action;
            entity.organisationid = request.organisationid;
            entity.fromdate = request.fromdate;
            entity.todate = request.todate;
            return new DataRequestReportVM
            {
                Lists = await _iDataRequestReportService.GetDataRequestReport(entity)
            };
        }
    }
}
