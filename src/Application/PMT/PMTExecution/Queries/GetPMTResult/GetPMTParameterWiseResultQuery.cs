using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PMT.PMTExecution.Queries.GetPMTResult
{
    public class GetPMTParameterWiseResultQuery : IRequest<PMTResultVM>
    {        
        public int resultid { get; set; }        
    }
    public class GetPMTParameterWiseResultQueryHandler : IRequestHandler<GetPMTParameterWiseResultQuery, PMTResultVM>
    {
        private readonly IPMTService _iPMTService;
        //private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPMTParameterWiseResultQueryHandler(IPMTService iPMTService, IMapper mapper)
        {
            _iPMTService = iPMTService;
            _mapper = mapper;
        }

        #region "To get the PMT result"
        ///<summary>
        /// Created By Spandana Ray on 27/09/2021
        /// </summary>
        /// <parameter>Request Object of GetPMTParameterWiseResultQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To get the grievance member register</remarks>
        public async Task<PMTResultVM> Handle(GetPMTParameterWiseResultQuery request, CancellationToken cancellationToken)
        {
            //return new PMTResultVM
            //{
            //    PMTResultParameterLists = await _context.t_pmt_pmtresult_parameter.Where(p => p.resultid == request.resultid)
            //                .Join(_context.m_masterparameter
            //                   , pmtresult => pmtresult.pmtmasterid
            //                   , pmtmaster => pmtmaster.pmtmasterid
            //                   , (pmtresult, pmtmaster) => new { pmtresult, pmtmaster })
            //                    .Select(s => new PMTResultParameterDto
            //                    {
            //                        resultid = s.pmtresult.resultid,
            //                        moduleid = s.pmtresult.moduleid,
            //                        parameterid = s.pmtresult.parameterid,
            //                        questionnaireid = s.pmtresult.questionnaireid,
            //                        pmtmasterid = s.pmtresult.pmtmasterid,
            //                        yesvalue = s.pmtresult.yesvalue,
            //                        novalue = s.pmtresult.novalue,
            //                        coefficient = s.pmtresult.coefficient,
            //                        constant = s.pmtresult.constant,
            //                        hhvalue = s.pmtresult.hhvalue,
            //                        formulaconstant = s.pmtresult.formulaconstant,
            //                        parametername = s.pmtmaster.parametername

            //                    })
            //           .OrderBy(t => t.moduleid)
            //           .ToListAsync(cancellationToken)
            //};
            return new PMTResultVM
            {
                PMTResultParameterLists = await _iPMTService.GetParameterWisePMTResult(request.resultid)
            };
        }
        #endregion
    }
}
