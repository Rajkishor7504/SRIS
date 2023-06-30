using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using SRIS.Domain.Entities.MasterDepenciesEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.DocumentsTypeMasters.Commands.DeleteDocumentTypeMasterItem
{
   public class DeleteDocumentTypeMasterCommand : IRequest<int>
    {
        public int id { get; set; }
    }
    public class DeleteMasterCommandHandler : IRequestHandler<DeleteDocumentTypeMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteDocumentTypeMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_documentType.FindAsync(request.id);
            try
            {
                count = _context.t_hhr_identitydocuments.Where(x => x.documentid == request.id && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Identitydocuments), request.id);
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
        //public async Task<Unit> Handle(DeleteDocumentTypeMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_documentType.FindAsync(request.id);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(DocumentTypeMaster), request.id);
        //    }

        //    _context.m_master_documentType.Remove(entity);

        //    await _context.SaveChangesAsync(cancellationToken);

        //    return Unit.Value;
        //}

    }
}
