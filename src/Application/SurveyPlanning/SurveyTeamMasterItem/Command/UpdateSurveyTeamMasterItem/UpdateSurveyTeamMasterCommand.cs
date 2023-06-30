using MediatR;
using SRIS.Application.Common.Exceptions;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.SurveyPlanning.SurveyTeamMasterItem.Query.GetSurveyTeamMasterItem;
using SRIS.Domain.Entities.SurveyPlanning;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SRIS.Application.SurveyPlanning.SurveyTeamMasterItem.Command.UpdateSurveyTeamMasterItem
{
   public class UpdateSurveyTeamMasterCommand: IRequest<int>
    {
        [Key]
        public int teamid { get; set; }
        public int surveyplanid { get; set; }
        public string teamname { get; set; }
        public string description { get; set; }
        public int userid { get; set; }
        public int usettypeid { get; set; }
        public int teamdetailid { get; set; }
        public string action { get; set; }
        public List<SurveyTeamMasterDto> Lists { get; set; }
       // public int updatedby { get; set; }
        // public string coficentname { get; set; }
    }
    public class UpdateSurveyTeamMasterCommandHandler : IRequestHandler<UpdateSurveyTeamMasterCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IDateTime _dateTime;
        public UpdateSurveyTeamMasterCommandHandler(IApplicationDbContext context, IDateTime dateTime)
        {
            _context = context;
            _dateTime = dateTime;
        }

        public async Task<int> Handle(UpdateSurveyTeamMasterCommand request, CancellationToken cancellationToken)
        {
            var ent = new SurveyTeamDetails();
            var x = request.Lists;
            //int y =Convert.ToInt32(x[0].deletevalue);
            //var z = y.ToString(); 


            int retval = 0;
            try
            {
                
                if (request.Lists == null)
                {
                    throw new NotFoundException(nameof(SurveyTeamMaster), request.teamname);
                }
                if (request.Lists.Count != 0)
                {
                    var entity = await _context.m_survey_team.FindAsync(x[0].teamid);
                    entity.teamid = x[0].teamid;
                    entity.surveyplanid = x[0].surveyplanid;
                    entity.teamname = x[0].teamname;
                    entity.description = x[0].description;
                    entity.updatedby = 1;
                    entity.updatedon = _dateTime.Now;
                    entity.deletedflag = false;
                    await _context.SaveChangesAsync(cancellationToken);
                    retval = 2;
                    if (retval == 2)
                    {
                        var entity1 = await _context.t_survey_teamdetail.FindAsync(x[0].teamdetailid1);
                        entity1.teamid = entity.teamid;
                        entity1.userid = x[0].userid1;
                        entity1.usettypeid = 2;
                        entity1.updatedby = 1;
                        entity1.updatedon = _dateTime.Now;
                        entity1.deletedflag = false;
                        entity1.teamdetailid = x[0].teamdetailid1;
                        await _context.SaveChangesAsync(cancellationToken);

                        foreach (var lst in request.Lists) {
                            var entity2 = await _context.t_survey_teamdetail.FindAsync(lst.teamdetailid);
                            if (lst.teamdetailid == 0)
                            {
                                ent.teamid = lst.teamid;
                                ent.userid = lst.userid;
                                ent.usettypeid = lst.usettypeid;
                                ent.createdby = 1;
                                ent.createdon = _dateTime.Now;
                                ent.updatedby = 1;
                                ent.updatedon = _dateTime.Now;
                                ent.teamdetailid = request.teamdetailid;
                                _context.t_survey_teamdetail.Add(ent);
                                await _context.SaveChangesAsync(cancellationToken);
                                retval = 2;

                            }
                            else
                            {
                                entity2.teamid = lst.teamid;
                                entity2.userid = lst.userid;
                                entity2.usettypeid = lst.usettypeid;
                                entity2.updatedby = 1;
                                entity2.updatedon = _dateTime.Now;
                                entity2.deletedflag = false;
                                entity2.teamdetailid = lst.teamdetailid;
                                await _context.SaveChangesAsync(cancellationToken);
                            }

                        }

                        if (x[0].deletevalue !="0")
                        //if (y!=0 && x[0].deletevalue != null)

                        {
                            var dlt = x[0].deletevalue;
                            string[] val = dlt.Split(',');
                            foreach (string value in val)
                                {
                                var entity3 = await _context.t_survey_teamdetail.FindAsync(Convert.ToInt32(value));
                                entity3.updatedby = 1;
                                entity3.updatedon = _dateTime.Now;
                                entity3.deletedflag = true;
                                entity3.teamdetailid = Convert.ToInt32(value);
                                await _context.SaveChangesAsync(cancellationToken);
                            }
                        }

                        retval = 2;
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