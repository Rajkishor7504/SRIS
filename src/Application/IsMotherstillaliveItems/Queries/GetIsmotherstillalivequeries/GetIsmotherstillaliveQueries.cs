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

namespace SRIS.Application.IsMotherstillaliveItems.Queries.GetIsmotherstillalivequeries
{
     public class GetIsmotherstillaliveQueries : IRequest<IsmotherstillaliveVM>
    {
        public int id { get; set; }
    }
    public class GetIsmotherstillaliveQueriesHandler : IRequestHandler<GetIsmotherstillaliveQueries, IsmotherstillaliveVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetIsmotherstillaliveQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IsmotherstillaliveVM> Handle(GetIsmotherstillaliveQueries request, CancellationToken cancellationToken)
        {
            return new IsmotherstillaliveVM
            {
                Lists = await _context.m_master_Ismotherstillalive
                    .ProjectTo<IsmotherstillaliveDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.ismotherstillalive)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
