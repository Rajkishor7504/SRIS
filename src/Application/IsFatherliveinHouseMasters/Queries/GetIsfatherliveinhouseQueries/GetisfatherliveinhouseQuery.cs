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

namespace SRIS.Application.IsFatherliveinHouseMasters.Queries.GetIsfatherliveinhouseQueries
{
    public class GetisfatherliveinhouseQuery : IRequest<IsfatherliveinhouseVM>
    {
        public int id { get; set; }
    }
    public class GetisfatherliveinhouseQueryHandler : IRequestHandler<GetisfatherliveinhouseQuery, IsfatherliveinhouseVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetisfatherliveinhouseQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IsfatherliveinhouseVM> Handle(GetisfatherliveinhouseQuery request, CancellationToken cancellationToken)
        {
            return new IsfatherliveinhouseVM
            {
                Lists = await _context.m_master_Isfatherliveinhouse
                    .ProjectTo<IsfatherliveinhouseDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.isfatherliveinhouse)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
