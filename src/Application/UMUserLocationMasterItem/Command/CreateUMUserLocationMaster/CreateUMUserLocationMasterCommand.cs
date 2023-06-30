using MediatR;
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

namespace SRIS.Application.UMUserLocationMasterItem.Command.CreateUMUserLocationMaster
{
    public class CreateUMUserLocationMasterCommand : IRequest<int>
    {
        [Key]
        public int userlocid { get; set; }
        public int roleid { get; set; }
        public int userid { get; set; }
        public int locationid { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public List<UMUserLocationDto> Lists { get; set; }
        public int createdby { get; set; }

    }
    public class CreateUMUserLocationMasterCommandHandler : IRequestHandler<CreateUMUserLocationMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
        private readonly IUserLocationService _iuserlocation;

        public CreateUMUserLocationMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime, IUserLocationService iuserlocation)
        {
            _context = context;
            _dateTime = dateTime;
            _iuserlocation = iuserlocation;
        }

        public async Task<int> Handle(CreateUMUserLocationMasterCommand request, CancellationToken cancellationToken)
        {
            var entity = new UMUserLocation();
            int count = 0;
            int retval = 0;
            var z = request.Lists.ToList();
            //    var entity = new UMUserLocationDto();
            //    int count = 0;
            //    int retval = 0;
            //    //entity.roleid = request.Lists[0].roleid;
            //    //entity.userid = request.Lists[0].userid;
            //    entity.createdby = request.createdby;
            //    entity.Lists = request.Lists;
            //    retval = await _iuserlocation.adduserloca(entity);
            //    return retval;
            //}
            try
            {
                count = _context.t_user_userlocation.Where(x => x.roleid == z[0].roleid && x.userid == z[0].userid && x.deletedflag==false).Count();
                if (count == 0)
                {
                    if (request.Lists.Count != 0)
                    {
                        foreach (var lst in request.Lists)
                        {
                            //count = _context.t_user_userlocation.Where(x => x.roleid == lst.roleid && x.userid == lst.userid).Count();
                            //if (lst = 0)
                            //{
                            entity.roleid = lst.roleid;
                            entity.userid = lst.userid;
                            entity.locationid = lst.districtid;
                            entity.createdby = 1;
                            entity.createdon = _dateTime.Now;
                            entity.deletedflag = false;
                            entity.userlocid = request.userlocid;
                            _context.t_user_userlocation.Add(entity);
                            await _context.SaveChangesAsync(cancellationToken);
                            retval = 1;
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