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

namespace SRIS.Application.SeeingDifficultyMaster.Queries.GetSeeingDifficulty
{
   public class GetSeeingDifficultyQuery: IRequest<SeeingDifficultyVM>
    {
        public int id { get; set; }
    }
    public class GetSeeingDifficultyQueryHandler : IRequestHandler<GetSeeingDifficultyQuery, SeeingDifficultyVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSeeingDifficultyQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SeeingDifficultyVM> Handle(GetSeeingDifficultyQuery request, CancellationToken cancellationToken)
        {
            return new SeeingDifficultyVM
            {
                Lists = await _context.m_master_seeingdifficulty
                    .ProjectTo<SeeingDifficultyDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.name)
                    .ToListAsync(cancellationToken)
            };
        }
    
    }
}
