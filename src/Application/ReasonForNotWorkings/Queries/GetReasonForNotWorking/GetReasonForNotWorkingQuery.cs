using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ReasonForNotWorkings.Queries.GetReasonForNotWorking
{
    public class GetReasonForNotWorkingQuery: IRequest<ReasonForNotWorkingVM>
    {
        public int reasonid { get; set; }
    }
    public class GetReasonForNotWorkingQueryHandler : IRequestHandler<GetReasonForNotWorkingQuery, ReasonForNotWorkingVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetReasonForNotWorkingQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReasonForNotWorkingVM> Handle(GetReasonForNotWorkingQuery request, CancellationToken cancellationToken)
        {
            return new ReasonForNotWorkingVM
            {
                Lists = await _context.m_master_reasonfornotworking
                    .ProjectTo<ReasonForNotWorkingDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.reasonname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}


