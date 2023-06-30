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

namespace SRIS.Application.AllMaster.NationalityMaster.Queries.GetNationalityListMaster
{
  public  class GetNationalityMasterQuery : IRequest<NationalityMasterVM>
    {
        public int id { get; set; }    
}
    public class GetNationalityQueryHandler : IRequestHandler<GetNationalityMasterQuery, NationalityMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetNationalityQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region "To get the Nationality records"

        public async Task<NationalityMasterVM> Handle(GetNationalityMasterQuery request, CancellationToken cancellationToken)
        {
            NationalityMasterVM model = new NationalityMasterVM();
            model.Lists = await _context.m_master_nationality.Where(g => !g.deletedflag)
             .Select(a => new NationalityMasterDto { id = a.nationalityid, name = a.nationality })
              .OrderBy(t => t.name)
              .ToListAsync(cancellationToken);

            return model;
        }
        #endregion
    }
}
