/*
* File Name : CreateGlobalLinkMasterCommand.cs
* class Name : CreateGlobalLinkMasterCommand, CreatGlobalLinkMasterCommandHandler
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

namespace SRIS.Application.GlobalLinkMasters.Commands.CreateGlobalLinkMasterList
{
    public  class CreateGlobalLinkMasterCommand : IRequest<int>
    {        
        public int glinkid { get; set; }        
        public string glinkname { get; set; }
        public int MenuOrder { get; set; }
    }
    public class CreatGlobalLinkMasterCommandHandler : IRequestHandler<CreateGlobalLinkMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatGlobalLinkMasterCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region "To Create a new record for Global Link"
        ///<summary>
        /// Created By Spandana Ray on 29/05/2021
        /// </summary>
        /// <parameter>Request Object of CreateGlobalLinkMasterCommand</parameter>
        /// <parameter>Object of CancellationToken</parameter>
        /// <returns>Integer</returns>
        /// <remarks>To Create a new record for Global Link</remarks>
        public async Task<int> Handle(CreateGlobalLinkMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = new GlobalLinkMaster();
            int count = 0;
            int retval = 0;
            try
            {

                count = _context.m_adm_globallink.Where(x => x.glinkname == request.glinkname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    entity.glinkname = request.glinkname;
                    entity.MenuOrder = _context.m_adm_globallink.OrderByDescending(g => g.MenuOrder).FirstOrDefault().MenuOrder + 1;
                    entity.createdby = 1;
                    entity.updatedby = 1;
                    entity.deletedflag = false;
                    entity.glinkid = request.glinkid;

                    _context.m_adm_globallink.Add(entity);

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
