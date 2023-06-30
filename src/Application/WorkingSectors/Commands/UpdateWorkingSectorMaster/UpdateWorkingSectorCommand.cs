using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.WorkingSectors.Commands.UpdateWorkingSectorMaster
{
   public class UpdateWorkingSectorCommand:IRequest<int>
    {
        [Key]
        public int sectorid { get; set; }
        public string sectorname { get; set; }
        public string description { get; set; }
    }
    public class UpdateWorkingSectorCommandHandler : IRequestHandler<UpdateWorkingSectorCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateWorkingSectorCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdateWorkingSectorCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_workingsector.FindAsync(request.sectorid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(WorkingSector), request.sectorname);
                }
                count = _context.m_master_workingsector.Where(x => x.sectorname == request.sectorname && x.sectorid != request.sectorid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.sectorid != 0)
                    {
                        entity.sectorname = request.sectorname;
                        entity.description = request.description;
                        entity.updatedby = 1;
                        entity.updatedon = _dateTime.Now;

                        bool hasSpecialChars = rgx.IsMatch(entity.sectorname);
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
