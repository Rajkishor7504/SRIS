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

namespace SRIS.Application.TransportationModeMasters.Queries.GetTransportationModeMaster
{
    public class GetTransportationModeMasterQuery : IRequest<TransportationModeMasterVM>
    {
        public int modeid { get; set; }
    }
    public class GetTransportationModeMasterQueryHandler : IRequestHandler<GetTransportationModeMasterQuery, TransportationModeMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTransportationModeMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TransportationModeMasterVM> Handle(GetTransportationModeMasterQuery request, CancellationToken cancellationToken)
        {
            return new TransportationModeMasterVM
            {
                Lists = await _context.m_master_transportationmode
                    .ProjectTo<TransportationModeMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.modename)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}