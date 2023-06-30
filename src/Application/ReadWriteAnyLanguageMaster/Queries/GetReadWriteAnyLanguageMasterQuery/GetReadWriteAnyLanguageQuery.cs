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

namespace SRIS.Application.ReadWriteAnyLanguageMaster.Queries.GetReadWriteAnyLanguageMasterQuery
{
    public class GetReadWriteAnyLanguageQuery : IRequest<ReadWriteAnyLanguageMasterVM>
    {
        public int readwriteid { get; set; }
    }
    public class GetReadWriteAnyLanguageQueryHandler : IRequestHandler<GetReadWriteAnyLanguageQuery, ReadWriteAnyLanguageMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetReadWriteAnyLanguageQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadWriteAnyLanguageMasterVM> Handle(GetReadWriteAnyLanguageQuery request, CancellationToken cancellationToken)
        {
            return new ReadWriteAnyLanguageMasterVM
            {
                Lists = await _context.m_master_readwriteanylanguage
                    .ProjectTo<ReadWriteAnyLanguageMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.typeofreadwrite)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
