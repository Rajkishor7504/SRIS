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

namespace SRIS.Application.RelationMasters.Queries.GetRelationMaster
{
    public class GetRelationMasterQuery : IRequest<RelationMasterVM>
    {
        public int id { get; set; }
    }
    public class GetRelationMasterQueryHandler : IRequestHandler<GetRelationMasterQuery, RelationMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRelationMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RelationMasterVM> Handle(GetRelationMasterQuery request, CancellationToken cancellationToken)
        {
            return new RelationMasterVM
            {
                Lists = await _context.m_master_relation
                    .ProjectTo<RelationMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.relationname)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
