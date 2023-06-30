using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterDepenciesEntities;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.MaritalStatusMaster.Commands.DeleteMaritalStatusMasterItem
{
  public  class DeleteMaritalStatusMasterCommand : IRequest<int>
    {
        public int maritalstatusid { get; set; }
    }
    public class DeleteMaritalStatusCommandHandler : IRequestHandler<DeleteMaritalStatusMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMaritalStatusCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To Delete Marital Status"
        ///<summary>
        /// Created By Rajalaxmi Behera on 09/06/2021
        /// </summary>
        /// <parameter>Request Object of DeleteMaritalStatusMasterCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To Delete Marital Status</remarks>
        public async Task<int> Handle(DeleteMaritalStatusMasterCommand request, CancellationToken cancellationToken)
        {
            int count = 0;
            int retval = 0;
            var entity = await _context.m_master_maritalstatus.FindAsync(request.maritalstatusid);
            try
            {
                count = _context.t_hhr_demographicmember.Where(x => x.maritalstatus == request.maritalstatusid && x.deletedflag == false).Count();

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Demographicmember), request.maritalstatusid);
                }
                if (count > 0)
                {
                    retval = 402;
                }
                else
                {
                    //_context.m_master_maritalstatus.Remove(entity);
                    entity.updatedby = 1;
                    entity.deletedflag = true;
                    entity.updatedon = DateTime.Now;
                    await _context.SaveChangesAsync(cancellationToken);
                    //await _context.SaveChangesAsync(cancellationToken);
                    retval = 200;
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            //return Unit.Value;
            return retval;
        }
        //public async Task<Unit> Handle(DeleteMaritalStatusMasterCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = await _context.m_master_maritalstatus.FindAsync(request.maritalstatusid);

        //    if (entity == null)
        //    {
        //        throw new NotFoundException(nameof(MaritalStatus), request.maritalstatusid);
        //    }
        //    entity.updatedon = DateTime.Now;
        //    entity.deletedflag = true;
        //    await _context.SaveChangesAsync(cancellationToken);
        //    return Unit.Value;
        //}
        #endregion
    }
}
