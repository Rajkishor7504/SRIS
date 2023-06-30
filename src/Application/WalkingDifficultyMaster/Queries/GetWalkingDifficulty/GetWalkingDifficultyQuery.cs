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

namespace SRIS.Application.WalkingDifficultyMaster.Queries.GetWalkingDifficulty
{
   public class GetWalkingDifficultyQuery : IRequest<WalkingDifficultyVM>
    {
        public int id { get; set; }
    }
    public class GetWalkingDifficultyQueryHandler : IRequestHandler<GetWalkingDifficultyQuery, WalkingDifficultyVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetWalkingDifficultyQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WalkingDifficultyVM> Handle(GetWalkingDifficultyQuery request, CancellationToken cancellationToken)
        {
            return new WalkingDifficultyVM
            {
                Lists = await _context.m_master_Walkingdifficulty
                    .ProjectTo<WalkingDifficultyDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.name)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
