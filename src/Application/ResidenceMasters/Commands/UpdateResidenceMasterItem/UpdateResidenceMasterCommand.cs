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

namespace SRIS.Application.ResidenceMasters.Commands.UpdateResidenceMasterItem
{
    public class UpdateResidenceMasterCommand : IRequest<int>
    {
        public int id { get; set; }
        public string residencename { get; set; }
        public string description { get; set; }
    }
    public class UpdateResidenceMasterCommandHandler : IRequestHandler<UpdateResidenceMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateResidenceMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateResidenceMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.M_Master_Residence.FindAsync(request.id);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(ResidenceMaster), request.residencename);
                }
                count = _context.M_Master_Residence.Where(x => x.residencename == request.residencename && x.id != request.id && x.deletedflag == false).Count();
                //count = _context..Where(x => x.residencename == request.residencename).Count();
                if (count == 0)
                {
                    if (request.id != 0)
                    {
                        entity.residencename = request.residencename;
                        entity.description = request.description;

                        bool hasSpecialChars = rgx.IsMatch(entity.residencename);
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
