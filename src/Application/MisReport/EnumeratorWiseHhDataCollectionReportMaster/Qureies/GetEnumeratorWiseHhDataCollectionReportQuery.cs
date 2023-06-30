using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces.IService.MisReport;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.MisReport.EnumeratorWiseHhDataCollectionReportMaster.Qureies
{
   public class GetEnumeratorWiseHhDataCollectionReportQuery: IRequest<EnumeratorWiseHhDataCollectionReportVM>
    {
        public string action { get; set; }
      //  public int id { get; set; }
      public int pid { get; set; }
        public int rid { get; set; }
        public int did { get; set; }
        public int p_planid { get; set; }
        public int parentid { get; set; }
        
    }
    public class GetEnumeratorWiseHhDataCollectionReportHandler : IRequestHandler<GetEnumeratorWiseHhDataCollectionReportQuery, EnumeratorWiseHhDataCollectionReportVM>
    {
        private readonly IEnumeratorWiseHhDataCollectionReportService _iEnumeratorWiseHhDataCollectionReportService;
        private readonly IMapper _mapper;

        public GetEnumeratorWiseHhDataCollectionReportHandler(IEnumeratorWiseHhDataCollectionReportService iEnumeratorWiseHhDataCollectionReportService, IMapper mapper)
        {
            _iEnumeratorWiseHhDataCollectionReportService = iEnumeratorWiseHhDataCollectionReportService;
            _mapper = mapper;
        }

        public async Task<EnumeratorWiseHhDataCollectionReportVM> Handle(GetEnumeratorWiseHhDataCollectionReportQuery request, CancellationToken cancellationToken)
        {
            var entity = new EnumeratorWiseHhDataCollectionReportDto();

            entity.action = request.action;
            entity.p_id = request.parentid;
            entity.p_planid = request.pid;
            entity.p_regionid = request.rid;
            entity.p_distid = request.did;
        
            
            return new EnumeratorWiseHhDataCollectionReportVM
            {
                Lists = await _iEnumeratorWiseHhDataCollectionReportService.EnumeratorWiseHhDataCollectionReport(entity)
            };
        }
    }
}

