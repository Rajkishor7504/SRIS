/*
* File Name : CreateAccessLinkMasterCommand.cs
* class Name : CreateAccessLinkMasterCommand, CreatAccessLinkMasterCommandHandler
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : command class to create the Access Link for User
*/

using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.AccessLinkMasters.Command.CreateAccessLinkMasterList
{
    public class CreateAccessLinkMasterCommand: IRequest<int>
    {
        public int linkaccessid { get; set; }
        public int plinkid { get; set; }
        public int userid { get; set; }
        public AccessLinkType accesstype { get; set; }
    }
    public class CreatAccessLinkMasterCommandHandler : IRequestHandler<CreateAccessLinkMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        public CreatAccessLinkMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To Create a new record for User Access Link"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of CreateAccessLinkMasterCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To Create a new record for User Access Link</remarks>
        public async Task<int> Handle(CreateAccessLinkMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = new AccessLinkMaster();
            try
            {
                entity.userid = request.userid;
                entity.accesstype = request.accesstype;
                entity.createdby = 1;
                entity.updatedby = 1;
                entity.deletedflag = false;
                entity.plinkid = request.plinkid;
                entity.linkaccessid = request.linkaccessid;
                if (entity.linkaccessid == 0)
                    _context.m_adm_linkaccess.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return entity.linkaccessid;
        }
        #endregion
    }
}
