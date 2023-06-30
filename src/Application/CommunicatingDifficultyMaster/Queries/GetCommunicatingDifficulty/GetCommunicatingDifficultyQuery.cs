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

namespace SRIS.Application.CommunicatingDifficultyMaster.Queries.GetCommunicatingDifficulty
{
 public  class GetCommunicatingDifficultyQuery : IRequest<CommunicatingDifficultyVM>
    {
        public int id { get; set; }
    }
    public class GetCommunicatingDifficultyQueryHandler : IRequestHandler<GetCommunicatingDifficultyQuery, CommunicatingDifficultyVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCommunicatingDifficultyQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommunicatingDifficultyVM> Handle(GetCommunicatingDifficultyQuery request, CancellationToken cancellationToken)
        {
            return new CommunicatingDifficultyVM
            {
                Lists = await _context.m_master_Communicatingdifficulty
                    .ProjectTo<CommunicatingDifficultyDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.name)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
