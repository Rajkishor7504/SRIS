/*
* File Name : DeleteAccessLinkMasterCommand.cs
* class Name : DeleteAccessLinkMasterCommand, DeleteMasterCommandHandler
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : command class to delete the Access Link for User
*/

using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AccessLinkMasters.Command.DeleteAccessLinkMasterItem
{
    public class DeleteAccessLinkMasterCommand : IRequest
    {
        public int linkaccessid { get; set; }
    }
    public class DeleteMasterCommandHandler : IRequestHandler<DeleteAccessLinkMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To delete the record for User Access Link"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of DeleteAccessLinkMasterCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Unit</returns>
        /// <remarks>To delete the record for User Access Link</remarks>
        public async Task<Unit> Handle(DeleteAccessLinkMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_adm_linkaccess.FindAsync(request.linkaccessid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(AccessLinkMaster), request.linkaccessid);
            }

            _context.m_adm_linkaccess.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        #endregion
    }
}
