using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ReadWriteAnyLanguageMaster.Commands.UpdateReadWriteAnyLangugeMasterItem
{
    public class UpdateReadWriteAnyLangugeCommand : IRequest<int>
    {
        public int readwriteid { get; set; }
        public string typeofreadwrite { get; set; }
        public string description { get; set; }
    }
    public class UpdateReadWriteAnyLangugeCommandHandler : IRequestHandler<UpdateReadWriteAnyLangugeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateReadWriteAnyLangugeCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdateReadWriteAnyLangugeCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_readwriteanylanguage.FindAsync(request.readwriteid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(ReadWriteAnyLanguageMasterEntity), request.typeofreadwrite);
                }
                count = _context.m_master_readwriteanylanguage.Where(x => x.typeofreadwrite == request.typeofreadwrite && x.readwriteid != request.readwriteid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.readwriteid != 0)
                    {
                        entity.typeofreadwrite = request.typeofreadwrite;
                        entity.description = request.description;
                        entity.updatedby = 1;
                        entity.updatedon = _dateTime.Now;

                        bool hasSpecialChars = rgx.IsMatch(entity.typeofreadwrite);
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
