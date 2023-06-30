using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService.Feedback;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.FeedbackReport.BenificiaryReport.Queries
{
    public class GetBenificiaryReportQuery : IRequest<BenificiaryReportVM>
    {
        public string action { get; set; }
        //public int p_hhid { get; set; }
        public int parentid { get; set; }
        //public int pageno { get; set; }
        //public int pagesize { get; set; }
        public int programdetailsid { get; set; }
    }
    public class GetBenificiaryReportQueryHandler : IRequestHandler<GetBenificiaryReportQuery, BenificiaryReportVM>
    {
        private readonly IBenificiaryReportService _iBenificiaryReportService;
        private readonly IMapper _mapper;

        public GetBenificiaryReportQueryHandler(IBenificiaryReportService iBenificiaryReportService, IMapper mapper)
        {
            _iBenificiaryReportService = iBenificiaryReportService;
            _mapper = mapper;
        }

        public async Task<BenificiaryReportVM> Handle(GetBenificiaryReportQuery request, CancellationToken cancellationToken)
        {
            var entity = new BenificiaryReportDto();

            entity.action = request.action;
            entity.p_id = request.parentid;
            //entity.pageno = request.pageno;
            //entity.pagesize = request.pagesize;
            entity.programdetailsid = request.programdetailsid;
            return new BenificiaryReportVM
            {
                Lists = await _iBenificiaryReportService.GetBenificiaryReport(entity)
            };
        }
    }
}
