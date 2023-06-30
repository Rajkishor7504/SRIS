using MediatR;
using SRIS.Application.ClusterMaster.Queries.GetClusterMasterQueries;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Domain.Common;
using SRIS.Domain.Entities;
using SRIS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.ClusterMaster.Commands.CreateClusterMasterItem
{
   public class CreateClusterMasterItemCommand : IRequest<int>
    {
        public string action { get; set; }
        public int regionid { get; set; }
        public int districtid { get; set; }
        public int wardid { get; set; }
        public int settlementid { get; set; }
        public int clusterno { get; set; }
        public int eano { get; set; }   //Changes by Deepak Kumar Sahu(16-09-2022)
        public int createdby { get; set; }
        public int id { get; set; }
        public List<ClusterMasterDto> Lists { get; set; }
    }
    public class CreateClusterMasterItemCommandHandler : IRequestHandler<CreateClusterMasterItemCommand, int>
    {
        private readonly IClusterMasterService _IClusterMasterService;
        private readonly IApplicationDbContext _context;

        public CreateClusterMasterItemCommandHandler(IClusterMasterService IClusterMasterService, IApplicationDbContext context)
        {
            _IClusterMasterService = IClusterMasterService;
            _context = context;
        }

        public async Task<int> Handle(CreateClusterMasterItemCommand request, CancellationToken cancellationToken)
        {
            //ClusterMasterDto obj = new ClusterMasterDto();
            int retval = 0;
            if(request.action== "ac")
            {
                try
                {
                    var entity = new ClusterMasterDto();

                    entity.action = request.action;
                    entity.regionid = request.regionid;
                    entity.districtid = request.districtid;
                    entity.wardid = request.wardid;
                    entity.settlementid = request.settlementid;
                    entity.clusterno = request.clusterno;
                    entity.eano = request.eano;
                    entity.createdby = request.createdby;

                    retval = await _IClusterMasterService.AddClusterMaster(entity);
                    //obj.status = retval.ToString();
                }
                catch (Exception ex)
                {
                    //obj.status = "500";
                    //obj.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                    throw new Exception(ex.Message);
                }
            }
            else if(request.action == "el")
            {
                try
                {
                    Regex rgx1 = new Regex("[^0-9 ]");
                    
                    var excellist = new List<ClusterMasterDto>();
                    if (request.Lists.Count>0)
                    {
                        //request.Lists.ForEach(pd => excellist.Add(new ClusterMasterDto()
                        //{
                            
                        ////exclusterno = pd.exclusterno,
                        ////exregionno = _context.m_adm_leveldetails.FirstOrDefault(a => a.code == pd.exregionno && a.levelid == 1 && a.parentid == 0).leveldetailid.ToString(),
                        ////exdistrictno = _context.m_adm_leveldetails.FirstOrDefault(a => a.code == pd.exdistrictno && a.levelid == 2 && a.parentid == int.Parse(pd.exregionno)).leveldetailid.ToString(),
                        ////exwardno = _context.m_adm_leveldetails.FirstOrDefault(a => a.code == pd.exwardno && a.levelid == 3 && a.parentid == int.Parse(pd.exdistrictno)).leveldetailid.ToString(),
                        ////exsettlementno = _context.m_adm_leveldetails.FirstOrDefault(a => a.code == pd.exsettlementno && a.levelid == 4 && a.parentid == int.Parse(pd.exwardno)).leveldetailid.ToString(),

                        //    exclusterno = pd.exclusterno,
                        //    exregionno = pd.exregionno,
                        //    exdistrictno = pd.exdistrictno,
                        //    exwardno = pd.exwardno,
                        //    exsettlementno = pd.exsettlementno

                        //}));
                        foreach (var pd in request.Lists)
                        {
                            bool clusterno = rgx1.IsMatch(pd.exclusterno);
                            bool regionno = rgx1.IsMatch(pd.exregionno);
                            bool districtno = rgx1.IsMatch(pd.exdistrictno);
                            bool wardno = rgx1.IsMatch(pd.exwardno);
                            bool settleno = rgx1.IsMatch(pd.exsettlementno);
                            bool eano = rgx1.IsMatch(pd.exeano);
                            if (clusterno==false && regionno==false && districtno==false && wardno==false && settleno==false && eano == false)
                            {
                                string exclusterno = "";
                                string exregionno = "";
                                string exdistrictno = "";
                                string exwardno = "";
                                string exsettlementno = "";
                                string exeano = "";
                                if (pd.exclusterno!="" && pd.exregionno != "" && pd.exdistrictno != "" && pd.exwardno != "" && pd.exsettlementno != "" && pd.exeano != "")
                                {
                                    exclusterno = pd.exclusterno;
                                    exregionno = pd.exregionno;
                                    exdistrictno = pd.exdistrictno;
                                    exwardno = pd.exwardno;
                                    exsettlementno = pd.exsettlementno;
                                    exeano = pd.exeano;
                                    excellist.Add(new ClusterMasterDto { exclusterno = exclusterno, exregionno = exregionno, exdistrictno = exdistrictno, exwardno = exwardno, exsettlementno = exsettlementno,exeano=exeano });
                                }
                                //string exclusterno = pd.exclusterno;
                                //string exregionno = pd.exregionno;
                                //string exdistrictno = pd.exdistrictno;
                                //string exwardno = pd.exwardno;
                                //string exsettlementno = pd.exsettlementno;
                                
                            }
                            else
                            {
                                retval = 500;
                                //obj.status = retval.ToString();
                                return retval; 
                            }
                                 
                        }
                        var entity = new ClusterMasterDto();
                        entity.Lists = excellist;
                        entity.createdby = request.createdby;
                        retval = await _IClusterMasterService.AddClusterMasterBulk(entity);
                        //obj.status = retval.ToString();
                    }
                    else
                    {
                        retval = 400;
                        //obj.status = retval.ToString();
                        return retval;
                    }
                }
                catch (Exception ex)
                {
                    //obj.status = "500";
                    //obj.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                    throw new Exception(ex.Message);
                }


            }
            else
            {
                try
                {
                    var entity = new ClusterMasterDto();

                    entity.action = request.action;
                    entity.regionid = request.regionid;
                    entity.districtid = request.districtid;
                    entity.wardid = request.wardid;
                    entity.settlementid = request.settlementid;
                    entity.clusterno = request.clusterno;
                    entity.eano = request.eano;
                    entity.createdby = request.createdby;
                    entity.id = request.id;
                    retval = await _IClusterMasterService.UpdateClusterMaster(entity);
                    //obj.status = retval.ToString();
                }
                catch (Exception ex)
                {
                    //obj.status = "500";
                    //obj.message = CommonHelper.GetEnumDescription((ResponseStatus)500);
                    throw new Exception(ex.Message);
                }
            }
            
            return retval;
        }
    }
}
