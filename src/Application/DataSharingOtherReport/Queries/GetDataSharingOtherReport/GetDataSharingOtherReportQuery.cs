using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.DataSharingOtherReport.Queries.GetDataSharingOtherReport
{
    public class GetDataSharingOtherReportQuery : IRequest<DataSharingOtherReportVM>
    {
        public string p_action { get; set; }
        public string p_location { get; set; }
        public int p_s { get; set; }
        public int p_shead { get; set; }
    }
    public class GetDataSharingOtherReportQueryHandler : IRequestHandler<GetDataSharingOtherReportQuery, DataSharingOtherReportVM>
    {
        private readonly IDataSharingOtherReportService _iDataSharingOtherReportService;
        private readonly IMapper _mapper;

        public GetDataSharingOtherReportQueryHandler(IDataSharingOtherReportService iDataSharingOtherReportService, IMapper mapper)
        {
            _iDataSharingOtherReportService = iDataSharingOtherReportService;
            _mapper = mapper;
        }

        public async Task<DataSharingOtherReportVM> Handle(GetDataSharingOtherReportQuery request, CancellationToken cancellationToken)
        {
            var entity = new DataSharingOtherReportDto();
            entity.p_action = request.p_action;
            entity.p_location = request.p_location;
            entity.p_s = request.p_s;
            entity.p_shead = request.p_shead;
            return new DataSharingOtherReportVM
            {
                Lists = await _iDataSharingOtherReportService.GetDataSharingOtherReport(entity)
            };
        }
    }
}
