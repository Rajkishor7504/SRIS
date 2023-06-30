using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.Grievances.Commands.AssignSurveyManager.UpdateAssignSurveyManagerCommand
{
    public class UpdateAssignSurveyManagerCommand : IRequest<int>
    {
        public int pkid { get; set; }
        public int createdby { get; set; }
        public string remarks { get; set; }
    }
    public class UpdateAssignSurveyManagerCommandHandler : IRequestHandler<UpdateAssignSurveyManagerCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAssignSurveyManagerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateAssignSurveyManagerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.t_grievance_assignsurveymanager.FindAsync(request.pkid);
            int retval = 0;
            if (entity == null)
            {
                throw new NotFoundException(nameof(GlobalLinkMaster), request.pkid);
            }            
            try
            {
                entity.pkid = request.pkid;
                entity.remarks = request.remarks;
                entity.remarksgivenby = request.createdby;
                entity.updatedby = request.createdby;
                entity.updatedon = DateTime.Now;
                entity.remarksgivendate = DateTime.Now;
                entity.status = 1;
                _context.t_grievance_assignsurveymanager.Update(entity);

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
