using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PMT.PMTParameterMasterItem.Queries.GetPMTParameterMasterItem
{
    public class GetPMTParameterQueries:IRequest<PMTParameterVM>
    {
        
    }
    public class GetPMTParameterQueriesHandler : IRequestHandler<GetPMTParameterQueries, PMTParameterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetPMTParameterQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<PMTParameterVM> Handle(GetPMTParameterQueries request, CancellationToken cancellationToken)
        {
            return new PMTParameterVM
            {
                Lists=await(from pmt in _context.t_pmt_pmtparameter
                            join mm in _context.m_master_module on pmt.moduleid equals mm.moduleid
                            join mq in _context.M_Master_Questionnaire on pmt.questionnaireid equals mq.questionnaireid
                           join sp in _context.t_survey_surveyplanning on pmt.planid equals sp.planid
                            join mp in _context.m_masterparameter on pmt.pmtmasterid equals mp.pmtmasterid
                            select new PMTParameterDto
                                {
                                   parameterid=pmt.parameterid,
                                   planid=pmt.planid,
                                   moduleid=pmt.moduleid,
                                   pmtmasterid = pmt.pmtmasterid,
                                   yesvalue=pmt.yesvalue,
                                   novalue=pmt.novalue,
                                   modulename=mm.modulename,
                                   questionnairename=mq.questionnairename,
                                   parametername=mp.parametername,
                                   surveyname=sp.surveyname
                                  

                                })
                       .OrderBy(t => t.moduleid)
                       .ToListAsync(cancellationToken)
            };
        }
    }
}
