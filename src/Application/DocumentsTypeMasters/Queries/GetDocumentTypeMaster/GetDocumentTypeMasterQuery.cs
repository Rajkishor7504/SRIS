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

namespace SRIS.Application.DocumentsTypeMasters.Queries.GetDocumentTypeMaster
{
    public class GetDocumentTypeMasterQuery : IRequest<DocumentTypeMasterVM>
    {
        public int id { get; set; }
    }
    public class GetDocumentTypeMasterQueryHandler : IRequestHandler<GetDocumentTypeMasterQuery, DocumentTypeMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDocumentTypeMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DocumentTypeMasterVM> Handle(GetDocumentTypeMasterQuery request, CancellationToken cancellationToken)
        {
            return new DocumentTypeMasterVM
            {
                Lists = await _context.m_master_documentType
                    .ProjectTo<DocumentTypeMasterDto>(_mapper.ConfigurationProvider)
                    .Where(t => t.deletedflag == false)
                    .OrderBy(t => t.documentType)
                    .ToListAsync(cancellationToken)
            };
        }

    }
}
