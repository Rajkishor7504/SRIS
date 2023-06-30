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

namespace SRIS.Application.PMT.PMTConfigurationMasterItem.Queries.GetPMTConfigurationMaster
{
    public class GetPMTConfigurationQueries : IRequest<PMTConfigurationVM>
    {
        public int pmtconfigureid { get; set; }
    }
    public class GetPMTConfigurationQueriesHandler : IRequestHandler<GetPMTConfigurationQueries, PMTConfigurationVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetPMTConfigurationQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<PMTConfigurationVM> Handle(GetPMTConfigurationQueries request, CancellationToken cancellationToken)
        {
            if (request.pmtconfigureid == 0)
            {
                return new PMTConfigurationVM
                {
                    Lists = await _context.t_pmt_configuration.Join(_context.t_survey_surveyplanning
                               , pmtconflid => pmtconflid.planid
                               , srvplnid => srvplnid.planid
                               , (pmtconflid, srvplnid) => new { pmtconflid, srvplnid })
                                .Select(s => new PMTConfigurationDto
                                {
                                    formulaname = s.pmtconflid.formulaname,
                                    formulacode = s.pmtconflid.formulacode,
                                    formuladescription = s.pmtconflid.formuladescription,
                                    formulaconstant = s.pmtconflid.formulaconstant,
                                    planid = s.pmtconflid.planid,
                                    pmtconfigureid = s.pmtconflid.pmtconfigureid,
                                    surveyname = s.srvplnid.surveyname,
                                   deletedflag=s.pmtconflid.deletedflag,

                        
                                })
                       .Where(t =>t.deletedflag == false)
                       .OrderBy(t => t.pmtconfigureid)
                       .ToListAsync(cancellationToken)
                };
            }
            else
            {
                return new PMTConfigurationVM
                { 
                Lists = await _context.t_pmt_config_coefficient.Join(_context.t_pmt_configuration
                              , coeffi => coeffi.pmtconfigureid
                              , pmtconfig => pmtconfig.pmtconfigureid
                              , (coeffi, pmtconfig) => new { coeffi, pmtconfig }).Join(_context.t_pmt_pmtparameter
                              , coeffi1 => coeffi1.coeffi.parameterid
                              , pmtmst => pmtmst.parameterid
                              , (coeffi1, pmtmst) => new { coeffi1, pmtmst,coeffi1.pmtconfig })
                              .Join(_context.m_masterparameter
                              , pmtmst2 => pmtmst2.pmtmst.pmtmasterid
                              , mstpmt => mstpmt.pmtmasterid
                              , (pmtmst2, mstpmt) => new { pmtmst2, mstpmt, pmtmst2.coeffi1.pmtconfig })
                              .Join(_context.m_master_module
                              , coeffi2 => coeffi2.pmtmst2.coeffi1.coeffi.moduleid
                              , mstmd => mstmd.moduleid
                              , (coeffi2, mstmd) => new { coeffi2, mstmd, coeffi2.mstpmt, coeffi2.pmtmst2,coeffi2.pmtconfig }).Join(_context.t_survey_surveyplanning
                              , pmtconfig1 => pmtconfig1.coeffi2.pmtconfig.planid
                              , survy => survy.planid
                              , (pmtconfig1, survy) => new { pmtconfig1, survy, pmtconfig1.mstpmt, pmtconfig1.coeffi2.pmtmst2, pmtconfig1.mstmd,pmtconfig1.coeffi2 })
                              .Where(s => s.coeffi2.pmtmst2.coeffi1.coeffi.pmtconfigureid == request.pmtconfigureid)
                               .Select(s => new PMTConfigurationDto
                               {
                                   coefficientid = s.coeffi2.pmtmst2.coeffi1.coeffi.coefficientid,
                                   pmtconfigureid = s.coeffi2.pmtmst2.coeffi1.coeffi.pmtconfigureid,
                                   moduleid = s.coeffi2.pmtmst2.coeffi1.coeffi.moduleid,
                                   parameterid = s.coeffi2.pmtmst2.coeffi1.coeffi.parameterid,
                                   yesvalue = s.coeffi2.pmtmst2.coeffi1.coeffi.yesvalue,
                                   novalue = s.coeffi2.pmtmst2.coeffi1.coeffi.novalue,
                                   coefficient = s.coeffi2.pmtmst2.coeffi1.coeffi.coefficient,
                                   constant = s.coeffi2.pmtmst2.coeffi1.coeffi.constant,
                                   parametername = s.mstpmt.parametername,
                                   modulename = s.mstmd.modulename,
                                   formulaname=s.pmtconfig1.pmtconfig.formulaname,
                                   formulacode=s.pmtconfig1.pmtconfig.formulacode,
                                   formuladescription=s.pmtconfig1.pmtconfig.formuladescription,
                                   formulaconstant=s.pmtconfig1.pmtconfig.formulaconstant,
                                   planid=s.pmtconfig1.pmtconfig.planid,
                                   surveyname=s.survy.surveyname,




                               })
                      .OrderBy(t => t.pmtconfigureid)
                      .ToListAsync(cancellationToken)
                };
        }

            
            
        }
    }
}


