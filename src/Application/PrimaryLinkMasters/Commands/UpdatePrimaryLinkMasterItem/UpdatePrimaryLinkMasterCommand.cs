/*
* File Name : UpdatePrimaryLinkMasterCommand.cs
* class Name : UpdatePrimaryLinkMasterCommand, UpdatePrimaryLinkMasterCommandHandler
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : command class to update the Primary Link
*/

using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PrimaryLinkMasters.Commands.UpdatePrimaryLinkMasterItem
{
    public class UpdatePrimaryLinkMasterCommand : IRequest<int>
    {
        public int plinkid { get; set; }
        public string plinkname { get; set; }
        public string controllername { get; set; }
        public string actionname { get; set; }
        public string areaname { get; set; }
    }
    public class UpdatePrimaryLinkMasterCommandHandler : IRequestHandler<UpdatePrimaryLinkMasterCommand,int>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePrimaryLinkMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To update the Primary Link"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of UpdatePrimaryLinkMasterCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To update the Primary Link</remarks>
        public async Task<int> Handle(UpdatePrimaryLinkMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.m_adm_primarylink.FindAsync(request.plinkid);
            int count = 0;
            int retval = 0;
            if (entity == null)
            {
                throw new NotFoundException(nameof(PrimaryLinkMaster), request.plinkname);
            }
            count = _context.m_adm_primarylink.Where(x => x.plinkname == request.plinkname && x.plinkid != request.plinkid && x.deletedflag==false).Count();
            if (count == 0)
            {
                entity.plinkname = request.plinkname;
                entity.controllername = request.controllername;
                entity.actionname = request.actionname;
                entity.areaname = request.areaname;

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
