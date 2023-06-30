/*
* File Name : GetRegisterMemberQuery.cs
* class Name : GetRegisterMemberQuery
* Created Date : 13th Aug 2021
* Created By : Spandana Ray
* Description : class grievance member register
*/
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Grievances.Queries.GetRegisterMember
{
    public class GetRegisterMemberQuery : IRequest<RegisterMemberVM>
    {

    }
    public class GetTodosQueryHandler : IRequestHandler<GetRegisterMemberQuery, RegisterMemberVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IGrievanceService _iGrievanceService;
        private readonly IMapper _mapper;

        public GetTodosQueryHandler(IApplicationDbContext context, IGrievanceService iGrievanceService, IMapper mapper)
        {
            _context = context;
            _iGrievanceService = iGrievanceService;
            _mapper = mapper;
        }

        #region "To get the grievance member register"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of GetRegisterMemberQuery</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To get the grievance member register</remarks>
        public async Task<RegisterMemberVM> Handle(GetRegisterMemberQuery request, CancellationToken cancellationToken)
        {
            return new RegisterMemberVM
            {
                Lists = await _iGrievanceService.GetRegisterMembers()
            };
        }
        #endregion
    }
}
