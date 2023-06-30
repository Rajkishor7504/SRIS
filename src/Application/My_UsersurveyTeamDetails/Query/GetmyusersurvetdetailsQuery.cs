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

namespace SRIS.Application.My_UsersurveyTeamDetails.Query
{
    public class GetmyusersurvetdetailsQuery: IRequest<My_usersurveyTeamdetailsVM>
    {
        public int id { get; set; }
        public string action { get; set; }
    }
    public class GetmyusersurvetdetailsQueryHandler : IRequestHandler<GetmyusersurvetdetailsQuery, My_usersurveyTeamdetailsVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ImyusersurveyteamdetailsService _imyustdService;
        public GetmyusersurvetdetailsQueryHandler(IApplicationDbContext context, IMapper mapper, ImyusersurveyteamdetailsService imyustdService)
        {
            _context = context;
            _mapper = mapper;
            _imyustdService = imyustdService;
        }

        public async Task<My_usersurveyTeamdetailsVM> Handle(GetmyusersurvetdetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = new My_usersurveyTeamdetailsDto();
            entity.action = request.action;
            

            //if (request.registrationid == 0)
            //{
                return new My_usersurveyTeamdetailsVM
                {
                    Lists = await _imyustdService.Getmusurveydetails(entity)

                };
            //}
        }
    }

}

