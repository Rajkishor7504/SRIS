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

namespace SRIS.Application.Quantiles.Queries.GetQuantiles
{
   public class GetQuantileQuery : IRequest<QuantileVM>
    {
    }
    public class GetQuantileQueryHandler : IRequestHandler<GetQuantileQuery, QuantileVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetQuantileQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<QuantileVM> Handle(GetQuantileQuery request, CancellationToken cancellationToken)
        {
            return new QuantileVM
            {
                Lists = await _context.m_master_quantile
                    .ProjectTo<QuantileDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.id)
                    .ToListAsync(cancellationToken)
            };
        }
    }

}
