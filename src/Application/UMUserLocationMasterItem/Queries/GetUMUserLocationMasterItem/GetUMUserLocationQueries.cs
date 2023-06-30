using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.UMUserLocationMasterItem.Queries.GetUMUserLocationMasterItem
{
    public class GetUMUserLocationQueries : IRequest<UMUserLocationVM>
    {
        public int userlocid { get; set; }
        public string action { get; set; }
        public int parentid { get; set; }
        public int userid { get; set; }
    }
    public class GetUMUserLocationQueriesHandler : IRequestHandler<GetUMUserLocationQueries, UMUserLocationVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserLocationService _iuserlocation;

        public GetUMUserLocationQueriesHandler(IApplicationDbContext context, IMapper mapper, IUserLocationService iuserlocation)
        {
            _context = context;
            _mapper = mapper;
            _iuserlocation = iuserlocation;
        }

        public async Task<UMUserLocationVM> Handle(GetUMUserLocationQueries request, CancellationToken cancellationToken)
        {
            var entity = new UMUserLocationDto();
            entity.action = request.action;
            entity.p_id = request.parentid;
            //entity.userid = request.userid;

            if (request.userid == 0)
            {
                return new UMUserLocationVM
                {
                    Lists = await _iuserlocation.Getuserlocation(entity)

                };
            }
            else
            {
                return new UMUserLocationVM
                {
                    Lists = await _iuserlocation.GetuserlocationByID(request.userid)

                };
            }
        }
    }
}
