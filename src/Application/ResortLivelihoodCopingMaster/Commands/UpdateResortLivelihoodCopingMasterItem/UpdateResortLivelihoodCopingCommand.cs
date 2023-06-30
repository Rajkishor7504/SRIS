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

namespace SRIS.Application.ResortLivelihoodCopingMaster.Commands.UpdateResortLivelihoodCopingMasterItem
{
    public class UpdateResortLivelihoodCopingCommand : IRequest<int>
    {
        public int resortlivelyhoodcopingid { get; set; }
        public string resortlivelyhoodcoping { get; set; }
        public string description { get; set; }
    }
    public class UpdateResortLivelihoodCopingCommandHandler : IRequestHandler<UpdateResortLivelihoodCopingCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateResortLivelihoodCopingCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdateResortLivelihoodCopingCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_resortLivelhoodCoping.FindAsync(request.resortlivelyhoodcopingid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(ResortLivelihoodCopingMasterEnity), request.resortlivelyhoodcoping);
                }
                count = _context.m_master_resortLivelhoodCoping.Where(x => x.resortlivelyhoodcoping == request.resortlivelyhoodcoping && x.resortlivelyhoodcopingid != request.resortlivelyhoodcopingid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.resortlivelyhoodcopingid != 0)
                    {
                        entity.resortlivelyhoodcoping = request.resortlivelyhoodcoping;
                        entity.description = request.description;
                        entity.updatedby = 1;
                        entity.updatedon = _dateTime.Now;

                        bool hasSpecialChars = rgx.IsMatch(entity.resortlivelyhoodcoping);
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
