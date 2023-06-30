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

namespace SRIS.Application.WorkingStatusMaster.Queries.GetWorkingStatusMaster
{
    public class GetWorkingStatusQuery: IRequest<WorkingStatusVM>
    {
        public int statusid { get; set; }
    }
    public class GetWorkingStatusQueryHandler : IRequestHandler<GetWorkingStatusQuery, WorkingStatusVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetWorkingStatusQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkingStatusVM> Handle(GetWorkingStatusQuery request, CancellationToken cancellationToken)
        {
            return new WorkingStatusVM
            {
                Lists = await _context.m_master_workingstatus
                    .ProjectTo<WorkingStatusDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.statusname)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
