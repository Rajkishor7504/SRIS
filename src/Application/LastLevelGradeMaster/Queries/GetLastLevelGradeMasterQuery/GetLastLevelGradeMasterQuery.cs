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

namespace SRIS.Application.LastLevelGradeMaster.Queries.GetLastLevelGradeMasterQuery
{
    public class GetLastLevelGradeMasterQuery : IRequest<LastLevelGradeMasterQueryVM>
    {
        public int lastlevelid { get; set; }
    }
    public class GetLastLevelGradeMasterQueryHandler : IRequestHandler<GetLastLevelGradeMasterQuery, LastLevelGradeMasterQueryVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetLastLevelGradeMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LastLevelGradeMasterQueryVM> Handle(GetLastLevelGradeMasterQuery request, CancellationToken cancellationToken)
        {
            return new LastLevelGradeMasterQueryVM
            {
                Lists = await _context.m_master_lastlevelgrade
                    .ProjectTo<LastLevelGradeMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.lastlevelname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
