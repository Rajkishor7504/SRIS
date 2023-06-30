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

namespace SRIS.Application.SurveyPlanning.SurveyTeamMasterItem.Query.GetSurveyTeamMasterItem
{
    public class GetSurveyTeamMasterQuery: IRequest<SurveyTeamMasterVM>
    {
        public int teamid { get; set; }
        public string action { get; set; }
        public int planid { get; set; }
        public int searchid { get; set; }
    }
    public class GetSurveyTeamMasterQueryHandler : IRequestHandler<GetSurveyTeamMasterQuery, SurveyTeamMasterVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ImyusersurveyteamdetailsService _imyustdService;

        public GetSurveyTeamMasterQueryHandler(IApplicationDbContext context, IMapper mapper, ImyusersurveyteamdetailsService imyustdService)
        {
            _context = context;
            _mapper = mapper;
            _imyustdService = imyustdService;
        }

        public async Task<SurveyTeamMasterVM> Handle(GetSurveyTeamMasterQuery request, CancellationToken cancellationToken)
        {
            var entity = new SurveyTeamMasterDto();
            entity.action = request.action;
            entity.planid = request.planid;
            entity.searchid = request.searchid;
            if (request.teamid == 0)
            {
                return new SurveyTeamMasterVM
                {
                    Lists = await _imyustdService.Getteamdetails(entity)
                };
            }
            else
            {
                return new SurveyTeamMasterVM
                {
                    Lists = await _context.m_survey_team.Join(_context.t_survey_teamdetail
                                              , st => st.teamid
                                              , std => std.teamid
                                              , (st, std) => new { st, std })
                                              .Join(_context.t_survey_surveyplanning
                                              , st1 => st1.st.surveyplanid
                                              , sp => sp.planid
                                              , (st1, sp) => new { st1,st1.std, sp })
                                               .Join(_context.m_um_user
                                              , std1 => std1.std.userid
                                              , umu => umu.Id
                                              , (std1, umu) => new { std1, umu, std1.st1, std1.st1.std, std1.sp })
                                              .Where(s => s.st1.st.teamid == request.teamid)
                                                              .Select(s => new SurveyTeamMasterDto
                                                              {
                                                                  teamid=s.st1.st.teamid,
                                                                  surveyplanid=s.st1.st.surveyplanid,
                                                                  teamname=s.st1.st.teamname,
                                                                  description=s.st1.st.description,
                                                                  surveyname=s.sp.surveyname,
                                                                  teamdetailid=s.st1.std.teamdetailid,
                                                                  userid=s.st1.std.userid,
                                                                  usettypeid=s.st1.std.usettypeid,
                                                                  userfullname=s.umu.userfullname,
                                                                  usertypename = s.st1.std.usettypeid==1?"Enumerator":"Supervisor",
                                                                  deletedflag=s.st1.std.deletedflag,
                                                              })
                      .OrderBy(t => t.teamdetailid)
                      .Where(x => x.deletedflag == false)
                      .ToListAsync(cancellationToken)
                };
            }
        }

    }
}
