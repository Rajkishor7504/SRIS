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

namespace SRIS.Application.MasterModuleItem.Queries.GetMastermoduleQueries
{
    public class GetMasterModuleQuery: IRequest<MasterModuleVM>
    {
        public int moduleid { get; set; }
    }
    public class GetConfigureGrievanceQueryHandler : IRequestHandler<GetMasterModuleQuery, MasterModuleVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetConfigureGrievanceQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MasterModuleVM> Handle(GetMasterModuleQuery request, CancellationToken cancellationToken)
        {
            return new MasterModuleVM
            {
                Lists = await _context.m_master_module
                    .ProjectTo<MasterModuleDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.moduleid)
                    .ToListAsync(cancellationToken)
            };
        }
    }

}
