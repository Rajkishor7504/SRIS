/*
* File Name : DeleteGlobalLinkMasterCommand.cs
* class Name : DeleteGlobalLinkMasterCommand, DeleteMasterCommandHandler
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : command class to delete the Global Link
*/

using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GlobalLinkMasters.Commands.DeleteGlobalLinkMasterItem
{
    public class DeleteGlobalLinkMasterCommand : IRequest<int>
    {
        public int glinkid { get; set; }
    }
    public class DeleteMasterCommandHandler : IRequestHandler<DeleteGlobalLinkMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To Delete Global Link"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of DeleteGlobalLinkMasterCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To Delete Global Link</remarks>
        public async Task<int> Handle(DeleteGlobalLinkMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_adm_globallink.FindAsync(request.glinkid);
            int count = 0;
            int retval = 0;
            if (entity == null)
            {
                throw new NotFoundException(nameof(GlobalLinkMaster), request.glinkid);
            }
            count = _context.m_adm_primarylink.Where(x => x.glinkid == request.glinkid && x.deletedflag == false).Count();
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
