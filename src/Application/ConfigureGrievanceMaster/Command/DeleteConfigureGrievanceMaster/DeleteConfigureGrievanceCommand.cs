using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ConfigureGrievanceMaster.Command.DeleteConfigureGrievanceMaster
{
    public class DeleteConfigureGrievanceCommand : IRequest<int>
    {
        public int grievanceconfigid { get; set; }
    }
    public class DeleteConfigureGrievanceCommandHandler : IRequestHandler<DeleteConfigureGrievanceCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteConfigureGrievanceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteConfigureGrievanceCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_grievance_configuregrievance.FindAsync(request.grievanceconfigid);

            //if (entity == null)
            //{
            //    throw new NotFoundException(nameof(ConfigureGrievance), request.grievanceconfigid);
            //}
            //entity.deletedflag = true;
            //return await _context.SaveChangesAsync(cancellationToken);
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.t_grievance_registration.Where(x => x.grievanceconfigid == request.grievanceconfigid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(ConfigureGrievance), request.grievanceconfigid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    entity.updatedby = 1;
                    entity.deletedflag = true;
                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 200;
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            //return Unit.Value;
            return retval;
        }
    }
    }

