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

namespace SRIS.Application.shocksMasters.Queries.GetshocksMaster
{
    public class GetshocksMasterQuery : IRequest<shocksMasterVM>
    {
        public int shockid { get; set; }
    }
    public class GetshocksMasterQueryHandler : IRequestHandler<GetshocksMasterQuery, shocksMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetshocksMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<shocksMasterVM> Handle(GetshocksMasterQuery request, CancellationToken cancellationToken)
        {
            return new shocksMasterVM
            {
                Lists = await _context.m_master_shocks
                    .ProjectTo<shocksMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.shockname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
