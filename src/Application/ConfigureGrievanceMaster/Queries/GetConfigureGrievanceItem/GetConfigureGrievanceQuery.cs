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

namespace SRIS.Application.ConfigureGrievanceMaster.Queries.GetConfigureGrievanceItem
{
    public class GetConfigureGrievanceQuery : IRequest<ConfigureGrievanceVM>
    {
    }
    public class GetConfigureGrievanceQueryHandler : IRequestHandler<GetConfigureGrievanceQuery, ConfigureGrievanceVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetConfigureGrievanceQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ConfigureGrievanceVM> Handle(GetConfigureGrievanceQuery request, CancellationToken cancellationToken)
        {
            return new ConfigureGrievanceVM
            {
                Lists = await _context.m_grievance_configuregrievance
                    .Where(x=>!x.deletedflag)
                    .ProjectTo<ConfigureGrievanceDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.grievanceconfigid)
                    .ToListAsync(cancellationToken)
            };
        }
    }

}

