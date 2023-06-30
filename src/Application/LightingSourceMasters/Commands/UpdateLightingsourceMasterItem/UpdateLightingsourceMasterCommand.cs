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

namespace SRIS.Application.LightingSourceMasters.Commands.UpdateLightingsourceMasterItem
{
    public class UpdateLightingsourceMasterCommand : IRequest<int>
    {
        public int sourceid { get; set; }
        public string sourcename { get; set; }
        public string description { get; set; }
    }
    public class UpdateLightingsourceMasterCommandHandler : IRequestHandler<UpdateLightingsourceMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateLightingsourceMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateLightingsourceMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_lightingsource.FindAsync(request.sourceid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(LightingSource), request.sourcename);
                }
                count = _context.m_master_lightingsource.Where(x => x.sourcename == request.sourcename && x.sourceid != request.sourceid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.sourceid != 0)
                    {
                        entity.sourcename = request.sourcename;
                        entity.description = request.description;
                        bool hasSpecialChars = rgx.IsMatch(entity.sourcename);
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
