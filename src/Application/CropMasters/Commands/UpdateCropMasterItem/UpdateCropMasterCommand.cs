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

namespace SRIS.Application.CropMasters.Commands.UpdateCropMasterItem
{
   public class UpdateCropMasterCommand : IRequest<int>
    {
        public int cropid { get; set; }
        public string cropname { get; set; }
        public string description { get; set; }
    }
    public class UpdateCropMasterCommandHandler : IRequestHandler<UpdateCropMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateCropMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _dateTime = dateTime;
            _context = context;
        }
        public async Task<int> Handle(UpdateCropMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_crop.FindAsync(request.cropid);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(Crop), request.cropname);
                }
                count = _context.m_master_crop.Where(x => x.cropname == request.cropname && x.cropid != request.cropid && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.cropid != 0)
                    {
                        entity.updatedon = _dateTime.Now;
                        entity.updatedby = 1;
                        entity.cropname = request.cropname;
                        entity.description = request.description;
                        bool hasSpecialChars = rgx.IsMatch(entity.cropname);
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
