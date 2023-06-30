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

namespace SRIS.Application.MainJobActivityMaster.Queries.GetMainJobActivityMasterQuery
{
   public class GetMainJobActivityQuery: IRequest<MainJobActivityVM>
    {
        public int activityid { get; set; }
    }
    public class GetMainJobActivityQueryHandler : IRequestHandler<GetMainJobActivityQuery, MainJobActivityVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMainJobActivityQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MainJobActivityVM> Handle(GetMainJobActivityQuery request, CancellationToken cancellationToken)
        {
            return new MainJobActivityVM
            {
                Lists = await _context.m_master_mainjobactivity
                    .ProjectTo<MainJobActivityDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.activityname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
