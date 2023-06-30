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

namespace SRIS.Application.LightingSourceMasters.Commands.CreateLightingsourceMasterList
{
    public class CreateLightingsourceMasterCommand : IRequest<int>
    {
        public int sourceid { get; set; }
        public string sourcename { get; set; }
        public string description { get; set; }
    }
    public class CreateLightingsourceMasterCommandHandler : IRequestHandler<CreateLightingsourceMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreateLightingsourceMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateLightingsourceMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new LightingSource();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_lightingsource.Where(x => x.sourcename == request.sourcename && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.sourceid == 0)
                    {
                        entity.sourcename = request.sourcename;
                        entity.description = request.description;
                        entity.createdby = 1;
                        entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.sourceid = request.sourceid;
                        bool hasSpecialChars = rgx.IsMatch(entity.sourcename);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_lightingsource.Add(entity);
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

                            _context.m_master_lightingsource.Add(entity);
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
