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

namespace SRIS.Application.OrganizatonTypeMasters.Commands.CreateOrganizatonTypeMasterList
{
   public class CreateOrganizatonTypeMasterCommand : IRequest<int>
    {
        public int organizationtypeid { get; set; }
        public string organizationtypename { get; set; }
        public string description { get; set; }
    }
    public class CreateEthnicityMasterCommandHandler : IRequestHandler<CreateOrganizatonTypeMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateEthnicityMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateOrganizatonTypeMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new OrganizatonType();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_organizatontype.Where(x => x.organizationtypename == request.organizationtypename && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.organizationtypeid == 0)
                    {
                        entity.organizationtypename = request.organizationtypename;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.organizationtypeid = request.organizationtypeid;
                        bool hasSpecialChars = rgx.IsMatch(entity.organizationtypename);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_organizatontype.Add(entity);
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

                            _context.m_master_organizatontype.Add(entity);
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
