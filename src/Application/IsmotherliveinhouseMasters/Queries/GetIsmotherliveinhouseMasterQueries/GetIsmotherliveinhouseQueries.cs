using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.IsmotherliveinhouseMasters.Queries.GetIsmotherliveinhouseMasterQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.IsmotherliveinhouseMasters.Queries.GetIsmotherliveinhouseMasterQueries
{
    public class GetIsmotherliveinhouseQueries : IRequest<IsmotherliveinhouseVM>
    {
        public int id { get; set; }
    }
    public class GetIsmotherliveinhouseQueriesHandler : IRequestHandler<GetIsmotherliveinhouseQueries, IsmotherliveinhouseVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetIsmotherliveinhouseQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IsmotherliveinhouseVM> Handle(GetIsmotherliveinhouseQueries request, CancellationToken cancellationToken)
        {
            return new IsmotherliveinhouseVM
            {
                Lists = await _context.m_master_Ismotherliveinhouse
                    .ProjectTo<IsmotherliveinhouseDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.ismotherliveinhouse)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
