/*
* File Name : GetConfigurePositionQuery.cs
* class Name : GetConfigurePositionQuery
* Created Date : 25 Aug 2021
* Created By : Spandana Ray
* Description : Get Configure Position
*/
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Grievances.Queries.GetConfigurePosition
{
    public class GetConfigurePositionQuery : IRequest<ConfigurePositionVM>
    {

    }
    public class GetTodosQueryHandler : IRequestHandler<GetConfigurePositionQuery, ConfigurePositionVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodosQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region "Get Configure Position"
        ///<summary>
        /// Created By Spandana Ray on 25/08/2021
        /// </summary>
        /// <parameter>Request Object of GetConfigurePositionQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>Get Configure Position</remarks>
        public async Task<ConfigurePositionVM> Handle(GetConfigurePositionQuery request, CancellationToken cancellationToken)
        {
            return new ConfigurePositionVM
            {
                Lists = await _context.m_grievance_configureposition
                .Where(g => !g.deletedflag)
                    .ProjectTo<ConfigurePositionDto>(_mapper.ConfigurationProvider)                    
                    .ToListAsync(cancellationToken)
            };
        }
        #endregion
    }
}
