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

namespace SRIS.Application.ConfigureCommiteeMasterItems.Queries.GetConfigureCommitee
{
   public class GetConfigureCommiteeQuery : IRequest<ConfigureCommiteeVM>
    {
        public int configureid { get; set; }
    }
    public class GetConfigureCommiteeQueryHandler : IRequestHandler<GetConfigureCommiteeQuery, ConfigureCommiteeVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetConfigureCommiteeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ConfigureCommiteeVM> Handle(GetConfigureCommiteeQuery request, CancellationToken cancellationToken)
        {
            try
            { 
            return new ConfigureCommiteeVM
            {
                Lists = await _context.m_grievance_configurecomittee
                    .ProjectTo<ConfigureCommiteeDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.commiteename)
                    .ToListAsync(cancellationToken)
            };
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
