using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.MemberInformationReport.Queries.GetMemberInformation
{
   public class MemberInformationQuery:IRequest<MemberInformationVM>
    {
        public string p_action { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int splanid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public int hhid { get; set; }
    }
    public class MemberInformationQueryHandler : IRequestHandler<MemberInformationQuery, MemberInformationVM>
    {
        private readonly IMemberInformationReportService _iIMemberInformationReportService;
        private readonly IMapper _mapper;

        public MemberInformationQueryHandler(IMemberInformationReportService iMemberInformationReportService, IMapper mapper)
        {
            _iIMemberInformationReportService = iMemberInformationReportService;
            _mapper = mapper;
        }

        public async Task<MemberInformationVM> Handle(MemberInformationQuery request, CancellationToken cancellationToken)
        {
            var entity = new MemberInformationDto();
            entity.p_action = request.p_action;
            entity.regionid = request.regionid;
            entity.splanid = request.splanid;
            entity.districtid = request.districtid;
            entity.wardid = request.wardid;
            entity.settlementid = request.settlementid;
            entity.hhid = request.hhid;
            return new MemberInformationVM
            {
                Lists = await _iIMemberInformationReportService.GetMemberInformation(entity)
            };
        }
    }
}
