using AutoMapper;
using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Common;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Household.Registerhousehold.Queries.GetRegisterHousehold
{
    public class GetLocationQuery : IRequest<string>
    {

        public int locationid { get; set; }

    }
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, string>
    {
        private readonly IHouseholdService _iHouseholdService;
        private readonly IMapper _mapper;

        public GetLocationQueryHandler(IHouseholdService iHouseholdService, IMapper mapper)
        {
            _iHouseholdService = iHouseholdService;
            _mapper = mapper;
        }

        public async Task<string> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            string locations = "";
            try
            {

                locations = await _iHouseholdService.GetAllParentLocation(request.locationid);


            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return locations.TrimStart('-').TrimStart('>');


        }
    }
}
