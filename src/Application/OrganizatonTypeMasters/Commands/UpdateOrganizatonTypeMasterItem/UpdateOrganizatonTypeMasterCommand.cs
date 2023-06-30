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

namespace SRIS.Application.OrganizatonTypeMasters.Commands.UpdateOrganizatonTypeMasterItem
{
    public class UpdateOrganizatonTypeMasterCommand : IRequest<int>
    {
        public int organizationtypeid { get; set; }
        public string organizationtypename { get; set; }
        public string description { get; set; }
    }
    public class UpdateOrganizatonTypeMasterCommandHandler : IRequestHandler<UpdateOrganizatonTypeMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateOrganizatonTypeMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateOrganizatonTypeMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_organizatontype.FindAsync(request.organizationtypeid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(OrganizatonType), request.organizationtypename);
                }
                count = _context.m_master_organizatontype.Where(x => x.organizationtypename == request.organizationtypename && x.organizationtypeid != request.organizationtypeid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.organizationtypeid != 0)
                    {
                        entity.organizationtypename = request.organizationtypename;
                        entity.description = request.description;
                        bool hasSpecialChars = rgx.IsMatch(entity.organizationtypename);
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