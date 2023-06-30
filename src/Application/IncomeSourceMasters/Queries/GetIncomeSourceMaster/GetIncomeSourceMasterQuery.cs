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

namespace SRIS.Application.IncomeSourceMasters.Queries.GetIncomeSourceMaster
{
    public class GetIncomeSourceMasterQuery : IRequest<IncomeSourceMasterVM>
    {
        public int incomesourceid { get; set; }
    }
    public class GetIncomeSourceMasterQueryHandler : IRequestHandler<GetIncomeSourceMasterQuery, IncomeSourceMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetIncomeSourceMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IncomeSourceMasterVM> Handle(GetIncomeSourceMasterQuery request, CancellationToken cancellationToken)
        {
            return new IncomeSourceMasterVM
            {
                Lists = await _context.m_master_incomesource
                    .ProjectTo<IncomeSourceMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.incomesourcename)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
