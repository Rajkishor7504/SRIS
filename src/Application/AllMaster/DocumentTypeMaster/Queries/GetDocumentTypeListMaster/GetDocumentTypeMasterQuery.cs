using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AllMaster.DocumentTypeMaster.Queries.GetDocumentTypeListMaster
{
   public class GetDocumentTypeMasterQuery : IRequest<DocumentTypeMasterVM>
    {
        public int id { get; set; }
    }
    public class GetDocumentTypeQueryHandler : IRequestHandler<GetDocumentTypeMasterQuery, DocumentTypeMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDocumentTypeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region "To get the DocumentType records"

        public async Task<DocumentTypeMasterVM> Handle(GetDocumentTypeMasterQuery request, CancellationToken cancellationToken)
        {
            DocumentTypeMasterVM model = new DocumentTypeMasterVM();
            model.Lists = await _context.m_master_documentType.Where(g => !g.deletedflag)
             .Select(a => new DocumentTypeMasterDto { id = a.id, name = a.documentType })
              .OrderBy(t => t.name)
              .ToListAsync(cancellationToken);

            return model;
        }
        #endregion
    }
}
