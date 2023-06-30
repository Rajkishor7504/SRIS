using MediatR;
using Microsoft.EntityFrameworkCore;
using SRIS.Application.Common.Interfaces;
using SRIS.Domain.Entities.MasterEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.LiveStockMasters.Commands.CreateLiveStockMasterList
{
   public class CreateLiveStockMasterCommand : IRequest<int>
    {
        public int livestockid { get; set; }
        public string livestockname { get; set; }
        public string description { get; set; }
    }
    public class CreateLiveStockMasterCommandHandler : IRequestHandler<CreateLiveStockMasterCommand, int>
    {
        private readonly IDateTime _dateTime;
        private readonly IApplicationDbContext _context;
        public CreateLiveStockMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }
        public async Task<int> Handle(CreateLiveStockMasterCommand request, CancellationToken cancellationToken)
        {
            Regex rgx = new Regex("[^A-Za-z ]");
            var entity = new LiveStock();
            int count = 0;
            int retval = 0;
            try
            {
                count = _context.m_master_livestock.Where(x => x.livestockname == request.livestockname && x.deletedflag == false).Count();
                if (count == 0)
                {
                    if (request.livestockid == 0)
                    {
                        int id = _context.m_master_livestock.ToListAsync().Result.LastOrDefault().livestockid;
                        entity.livestockname = request.livestockname;
                        entity.description = request.description;
                        // entity.createdby = 1;
                        //// entity.updatedby = 1;
                        // entity.deletedflag = false;
                        entity.createdby = 1;
                        //entity.updatedby = 1;
                        entity.deletedflag = false;
                        entity.createdon = _dateTime.Now;
                        entity.livestockid = id + 1;
                        bool hasSpecialChars = rgx.IsMatch(entity.livestockname);
                        if (entity.description != null)
                        {
                            bool hasSpecialChars1 = rgx.IsMatch(entity.description);
                            if (hasSpecialChars == false && hasSpecialChars1 == false)
                            {
                                _context.m_master_livestock.Add(entity);
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 1;
                            }
                            else
                            {
                                retval = 403;
                            }
                        }

                        else if (hasSpecialChars == false)
                        {

                            _context.m_master_livestock.Add(entity);
                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 1;
                        }
                        else
                        {
                            retval = 403;


                        }
                    }
                }
                else
                {
                    retval = 3;
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return retval;
        }
    }
}