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

namespace SRIS.Application.PMT.PMTExecution.Queries.GetParameterItem
{
    public class GetParameterQuery : IRequest<ParameterVM>
    {
        public int pmtconfigureid { get; set; }
    }
    public class GetParameterQueryHandler : IRequestHandler<GetParameterQuery, ParameterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public GetParameterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<ParameterVM> Handle(GetParameterQuery request, CancellationToken cancellationToken)
        {
            return new ParameterVM
            {
                Lists = await(from coeff in _context.t_pmt_config_coefficient.Where(c=>c.pmtconfigureid == request.pmtconfigureid && !c.deletedflag)
                              join p in _context.m_masterparameter on coeff.parameterid equals p.pmtmasterid
                              
                              select new ParameterDto
                              {

                              })
                       //.OrderBy(t => t.moduleid)
                       .ToListAsync(cancellationToken)
            };
        }
    }
}
