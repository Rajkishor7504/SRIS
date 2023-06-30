using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.LoginLogoutReport.Queries.GetLoginLogoutReport
{
  public  class GetLoginLogoutReportQuery:IRequest<LoginLogoutReportVM>
    {
        public string p_action { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
    }
      public class GetLoginLogoutReportQueryHandler : IRequestHandler<GetLoginLogoutReportQuery, LoginLogoutReportVM>
    {
        private readonly ILoginLogoutReportService _iLoginLogoutReportService;
        private readonly IMapper _mapper;

        public GetLoginLogoutReportQueryHandler(ILoginLogoutReportService iLoginLogoutReportService, IMapper mapper)
        {
            _iLoginLogoutReportService = iLoginLogoutReportService;
            _mapper = mapper;
        }

        public async Task<LoginLogoutReportVM> Handle(GetLoginLogoutReportQuery request, CancellationToken cancellationToken)
        {
            //handel method
            var entity = new LoginLogoutReportDto();
            entity.p_action = request.p_action;
            entity.fromdate = request.fromdate;
            entity.todate = request.todate;
            return new LoginLogoutReportVM
            {
                Lists = await _iLoginLogoutReportService.GetLoginLogoutReport(entity)
            };
        }
    }
}
