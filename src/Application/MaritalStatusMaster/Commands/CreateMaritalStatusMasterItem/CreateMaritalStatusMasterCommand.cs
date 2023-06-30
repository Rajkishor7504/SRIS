using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SRIS.Application.MaritalStatusMaster.Commands.CreateMaritalStatusMasterItem
{
   public class CreateMaritalStatusMasterCommand : IRequest<int>
    {
        public int maritalstatusid { get; set; }

        [Required]
        [MaxLength(50)]     
        public string maritalstatusname { get; set; }
    }
    public class CreateMaritalStatusMasterCommandHandler : IRequestHandler<CreateMaritalStatusMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;

        public CreateMaritalStatusMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        #region "To Create a new record for Marital Status"
        ///<summary>
        /// Created By Rajalaxmi behera on 09/06/2021
        /// </summary>
        /// <parameter>Request Object of CreateMaritalStatusMasterCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To Create a new record for Marital Status</remarks>
        public async Task<int> Handle(CreateMaritalStatusMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            int count = 0;
            int retval = 0;
            var entity = new MaritalStatus();
           
            try
            {
                count = _context.m_master_maritalstatus.Where(x => x.maritalstatusname == request.maritalstatusname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.maritalstatusid == 0)
                    {

                        int id = _context.m_master_maritalstatus.ToListAsync().Result.LastOrDefault().maritalstatusid;
                        entity.maritalstatusname = request.maritalstatusname;
                        entity.createdby = 1;
                        //entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.createdon = _dateTime.Now;
                        //entity.updatedon = DateTime.Now;
                        entity.maritalstatusid = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.maritalstatusname);
                        if (hasSpecialChars == false)
                        {

                            _context.m_master_maritalstatus.Add(entity);
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
        #endregion
    }
}
