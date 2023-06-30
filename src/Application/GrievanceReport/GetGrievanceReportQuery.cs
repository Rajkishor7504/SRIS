using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GrievanceReport
{
    public class GetGrievanceReportQuery:IRequest<GrievanceReportVM>
    {
        public int rid { get; set; }
        public int roleid { get; set; }
        public int id { get; set; }
        public int did { get; set; }
        public int wid { get; set; }
        public int sid { get; set; }
        public int cid { get; set; }
        public string fid { get; set; }
        public string tid { get; set; }
        public string action { get; set; }
    }
    public class GetGrievanceReportQueryHandler : IRequestHandler<GetGrievanceReportQuery, GrievanceReportVM>
     {
    
        private readonly IMapper _mapper;
        private readonly IGrievanceReportService _igrievancereportService;

       public GetGrievanceReportQueryHandler(IMapper mapper,IGrievanceReportService igrievancereportService)
       {
        
        _mapper = mapper;
        _igrievancereportService = igrievancereportService;  
       }

        public async Task<GrievanceReportVM> Handle(GetGrievanceReportQuery request, CancellationToken cancellationToken)
        {
            var entity = new GrievanceReportDto();
            entity.action = request.action;
            entity.id = request.id;
            entity.districtid = request.did;
            entity.regionid = request.rid;
            entity.wardid = request.wid;
            entity.settlementid = request.sid;
            entity.grievanceconfigid = request.cid;
            entity.fromdate = request.fid;
            entity.todate = request.tid;

            return new GrievanceReportVM
            {
                Lists = await _igrievancereportService.GrievanceReportList(entity)

            };
        }
    }
}