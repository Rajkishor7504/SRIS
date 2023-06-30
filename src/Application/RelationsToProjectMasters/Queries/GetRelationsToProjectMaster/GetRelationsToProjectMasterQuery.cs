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

namespace SRIS.Application.RelationsToProjectMasters.Queries.GetRelationsToProjectMaster
{
    public class GetRelationsToProjectMasterQuery : IRequest<RelationsToProjectMasterVM>
    {
        public int relationid { get; set; }
    }
    public class GetshocksSeverityMasterQueryHandler : IRequestHandler<GetRelationsToProjectMasterQuery, RelationsToProjectMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetshocksSeverityMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RelationsToProjectMasterVM> Handle(GetRelationsToProjectMasterQuery request, CancellationToken cancellationToken)
        {
            return new RelationsToProjectMasterVM
            {
                Lists = await _context.m_master_relationofproject
                    .ProjectTo<RelationsToProjectMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.relationname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
