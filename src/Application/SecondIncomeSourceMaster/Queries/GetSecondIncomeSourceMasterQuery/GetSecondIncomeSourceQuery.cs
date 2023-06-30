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

namespace SRIS.Application.SecondIncomeSourceMaster.Queries.GetSecondIncomeSourceMasterQuery
{
    public class GetSecondIncomeSourceQuery : IRequest<SecondIncomeSourceVM>
    {
        public int secondincomesourceid { get; set; }
    }
    public class GetSecondIncomeSourceQueryHandler : IRequestHandler<GetSecondIncomeSourceQuery, SecondIncomeSourceVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSecondIncomeSourceQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SecondIncomeSourceVM> Handle(GetSecondIncomeSourceQuery request, CancellationToken cancellationToken)
        {
            return new SecondIncomeSourceVM
            {
                Lists = await _context.m_master_second_incomesource
                    .ProjectTo<SecondIncomeSourceDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.secondincomesourcename)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
