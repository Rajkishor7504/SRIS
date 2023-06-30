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

namespace SRIS.Application.WorkingFrequencyMasters.Queries.GetWorkingFrequencyMaster
{
    public class GetWorkingFrequencyQuery : IRequest<WorkingFrequencyVM>
    {
        public int id { get; set; }
    }
    public class GetWorkingFrequencyQueryHandler : IRequestHandler<GetWorkingFrequencyQuery, WorkingFrequencyVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetWorkingFrequencyQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkingFrequencyVM> Handle(GetWorkingFrequencyQuery request, CancellationToken cancellationToken)
        {
            return new WorkingFrequencyVM
            {
                Lists = await _context.m_master_workingfreequency
                    .ProjectTo<WorkingFrequencyDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.name)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
