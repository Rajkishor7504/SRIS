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

namespace SRIS.Application.NationalityMasters.Commands.UpdateNationalityMasterItem
{
     public class UpdateNationalityMasterCommand : IRequest<int>
    {
        public int nationalityid { get; set; }
        public string nationality { get; set; }
        public string description { get; set; }
    }
    public class UpdateNationalityMasterCommandHandler : IRequestHandler<UpdateNationalityMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateNationalityMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateNationalityMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_nationalitytbl.FindAsync(request.nationalityid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(NationalityMaster), request.nationality);
                }
                count = _context.m_master_nationalitytbl.Where(x => x.nationality == request.nationality && x.nationalityid != request.nationalityid && x.deletedflag == false).Count();
                //count = _context.m_master_nationalitytbl.Where(x => x.nationality == request.nationality).Count();
                if (count == 0)
                {
                    if (request.nationalityid != 0)
                    {
                        entity.nationality = request.nationality;
                        entity.description = request.description;
                        bool hasSpecialChars = rgx.IsMatch(entity.nationality);
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
