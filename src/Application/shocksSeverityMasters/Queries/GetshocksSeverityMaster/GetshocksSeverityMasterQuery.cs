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

namespace SRIS.Application.shocksSeverityMasters.Queries.GetshocksSeverityMaster
{
    public class GetshocksSeverityMasterQuery : IRequest<shocksSeverityMasterVM>
    {
        public int severityid { get; set; }
    }
    public class GetshocksSeverityMasterQueryHandler : IRequestHandler<GetshocksSeverityMasterQuery, shocksSeverityMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetshocksSeverityMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<shocksSeverityMasterVM> Handle(GetshocksSeverityMasterQuery request, CancellationToken cancellationToken)
        {
            return new shocksSeverityMasterVM
            {
                Lists = await _context.m_master_severity
                    .ProjectTo<shocksSeverityMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.severityname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
