/*
* File Name : CreatePrimaryLinkMasterCommand.cs
* class Name : CreatePrimaryLinkMasterCommand, CreatPrimaryLinkMasterCommandHandler
* Created Date : 29th May 2021
* Created By : Spandana Ray
* Description : command class to create the Global Link
*/

using MediatR;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.PrimaryLinkMasters.Commands.CreatePrimaryLinkMasterList
{
    public  class CreatePrimaryLinkMasterCommand : IRequest<int>
    {        
        public int plinkid { get; set; }
        public int glinkid { get; set; }
        public string plinkname { get; set; }
        public string controllername { get; set; }
        public string actionname { get; set; }
        public string areaname { get; set; }
    }
    public class CreatPrimaryLinkMasterCommandHandler : IRequestHandler<CreatePrimaryLinkMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatPrimaryLinkMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To Create a new record for Primary Link"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of CreatePrimaryLinkMasterCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To Create a new record for Primary Link</remarks>
        public async Task<int> Handle(CreatePrimaryLinkMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = new PrimaryLinkMaster();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_adm_primarylink.Where(x => x.plinkname == request.plinkname && x.deletedflag==false).Count();
                if (count == 0)
                {
                    entity.plinkname = request.plinkname;
                    entity.controllername = request.controllername;
                    entity.actionname = request.actionname;
                    entity.areaname = request.areaname;
                    entity.createdby = 1;
                    entity.updatedby = 1;
                    entity.deletedflag = false;
                    entity.plinkid = request.plinkid;
                    entity.glinkid = request.glinkid;
                    _context.m_adm_primarylink.Add(entity);

                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 1;
                }
                else
                {
                    retval = 2;
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
