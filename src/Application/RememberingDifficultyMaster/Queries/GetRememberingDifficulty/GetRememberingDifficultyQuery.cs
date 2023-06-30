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

namespace SRIS.Application.RememberingDifficultyMaster.Queries.GetRememberingDifficulty
{
   public class GetRememberingDifficultyQuery : IRequest<RememberingDifficultyVM>
    {
        public int id { get; set; }
    }
    public class GetHearingDifficultyQueryHandler : IRequestHandler<GetRememberingDifficultyQuery, RememberingDifficultyVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetHearingDifficultyQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RememberingDifficultyVM> Handle(GetRememberingDifficultyQuery request, CancellationToken cancellationToken)
        {
            return new RememberingDifficultyVM
            {
                Lists = await _context.m_master_Rememberingdifficulty
                    .ProjectTo<RememberingDifficultyDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.name)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
