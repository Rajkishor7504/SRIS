using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using SRIS.Domain.Entities.SurveyPlanning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.SurveyTeamMasterItem.Command.DeleteSurveyTeamMasterItem
{
    public class DeleteSurveyTeamMasterCommand:IRequest<int>
    {
        public int teamid { get; set; }
    }
    public class DeleteSurveyTeamMasterCommandHandler : IRequestHandler<DeleteSurveyTeamMasterCommand,int>
    {
        private readonly ImyusersurveyteamdetailsService _iMyusteamService;
        private readonly IApplicationDbContext _context;
        public DeleteSurveyTeamMasterCommandHandler(ImyusersurveyteamdetailsService iMyusteamService, IApplicationDbContext context)
        {
            _iMyusteamService = iMyusteamService;
            _context = context;
        }

        //public Task<Unit> Handle(DeleteSurveyTeamMasterCommand request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<int> Handle(DeleteSurveyTeamMasterCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            var entity = await _context.m_survey_team.FindAsync(request.teamid);

            var entity1 = _context.t_survey_teamdetail.Where(s => s.teamid == request.teamid).ToList();


            if (entity == null)
            {
                throw new NotFoundException(nameof(SurveyTeamMaster), request.teamid);
            }

            retval = await _iMyusteamService.deleteTeam(request.teamid);

            return retval;
        }
    }
}

