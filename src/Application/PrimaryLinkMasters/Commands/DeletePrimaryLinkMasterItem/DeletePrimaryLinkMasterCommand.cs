/*
* File Name : DeletePrimaryLinkMasterCommand.cs
* class Name : DeletePrimaryLinkMasterCommand, DeleteMasterCommandHandler
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : command class to delete the Primary Link
*/

using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PrimaryLinkMasters.Commands.DeletePrimaryLinkMasterItem
{
    public class DeletePrimaryLinkMasterCommand : IRequest<int>
    {
        public int plinkid { get; set; }
    }
    public class DeleteMasterCommandHandler : IRequestHandler<DeletePrimaryLinkMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To delete the Primary Link"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of DeletePrimaryLinkMasterCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To delete the Primary Link</remarks>
        public async Task<int> Handle(DeletePrimaryLinkMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_adm_primarylink.FindAsync(request.plinkid);
            int count = 0;
            int retval = 0;
            if (entity == null)
            {
                throw new NotFoundException(nameof(PrimaryLinkMaster), request.plinkid);
            }
            count = _context.m_adm_linkaccess.Where(x => x.plinkid == request.plinkid && x.deletedflag == false).Count();
            if (count > 0)
            {
                retval = 2;
            }
            else
            {
                entity.deletedflag = true;

                await _context.SaveChangesAsync(cancellationToken);
                retval = 1;
            }

            return retval;
        }
        #endregion
    }
}
