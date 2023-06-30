using SRIS.Application.ConfigureCommiteeMasterItems.Queries.GetConfigureCommitee;
using SRIS.Application.GrievanceComplaintsMasterItems.Queries.GetGrievanceComplaintsItem;
using SRIS.Application.Grievances.Queries.GetAssignSurveyManager;
using SRIS.Application.Grievances.Queries.GetRegisterMember;
using SRIS.Application.NotificationMasterItem.Queries.GetNotoficationMasterQueriesItem;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SRIS.Application.Common.Interfaces
{
    public interface IGrievanceService
    {
        Task<int> AddConfigureCommitee(ConfigureCommiteeDto objConfigureCommitee);
        Task<int> UpdateGrievanceNotification(NotificationMasterDto objnotificstionmaster);
        Task<int> UpdateqasupervisorNotification(NotificationMasterDto objnotificstionmaster);
        Task<List<NotificationMasterDto>> GetNotificationDetails(NotificationMasterDto obj);
        Task<List<NotificationMasterDto>> GetNotificationCount(NotificationMasterDto obj);
        Task<int> UpdateQAOfficerNotification(NotificationMasterDto objqanotification);
        Task<int> AddQAOfficerNotification(NotificationMasterDto objaddQaNotification);
        Task<int> AddUpdateOfficerNotification(NotificationMasterDto objaddQaNotification);
        //Task<int> AddadminHouseholdNotification(NotificationMasterDto objaddQaNotification);
        Task<int> RegisterMember(RegisterMemberDto objRegisterMember);
        Task<List<GrievanceRegisteredDto>> RegisteredGrievanceView(int userId);
        Task<List<GrievanceRegisteredDto>> GrievanceView(string action, int locationid, int userId);
        Task<List<GrievanceDetailDto>> GetGrievanceDetail(int grievanceId);
        Task<List<GrievanceDetailticketDto>>GetGrievanceticketdetailsDetail(int grievanceId);
        Task<List<HouseholdDetailsDto>> GetHouseholddetails(int grievanceId);
        Task<List<RegisterMemberDto>> GetRegisterMembers();
        Task<List<GrievanceStatusDto>> GetGrievanceStatusDetail(int grievanceId);
        Task<List<SurveyManagerDto>> GetSurveyDetails(string action, int locationid, int userId);
        Task<List<AssignSurveyManagerDto>> GetGrievanceBySurveyManagerId(int userId);
        
        Task<List<AssignSurveyManagerDto>> ViewTaggedSurveyManager(int pkid);
    }
}
