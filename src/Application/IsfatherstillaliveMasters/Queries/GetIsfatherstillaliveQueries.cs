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

namespace SRIS.Application.IsfatherstillaliveMasters.Queries
{
   public class GetIsfatherstillaliveQueries : IRequest<IsfatherstillaliveVM>
    {
        public int id { get; set; }
    }
    public class GetIsfatherstillaliveQueriesHandler : IRequestHandler<GetIsfatherstillaliveQueries, IsfatherstillaliveVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetIsfatherstillaliveQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IsfatherstillaliveVM> Handle(GetIsfatherstillaliveQueries request, CancellationToken cancellationToken)
        {
            return new IsfatherstillaliveVM
            {
                Lists = await _context.m_master_isfatherstillalive
                    .ProjectTo<IsfatherstillaliveDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.isfatherstillalive)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}

