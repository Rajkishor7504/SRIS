using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Grievances.Commands.AssignSurveyManager.CreateAssignSurveyManagerCommand
{
    public class CreateAssignSurveyManagerCommand : IRequest<int>
    {
        public int grievanceid { get; set; }
        public int planid { get; set; }
        public string surveymanager { get; set; }
        public string surveyname { get; set; }
        public int surveymanagerid { get; set; }
        public int status { get; set; }
        public int createdby { get; set; }
    }
    public class CreateAssignSurveyManagerCommandHandler : IRequestHandler<CreateAssignSurveyManagerCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAssignSurveyManagerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAssignSurveyManagerCommand request, CancellationToken cancellationToken)
        {
            var entity = new GrievanceAssignSurveyManager();
            int retval = 0;
            try
            {
                entity.grievanceid = request.grievanceid;
                entity.planid = request.planid;
                entity.surveymanager = request.surveymanager;
                entity.surveyname = request.surveyname;
                entity.surveymanagerid = request.surveymanagerid;
                entity.status = request.status;
                entity.createdby = request.createdby;
                entity.createdon = DateTime.Now;
                _context.t_grievance_assignsurveymanager.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
                retval = 1;
            }
            catch (Exception ex)
            {
                
            }
            return retval;
        }
    }
}
