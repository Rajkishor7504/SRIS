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

namespace SRIS.Application.ContactTypeMaster.Commands.UpdateContactTypeMasterItem
{
  public  class UpdateContactTypeCommand : IRequest<int>
    {
        public int id { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
    }
    public class UpdateContactTypeCommandHandler : IRequestHandler<UpdateContactTypeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateContactTypeCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdateContactTypeCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_Contacttype.FindAsync(request.id);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(ContactType), request.Designation);
                }
                count = _context.m_master_Contacttype.Where(x => x.Designation == request.Designation && x.id != request.id && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.id != 0)
                    {

                        entity.Designation = request.Designation;
                        entity.Description = request.Description;
                        entity.updatedby = 1;
                        entity.updatedon = _dateTime.Now;
                        bool hasSpecialChars = rgx.IsMatch(entity.Designation);
                        if (entity.Description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.Description);
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
