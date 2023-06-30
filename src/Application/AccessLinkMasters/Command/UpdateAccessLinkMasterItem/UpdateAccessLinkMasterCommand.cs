/*
* File Name : UpdateAccessLinkMasterCommand.cs
* class Name : UpdateAccessLinkMasterCommand, UpdateAccessLinkMasterCommandHandler
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : command class to update the Access Link for User
*/

using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AccessLinkMasters.Command.UpdateAccessLinkMasterItem
{
    public class UpdateAccessLinkMasterCommand : IRequest
    {
        public int linkaccessid { get; set; }
        public int plinkid { get; set; }
        public int userid { get; set; }
        public bool deletedflag { get; set; }
        public AccessLinkType accesstype { get; set; }
    }
    public class UpdateAccessLinkMasterCommandHandler : IRequestHandler<UpdateAccessLinkMasterCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAccessLinkMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To update record for User Access Link"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of UpdateAccessLinkMasterCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To update record for User Access Link</remarks>
        public async Task<Unit> Handle(UpdateAccessLinkMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_adm_linkaccess.FindAsync(request.linkaccessid);

            if (entity == null)
            {
                throw new NotFoundException(nameof(AccessLinkMaster), request.plinkid);
            }
            if (request.deletedflag)
            {
                entity.deletedflag = true;
            }
            else
            {
                entity.plinkid = request.plinkid;
                entity.userid = request.userid;
                entity.accesstype = request.accesstype;
            }
           

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
        #endregion
    }
}
