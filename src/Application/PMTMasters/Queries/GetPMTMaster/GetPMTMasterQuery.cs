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

namespace SRIS.Application.PMTMasters.Queries.GetPMTMaster
{
   public class GetPMTMasterQuery : IRequest<PMTMasterVM>
    {
        public int categoryid { get; set; }
       

    }
    public class GetPMTMasterQueryHandler : IRequestHandler<GetPMTMasterQuery, PMTMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPMTMasterQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public async Task<List<PMTMasterVM>> Handle(GetPMTMasterQuery request, CancellationToken cancellationToken)
        //{
        //    List<PMTMasterVM> list = new List<PMTMasterVM>();
        //    if (request.pmtid == 0)
        //    {
        //        list = await _context.m_master_pmt
        //       .Join(_context.m_master_quantile
        //       , pmt => pmt.categoryid
        //       , qm => qm.id
        //       , (pmt, qm) => new { pmt, qm })


        //       .Select(s => new PMTMasterVM
        //       {
        //           pmtid = s.pmt.pmtid,
        //           categoryid = s.pmt.categoryid,
        //           topcutoff = s.pmt.topcutoff,
        //           buttomcutoff = s.pmt.buttomcutoff,
        //           id = s.qm.id,
        //           quantile = s.qm.quantile

        //       })
        //      .OrderBy(o => o.pmtid)
        //       .ToListAsync(cancellationToken);
        //    }
        //    else
        //    {
        //        list = await _context.m_master_pmt
        //        .Join(_context.m_master_quantile
        //        , pmt => pmt.categoryid
        //        , qm => qm.id
        //        , (pmt, qm) => new { pmt, qm }).Where(x => x.pmt.pmtid == request.pmtid)


        //        .Select(s => new PMTMasterVM
        //        {
        //            pmtid = s.pmt.pmtid,
        //            categoryid = s.pmt.categoryid,
        //            topcutoff = s.pmt.topcutoff,
        //            buttomcutoff = s.pmt.buttomcutoff,
        //            id = s.qm.id,
        //            quantile = s.qm.quantile

        //        })
        //       .OrderBy(o => o.pmtid)
        //        .ToListAsync(cancellationToken);
        //    }


        //    return list;
        //}
        public async Task<PMTMasterVM> Handle(GetPMTMasterQuery request, CancellationToken cancellationToken)
        {
            return new PMTMasterVM
            {
                Lists = await _context.m_pmt_category
                    .ProjectTo<PMTMasterDto>(_mapper.ConfigurationProvider)
                     .Where(t => !t.deletedflag)
                    .OrderBy(t => t.category)
                    .ToListAsync(cancellationToken)
            };
        }
    }

}
