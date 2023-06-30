using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ContactTypeMaster.Commands.CreateContactTypeMasterItem
{
   public class CreateContactTypeCommand : IRequest<int>
    {
        public int id { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
    }
    public class CreateContactTypeCommandHandler : IRequestHandler<CreateContactTypeCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public CreateContactTypeCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(CreateContactTypeCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new ContactType();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_Contacttype.Where(x => x.Designation == request.Designation && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.id == 0)
                    {

                        entity.Designation = request.Designation;
                        entity.Description = request.Description;
                        entity.createdby = 1;
                        entity.createdon = _dateTime.Now;
                        entity.deletedflag = false;
                        entity.id = request.id;
                        bool hasSpecialChars = rgx.IsMatch(entity.Designation);
                        if (entity.Description != "")
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.Description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_Contacttype.Add(entity);
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 1;
                            }
                            else
                            {
                                retval = 403;
                            }
                        }

                        else if (hasSpecialChars == false)
                        {

                            _context.m_master_Contacttype.Add(entity);
                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 1;
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
