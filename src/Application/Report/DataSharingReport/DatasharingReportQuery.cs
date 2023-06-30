using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Report.DataSharingReport
{
    public class DatasharingReportQuery:IRequest<DataSharingReportVM>
    {
        public int cid { get; set; }
        public string fid { get; set; }
        public string tid { get; set; }
        public string action { get; set; }
        public int orgname { get; set; }
        public int userid { get; set; }
    }
    public class DatasharingReportQueryHandler:IRequestHandler<DatasharingReportQuery,DataSharingReportVM>
    {

        
        private readonly IDatasharingReportService _idatasharingreportService;

        public DatasharingReportQueryHandler(IDatasharingReportService idatasharingreportService)
        {

            
            _idatasharingreportService = idatasharingreportService;
        }

        public async Task<DataSharingReportVM> Handle(DatasharingReportQuery request, CancellationToken cancellationToken)
        {
            
            var entity = new DataSharingReportDto();
            entity.catagory = request.cid;
            entity.orgname = request.orgname;
            entity.fid = request.fid;
            entity.tid = request.tid;
            entity.action = request.action;
            entity.userid = request.userid;

            return new DataSharingReportVM
            {
                
                Lists = await _idatasharingreportService.DatasharingReportList(entity)

            };
        }
    }
}
