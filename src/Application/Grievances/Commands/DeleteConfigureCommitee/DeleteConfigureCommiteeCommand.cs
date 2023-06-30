using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ConfigureCommiteeMasterItems.Commands.DeleteConfigureCommitee
{
    public class DeleteConfigureCommiteeCommand:IRequest<int>
    {
        public int configureid { get; set; }
        public int createdby { get; set; }
    }
    public class DeleteConfigureCommiteeCommandHandler : IRequestHandler<DeleteConfigureCommiteeCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteConfigureCommiteeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteConfigureCommiteeCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_grievance_configurecomittee.FindAsync(request.configureid);
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(ConfigureCommitee), request.configureid);
                }
                count = _context.m_grievance_registermember.Where(x => x.comitteid == request.configureid && !x.deletedflag).Count();
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    entity.deletedflag = true;                    
                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 200;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return retval;
        }
    }
}
