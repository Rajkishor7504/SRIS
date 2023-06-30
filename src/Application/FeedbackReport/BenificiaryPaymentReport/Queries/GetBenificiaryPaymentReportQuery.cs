using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService.Feedback;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.FeedbackReport.BenificiaryPaymentReport.Queries
{
    public class GetBenificiaryPaymentReportQuery : IRequest<BenificiaryPaymentReportVM>
    {
        public string action { get; set; }
         public int id { get; set; }
        public int parentid { get; set; }
        public int datarequest_id { get; set; }
        public int programdtlsid { get; set; }
        //  public int pageno { get; set; }
        //  public int pagesize { get; set; }


    }
    public class GetBenificiaryPaymentReportQueryHandler : IRequestHandler<GetBenificiaryPaymentReportQuery, BenificiaryPaymentReportVM>
    {
        private readonly IBenificiaryPaymentReportService _iBenificiaryPaymentReportService; 
        private readonly IMapper _mapper;

        public GetBenificiaryPaymentReportQueryHandler(IBenificiaryPaymentReportService iBenificiaryPaymentReportService, IMapper mapper)
        {
            _iBenificiaryPaymentReportService = iBenificiaryPaymentReportService;
            _mapper = mapper;
        }

        public async Task<BenificiaryPaymentReportVM> Handle(GetBenificiaryPaymentReportQuery request, CancellationToken cancellationToken)
        {
            var entity = new BenificiaryPaymentReportDto();

            entity.action = request.action;
            entity.p_id = request.parentid;
            entity.programdtlsid = request.programdtlsid;
            entity.datarequest_id = request.datarequest_id;
            return new BenificiaryPaymentReportVM
            {
                Lists = await _iBenificiaryPaymentReportService.BenificiaryPaymentReport(entity)
            };
        }
    }
}
