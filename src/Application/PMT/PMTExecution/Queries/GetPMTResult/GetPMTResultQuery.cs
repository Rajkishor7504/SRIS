using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PMT.PMTExecution.Queries.GetPMTResult
{
    public class GetPMTResultQuery : IRequest<PMTResultVM>
    {
        public string action { get; set; }
        public string locationid { get; set; }
        //public int locationid { get; set; }
        public int surveyid { get; set; }
        public int pmtconfigureid { get; set; }
    }
    public class GetPMTResultQueryHandler : IRequestHandler<GetPMTResultQuery, PMTResultVM>
    {        
        private readonly IPMTService _iPMTService;
        private readonly IMapper _mapper;

        public GetPMTResultQueryHandler(IPMTService iPMTService, IMapper mapper)
        {
            _iPMTService = iPMTService;
            _mapper = mapper;
        }

        #region "To get the PMT result"
        ///<summary>
        /// Created By Spandana Ray on 27/09/2021
        /// </summary>
        /// <parameter>Request Object of GetPMTResultQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To get the PMT result</remarks>
        public async Task<PMTResultVM> Handle(GetPMTResultQuery request, CancellationToken cancellationToken)
        {
            if (request.action == "PR" || request.action == "PE")
            {
                return new PMTResultVM
                {
                    Lists = await _iPMTService.GetPMTResult(request.action, request.locationid, request.surveyid, request.pmtconfigureid)
                };
            }
            else if ( request.action == "DPR")
            {
                return new PMTResultVM
                {
                    PMTReportWiseCountLists = await _iPMTService.GetPMTReport(request.action, request.locationid, request.surveyid,request.pmtconfigureid)
                };
            }
            else
            {
                return new PMTResultVM
                {
                    PMTCategoryWiseCountLists = await _iPMTService.GetPMTCategoryWiseCount(request.action, request.locationid, request.surveyid, request.pmtconfigureid)
                };
            }
        }
        #endregion
    }
}
