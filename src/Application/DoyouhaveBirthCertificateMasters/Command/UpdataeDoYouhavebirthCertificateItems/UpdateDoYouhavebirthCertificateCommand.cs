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

namespace SRIS.Application.DoyouhaveBirthCertificateMasters.Command.UpdataeDoYouhavebirthCertificateItems
{
    public class UpdateDoYouhavebirthCertificateCommand:IRequest<int>
    {
        public int id { get; set; }
        public string doyouhavebirthcertificate { get; set; }
        public string description { get; set; }
    }
    public class UpdateDoYouhavebirthCertificateCommandHandler : IRequestHandler<UpdateDoYouhavebirthCertificateCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public UpdateDoYouhavebirthCertificateCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdateDoYouhavebirthCertificateCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_doyouhavebirthcertificate.FindAsync(request.id);
            int count = 0;
            int retval = 0;
            try
            {
                if (entity == null)
                {
                    throw new NotFoundException(nameof(DoyouhaveBirthCertificate), request.doyouhavebirthcertificate);
                }
                count = _context.m_master_doyouhavebirthcertificate.Where(x => x.doyouhavebirthcertificate == request.doyouhavebirthcertificate && x.id != request.id && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.id != 0)
                    {
                        entity.doyouhavebirthcertificate = request.doyouhavebirthcertificate;
                        entity.description = request.description;
                        entity.updatedby = 1;
                        entity.updatedon = _dateTime.Now;

                        bool hasSpecialChars = rgx.IsMatch(entity.doyouhavebirthcertificate);
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
