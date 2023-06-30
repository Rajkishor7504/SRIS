using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.SettlementWiseTargetMaster.Queries.GetSettlementWiseTargetMasterQuery
{
    public class GetSettlementWiseTargetQuery : IRequest<SettlementWiseTargetVM>
    {
        public int stargetid { get; set; }
        public string action { get; set; }
        public int planid { get; set; }
        public int searchid { get; set; }
        public int clusterno { get; set; }
        public int rid { get; set; }
        public int did { get; set; }
        public int eaid { get; set; }
    }
    public class GetSettlementWiseTargetQueryHandler : IRequestHandler<GetSettlementWiseTargetQuery, SettlementWiseTargetVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISettlementwisetargetservice _isettlementtarget;

        public GetSettlementWiseTargetQueryHandler(IApplicationDbContext context, IMapper mapper, ISettlementwisetargetservice isettlementtarget)
        {
            _context = context;
            _mapper = mapper;
            _isettlementtarget = isettlementtarget;
        }

        public async Task<SettlementWiseTargetVM> Handle(GetSettlementWiseTargetQuery request, CancellationToken cancellationToken)
        {
            var entity = new SettlementWiseTargetDto();
            entity.action = request.action;
            entity.planid = request.planid;
            entity.searchid = request.searchid;
            entity.clusterno = request.clusterno;
            entity.regionid = request.rid;
            entity.districtid = request.did;
            entity.eaid = request.eaid;
            //if (request.teamid == 0)
            //{
                return new SettlementWiseTargetVM
                {
                    Lists = await _isettlementtarget.Geteanumber(entity)
                };
           // }
        }
    }
}
