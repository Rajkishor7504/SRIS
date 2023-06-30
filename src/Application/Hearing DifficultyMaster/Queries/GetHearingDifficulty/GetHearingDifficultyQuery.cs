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

namespace SRIS.Application.Hearing_DifficultyMaster.Queries.GetHearingDifficulty
{
   public class GetHearingDifficultyQuery : IRequest<HearingDifficultyVM>
    {
       
            public int id { get; set; }
        
    }
    public class GetHearingDifficultyQueryHandler : IRequestHandler<GetHearingDifficultyQuery, HearingDifficultyVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetHearingDifficultyQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<HearingDifficultyVM> Handle(GetHearingDifficultyQuery request, CancellationToken cancellationToken)
        {
            return new HearingDifficultyVM
            {
                Lists = await _context.m_master_Hearingdifficulty
                    .ProjectTo<HearingDifficultyDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.name)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
