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

namespace SRIS.Application.MaritalStatusMaster.Queries.GetMaritalStatusListMaster
{
   public class GetMaritalStatusMasterQuery : IRequest<MaritalStatusMasterVM>
    {
        public int maritalstatusid { get; set; }
    }
    public class GetMaritalStatusQueryHandler : IRequestHandler<GetMaritalStatusMasterQuery, MaritalStatusMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMaritalStatusQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region "To get the Marital Statusrecords"
        ///<summary>
        /// Created By Rajalaxmi Behera on 09/06/2021
        /// </summary>
        /// <parameter>Request Object of GetMaritalStatusMasterQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To get the Marital Status records</remarks>
        public async Task<MaritalStatusMasterVM> Handle(GetMaritalStatusMasterQuery request, CancellationToken cancellationToken)
        {
            MaritalStatusMasterVM model = new MaritalStatusMasterVM(); 
            model.Lists = await _context.m_master_maritalstatus.Where(g => !g.deletedflag)
             .Select(a => new MaritalStatusMasterDto {maritalstatusid=a.maritalstatusid,maritalstatusname=a.maritalstatusname })
              .OrderBy(t => t.maritalstatusname)
              .ToListAsync(cancellationToken);

            return model;
        }
        #endregion
    }
}
