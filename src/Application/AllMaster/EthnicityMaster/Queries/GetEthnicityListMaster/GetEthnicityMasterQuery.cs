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

namespace SRIS.Application.AllMaster.EthnicityMaster.Queries.GetEthnicityListMaster
{
   public class GetEthnicityMasterQuery : IRequest<EthnicityMasterVM>
    {
        public int id { get; set; }
    }
    public class GetEthnicityQueryHandler : IRequestHandler<GetEthnicityMasterQuery, EthnicityMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEthnicityQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region "To get the DocumentType records"

        public async Task<EthnicityMasterVM> Handle(GetEthnicityMasterQuery request, CancellationToken cancellationToken)
        {
            EthnicityMasterVM model = new EthnicityMasterVM();
            model.Lists = await _context.m_master_ethnicity.Where(g => !g.deletedflag)
             .Select(a => new EthnicityMasterDto { id = a.ethnicityid, name = a.ethnicityname })
              .OrderBy(t => t.name)
              .ToListAsync(cancellationToken);

            return model;
        }
        #endregion
    }
}
