using MediatR;
using SRIS.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.AssignSurveyManagerMaster.Command.DeleteAssignSurveyManagerMaster
{
    public class DeleteAssignSurveyManagerCommand: IRequest<int>
    {
        public int assignmanagerid { get; set; }
    }
    public class DeleteAssignSurveyManagerCommandHandler : IRequestHandler<DeleteAssignSurveyManagerCommand, int>
    {
        private readonly IAssignSurveyManagerService _iAssignSurveymanagerService;
        //private readonly IApplicationDbContext _context;
        public DeleteAssignSurveyManagerCommandHandler(IAssignSurveyManagerService iAssignSurveymanagerService)
        {
            _iAssignSurveymanagerService = iAssignSurveymanagerService;
            //_context = context;
        }

        //public Task<Unit> Handle(DeleteSurveyTeamMasterCommand request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<int> Handle(DeleteAssignSurveyManagerCommand request, CancellationToken cancellationToken)
        {
            int retval = 0;
            //var entity = await _context.m_survey_team.FindAsync(request.teamid);

            //var entity1 = _context.t_survey_teamdetail.Where(s => s.teamid == request.teamid).ToList();

            //if (entity == null)
            //{
            //    throw new NotFoundException(nameof(SurveyTeamMaster), request.teamid);
            //}

            retval = await _iAssignSurveymanagerService.deletesurveymanag(request.assignmanagerid);

            return retval;
        }
    }
}

