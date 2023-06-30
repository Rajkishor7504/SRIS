using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterDepenciesEntities;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.OrganizatonTypeMasters.Commands.DeleteOrganizatonTypeMasterItem
{
    public class DeleteOrganizatonTypeMasterCommand : IRequest<int>
    {
        public int organizationtypeid { get; set; }
    }
    public class DeleteOrganizatonTypeMasterCommandHandler : IRequestHandler<DeleteOrganizatonTypeMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteOrganizatonTypeMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteOrganizatonTypeMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_organizatontype.FindAsync(request.organizationtypeid);
            try
            {
                count = _context.t_hhr_incomeorgdetail.Where(x => x.orgtype == request.organizationtypeid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Incomeorgdetail), request.organizationtypeid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    //_context.m_master_organizatontype.Remove(entity);
                    //await _context.SaveChangesAsync(cancellationToken);
                    entity.updatedby = 1;
                    entity.deletedflag = true;
                    entity.updatedon = DateTime.Now;
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
        //public async Task<Unit> Handle(DeleteOrganizatonTypeMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_organizatontype.FindAsync(request.organizationtypeid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(OrganizatonType), request.organizationtypeid);
        //    }

        //    _context.m_master_organizatontype.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}