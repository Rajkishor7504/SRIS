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

namespace SRIS.Application.ServiceMasterItem.Queries.GetServicesMasterQueries
{
    public class ServicesMasterQuery : IRequest<ServicesMasterVM>
    {
        public int serviceid { get; set; }
    }
    public class ServicesMasterQueryHandler : IRequestHandler<ServicesMasterQuery, ServicesMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ServicesMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServicesMasterVM> Handle(ServicesMasterQuery request, CancellationToken cancellationToken)
        {
            return new ServicesMasterVM
            {
                Lists = await _context.m_master_services
                    .ProjectTo<ServicesMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deleteflag == false)
                    .OrderBy(t => t.servicename)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}


