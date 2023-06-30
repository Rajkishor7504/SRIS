using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.UMUserLocationMasterItem.Queries.GetUMUserLocationMasterItem;
using SRIS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.UMUserLocationMasterItem.Command.UpdateUMUserLocationMaster
{
    public class UpdateUMUserLocationMasterCommand:IRequest<int>
    {[Key]
        public int userlocid { get; set; }
        public int roleid { get; set; }
        public int userid { get; set; }
        public int locationid { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public List<UMUserLocationDto> Lists { get; set; }
        

    }
    public class UpdateUMUserLocationMasterCommandHandler : IRequestHandler<UpdateUMUserLocationMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
        public UpdateUMUserLocationMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdateUMUserLocationMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = new UMUserLocation();
            int count = 0;
            var z = request.Lists;
            int retval = 0;
            try
            {

                if (request.Lists == null)
                {
                    throw new NotFoundException(nameof(UMUserLocation), request.userid);
                }
               // count = _context.t_user_userlocation.Where(x => x.roleid == z[0].roleid && x.userid == z[0].userid && x.deletedflag == false).Count();
                //if (count == 0)
                //{
                    if (request.Lists.Count != 0)
                    {
                        foreach (var lst in request.Lists)
                        {
                            var entity2 = await _context.t_user_userlocation.FindAsync(lst.usrlocid1);
                            if (lst.usrlocid1 == 0)
                            {
                                entity.roleid = lst.roleid;
                                entity.userid = lst.userid;
                                entity.locationid = lst.districtid;
                                entity.createdby = 1;
                                entity.createdon = _dateTime.Now;
                                entity.updatedby = 1;
                                entity.updatedon = _dateTime.Now;
                                entity.deletedflag = false;
                                entity.userlocid = request.userlocid;
                                _context.t_user_userlocation.Add(entity);
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 2;

                            }
                            else
                            {
                                entity.roleid = lst.roleid;
                                entity.userid = lst.userid;
                                entity.locationid = lst.districtid;
                                entity.updatedby = 1;
                                entity.updatedon = _dateTime.Now;
                                entity.deletedflag = false;
                                entity.userlocid = lst.usrlocid1;
                                await _context.SaveChangesAsync(cancellationToken);
                            }

                        }
                        if (z[0].deletevalue != "0")
                        {
                            string[] val = z[0].deletevalue.Split(',');
                            foreach (string value in val)
                            {
                                var entity3 = await _context.t_user_userlocation.FindAsync(Convert.ToInt32(value));
                                entity3.userlocid = Convert.ToInt32(value);
                                entity3.updatedby = 1;
                                entity3.updatedon = _dateTime.Now;
                                entity3.deletedflag = true;
                                await _context.SaveChangesAsync(cancellationToken);
                            }
                        }

                        retval = 2;
                    //}
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

