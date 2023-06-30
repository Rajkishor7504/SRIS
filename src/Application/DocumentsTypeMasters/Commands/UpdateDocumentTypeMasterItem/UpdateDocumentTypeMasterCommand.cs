using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.DocumentsTypeMasters.Commands.UpdateDocumentTypeMasterItem
{
    public class UpdateDocumentTypeMasterCommand : IRequest<int>
    {
        public int id { get; set; }
        public string documentType { get; set; }
        public string description { get; set; }
        public class UpdateDocumentTypeMasterCommandHandler : IRequestHandler<UpdateDocumentTypeMasterCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateDocumentTypeMasterCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateDocumentTypeMasterCommand request, CancellationToken cancellationToken)
            {
                Regex rgx = new Regex("[^A-Za-z ]");
                int count = 0;
                int retval = 0;
                try
                {
                    var entity = await _context.m_master_documentType.FindAsync(request.id);
               
               
                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(DocumentTypeMaster), request.documentType);
                    }
                    count = _context.m_master_documentType.Where(x => x.documentType == request.documentType && x.id != request.id && x.deletedflag == false).Count();
                    if (count == 0)
                    //count = _context.m_master_documentType.Where(x => x.documentType == request.documentType).Count();
                    //if (count == 0)
                    {
                        if (request.id != 0)
                        {
                            entity.documentType = request.documentType;
                            entity.description = request.description;
                            bool hasSpecialChars = rgx.IsMatch(entity.documentType);
                            if (entity.description != null)
                            {
                                bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                                if (hasSpecialChars == false && hasSpecialChars1 == false)
                                {
                                    await _context.SaveChangesAsync(cancellationToken);
                                    retval = 2;
                                }
                                else
                                {
                                    retval = 403;
                                }
                            }

                            else if (hasSpecialChars == false)
                            {

                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 2;
                            }
                            else
                            {
                                retval = 403;
                            }
                        }
                    }
                    else
                    {
                        retval = 3;
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
}
