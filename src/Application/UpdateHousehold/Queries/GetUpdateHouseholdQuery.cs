using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.UpdateHousehold.Queries
{
   public class GetUpdateHouseholdQuery : IRequest<UpdatehouseholdVM>
    {
        public string action { get; set; }
        public string hhnumber { get; set; }
        public string hholdnumber { get; set; }
        public int parentid { get; set; }
        public int householdid { get; set; }

    }
    public class GetUpdateHouseholdQueryHandler : IRequestHandler<GetUpdateHouseholdQuery, UpdatehouseholdVM>
    {
        private readonly IUpdateHouseholdService _iUpdateHouseholdService;
        private readonly IMapper _mapper;

        public GetUpdateHouseholdQueryHandler(IUpdateHouseholdService iUpdateHouseholdService, IMapper mapper)
        {
            _iUpdateHouseholdService = iUpdateHouseholdService;
            _mapper = mapper;
        }

        public async Task<UpdatehouseholdVM> Handle(GetUpdateHouseholdQuery request, CancellationToken cancellationToken)
        {
            var entity = new UpdateHouseholdDto();
            entity.action = request.action;
            entity.hhnumber = request.hhnumber;
            entity.hholdnumber = request.hholdnumber;
            entity.p_id = request.parentid;
            return new UpdatehouseholdVM
            {
                Lists = await _iUpdateHouseholdService.GetHouseholdDetails(entity)
            };
        }
    }

}
