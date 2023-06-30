using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PMT.ParameterMasterItems.Queries.GetParametermasterQueries
{
    public class GetParameterMasterQuery: IRequest<ParameterMasterVM>
    {
        public int pmtmasterid { get; set; }
    }
    public class GetParameterMasterQueryHandler : IRequestHandler<GetParameterMasterQuery, ParameterMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetParameterMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ParameterMasterVM> Handle(GetParameterMasterQuery request, CancellationToken cancellationToken)
        {
            return new ParameterMasterVM
            {
                Lists = await _context.m_masterparameter
                    .ProjectTo<ParameterMasterDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.pmtmasterid)
                    .ToListAsync(cancellationToken)
            };
        }
    }

}
