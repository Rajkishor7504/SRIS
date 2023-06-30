/*
* File Name : GetGlobalLinkMasterQuery.cs
* class Name : GetGlobalLinkMasterQuery, GetTodosQueryHandler
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : Query to get the global link records
*/

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GlobalLinkMasters.Queries.GetGlobalLinkMaster
{
    public class GetGlobalLinkMasterQuery : IRequest<GlobalLinkMasterVM>
    {
        public int glinkid { get; set; }
    }

    public class GetTodosQueryHandler : IRequestHandler<GetGlobalLinkMasterQuery, GlobalLinkMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region "To get the global link records"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of CreateGlobalLinkMasterCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To get the global link records</remarks>
        public async Task<GlobalLinkMasterVM> Handle(GetGlobalLinkMasterQuery request, CancellationToken cancellationToken)
        {
            return new GlobalLinkMasterVM
            {
                Lists = await _context.m_adm_globallink
                .Where(g => !g.deletedflag)
                    .ProjectTo<GlobalLinkMasterDto>(_mapper.ConfigurationProvider)
                    .OrderBy(o=>o.MenuOrder)
                    .ThenBy(t => t.glinkname)
                    .ToListAsync(cancellationToken)
            };
        }
        #endregion
    }
}
