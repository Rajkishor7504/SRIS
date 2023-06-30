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

namespace SRIS.Application.ResidenceStatusMaster.Queries.GetResidenceStatusList
{
   public class GetResidenceStatusQuery : IRequest<ResidenceStatusVM>
    {
        public int id { get; set; }
    
}
    public class GetResidenceStatusQueryHandler : IRequestHandler<GetResidenceStatusQuery, ResidenceStatusVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetResidenceStatusQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region "To get the Residence Status records"

        public async Task<ResidenceStatusVM> Handle(GetResidenceStatusQuery request, CancellationToken cancellationToken)
        {
            ResidenceStatusVM model = new ResidenceStatusVM();
            model.Lists = await _context.m_master_residencestatus.Where(g => !g.deletedflag)
             .Select(a => new ResidenceStatusDto { id = a.residencestatusid, name = a.residencestatusname })
              .OrderBy(t => t.name)
              .ToListAsync(cancellationToken);

            return model;
        }
        #endregion
    }
}
