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

namespace SRIS.Application.MaritalStatusMaster.Commands.UpdateMaritalStatusMasterItem
{
   public class UpdateMaritalStatusMasterCommand : IRequest<int>
    {
        public int maritalstatusid { get; set; }
        public string maritalstatusname { get; set; }
    }
    public class UpdateMaritalStatusMasterCommandHandler : IRequestHandler<UpdateMaritalStatusMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
       

        public UpdateMaritalStatusMasterCommandHandler(IApplicationDbContext context, 
            IDateTime dateTime )
        {
           
            _dateTime = dateTime;
            _context = context;
        }

        #region "To Update Marital Status"
        ///<summary>
        /// Created By Rajalaxmi Behera on 09/06/2021
        /// </summary>
        /// <parameter>Request Object of UpdateMaritalStatusMasterCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Unit</returns>
        /// <remarks>To Update MaritalStatus </remarks>
        public async Task<int> Handle(UpdateMaritalStatusMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = await _context.m_master_maritalstatus.FindAsync(request.maritalstatusid);
            int count = 0;
            int retval = 0;

            if (entity == null)
            {
                throw new NotFoundException(nameof(MaritalStatus), request.maritalstatusname);
            }
            count = _context.m_master_maritalstatus.Where(x => x.maritalstatusname == request.maritalstatusname && x.maritalstatusid != request.maritalstatusid && x.deletedflag == false).Count();
            if (count == 0)
            {
                if (request.maritalstatusid != 0)
                {
                    entity.updatedon = _dateTime.Now;
                    entity.updatedby =1;
                    entity.maritalstatusname = request.maritalstatusname;
                    bool hasSpecialChars = rgx.IsMatch(entity.maritalstatusname);
                    if (hasSpecialChars == false)
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

            return retval;
        }
        #endregion
    }
}
