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

namespace SRIS.Application.SelfcareingdifficultyMaster.Queries.GetSelfcareingdifficulty
{
    public class GetSelfcareingdifficultyQuery:IRequest<SelfcareingdifficultyVM>
    {
        public int id { get; set; }
    }
    public class GetSelfcareingdifficultyQueryHandler : IRequestHandler<GetSelfcareingdifficultyQuery, SelfcareingdifficultyVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSelfcareingdifficultyQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SelfcareingdifficultyVM> Handle(GetSelfcareingdifficultyQuery request, CancellationToken cancellationToken)
        {
            return new SelfcareingdifficultyVM
            {
                Lists = await _context.m_master_Selfcareingdifficulty
                    .ProjectTo<SelfcareingdifficultyDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.name)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}

