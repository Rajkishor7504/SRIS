/*
* File Name : UpdateGlobalLinkMasterCommand.cs
* class Name : UpdateGlobalLinkMasterCommand, UpdateGlobalLinkMasterCommandHandler
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : command class to update the global link
*/

using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.GlobalLinkMasters.Commands.UpdateGlobalLinkMasterItem
{
    public class UpdateGlobalLinkMasterCommand : IRequest<int>
    {
        public int glinkid { get; set; }
        public string glinkname { get; set; }
        public int MenuOrder { get; set; }
    }
    public class UpdateGlobalLinkMasterCommandHandler : IRequestHandler<UpdateGlobalLinkMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateGlobalLinkMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To Update Global Link"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of UpdateGlobalLinkMasterCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Unit</returns>
        /// <remarks>To Update Global Link</remarks>
        public async Task<int> Handle(UpdateGlobalLinkMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_adm_globallink.FindAsync(request.glinkid);
            int count = 0;
            int retval = 0;
            if (entity == null)
            {
                throw new NotFoundException(nameof(GlobalLinkMaster), request.glinkname);
            }
            count = _context.m_adm_globallink.Where(x => x.glinkname == request.glinkname && x.glinkid != request.glinkid).Count();
            if (count == 0)
            {
                entity.glinkname = request.glinkname;
                await _context.SaveChangesAsync(cancellationToken);
                retval = 1;
            }

            else
            {
                retval = 2;
            }
            return retval;
        }
        #endregion
    }
}
