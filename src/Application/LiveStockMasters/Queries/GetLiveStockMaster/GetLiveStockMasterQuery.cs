using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.LiveStockMasters.Queries.GetLiveStockMaster
{
    public class GetLiveStockMasterQuery : IRequest<LiveStockMasterVM>
    {
        public int livestockid { get; set; }
    }
    public class GetLiveStockMasterQueryHandler : IRequestHandler<GetLiveStockMasterQuery, LiveStockMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetLiveStockMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LiveStockMasterVM> Handle(GetLiveStockMasterQuery request, CancellationToken cancellationToken)
        {
            return new LiveStockMasterVM
            {
                Lists = await _context.m_master_livestock
                    .ProjectTo<LiveStockMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.livestockname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
