using System;
using MediatR;
using System.Collections.Generic;
using System.Text;
using SRIS.Application.RegionReport.Queries;
using SRIS.Application.Common.Interfaces.IService;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;

namespace SRIS.Application.RegionReport.Queries.GetRegionSurvey
{
    public class GetRegionSurveyQuery : IRequest<SurveyRegionVM>
    {
        public string p_action { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int splanid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
    }
        public class GetRegionSurveyQueryHandler : IRequestHandler<GetRegionSurveyQuery, SurveyRegionVM>
        {
            private readonly IRegionReportService _iIRegionReportService;
            private readonly IMapper _mapper;

            public GetRegionSurveyQueryHandler(IRegionReportService iRegionReportService, IMapper mapper)
            {
            _iIRegionReportService = iRegionReportService;
                _mapper = mapper;
            }

            public async Task<SurveyRegionVM> Handle(GetRegionSurveyQuery request, CancellationToken cancellationToken)
            {
                var entity = new SurveyRegionDto();
                entity.p_action = request.p_action;
                entity.regionid = request.regionid;
                entity.splanid = request.splanid;
                entity.districtid = request.districtid;
                entity.wardid = request.wardid;
                entity.settlementid = request.settlementid;
                return new SurveyRegionVM
                {
                    Lists = await _iIRegionReportService.GetRegionReport(entity)
                };
            }
        }
    }
