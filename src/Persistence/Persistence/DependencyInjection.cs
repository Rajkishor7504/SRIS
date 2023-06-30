using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Service;
using Persistence.Service.MisReport;
using Persistence.Service.SurveyPlan;
using SIRS.Persistence.Service.MisReport;
using SRIS.Application.Common;
using SRIS.Application.Common.Interfaces;
using SRIS.Application.Common.Interfaces.IMaster;
using SRIS.Application.Common.Interfaces.IService;
using SRIS.Application.Common.Interfaces.IService.Feedback;
using SRIS.Application.Common.Interfaces.IService.MisReport;
using SRIS.Application.Common.Interfaces.ISurveyPlan;
using SRIS.Persistence.Contract;
using SRIS.Persistence.Service;
using SRIS.Persistence.Service.Feedback;
using SRIS.Persistence.Service.MasterAPI;
using SRIS.Persistence.Service.SurveyPlan;

namespace SRIS.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Connection with Dapper ORM
            IConnectionFactory connectionFactory = new ConnectionFactory(configuration.GetConnectionString("DefaultConnection"));
            services.AddSingleton<IConnectionFactory>(connectionFactory);

            services.AddTransient<IMyUserService, MyUserService>();
            services.AddTransient<IHouseholdService, HouseholdService>();
            services.AddTransient<IMasterService, MasterService>();
            services.AddTransient<IAccessLinkService, AccessLinkService>();
            services.AddTransient<IPrimaryLinkService, PrimaryLinkService>();

            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddSingleton<ISysUserService, SysUserService>();
            services.AddTransient<ILocationMasterService, LocationMasterService>();
            services.AddTransient<IDemographicMasterService, DemographicMasterService>();
            services.AddTransient<IEducationMasterService, EducationMasterService>();
            services.AddTransient<IHealthMasterService, HealthMasterService>();
            services.AddTransient<IEmployementMasterService, EmployementMasterService>();
            services.AddTransient<IHouseHoldHousingService, HouseHoldHousingService>();
            services.AddTransient<IDistanceMasterService, DistanceMasterService>();
            services.AddTransient<IIncomeSourcesMasterService, IncomeSourcesMasterService>();

            services.AddTransient<ICommonService, CommonService>();


            services.AddTransient<IAgriculturalMasterService, AgriculturalMasterService>();
            services.AddTransient<ICopingStrategiesService, CopingStrategiesService>();
            services.AddTransient<IImpactOfShocksService, ImpactOfShocksService>();
            services.AddTransient<IHouseHoldAssetService, HouseHoldAssetService>();
            services.AddTransient<IPlanSurveyService, PlanSurveyService>();
            services.AddTransient<IAssignSurveyService, AssignSurveyService>();
            services.AddTransient<IAssignEAService, AssignEAService>();
            services.AddTransient<IExternalDataRequestService, ExternalDataRequestService>();
            services.AddTransient<IAssignedDeviceService, AssignDeviceService>();
            services.AddTransient<ILocationStatusUpdateService, LocationStatusUpdateService>();
            services.AddTransient<IGrievanceResolutionService, GrievanceResolutionService>();
            services.AddTransient<IGrievanceService, GrievanceService>();

            services.AddTransient<IUserRoleService, UserRoleService>();
            services.AddTransient<IHouseholdSurveyService, HouseholdSurveyService>();
            services.AddTransient<IFeedbackService, FeedbackService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IUpdateHouseholdService, UpdateHouseholdService>();
            services.AddTransient<IHouseholdServiceMobile, HouseholdServiceMobile>();
            services.AddTransient<IAssignLinkToRoleService, AssignLinkToRoleService>();
            services.AddTransient<IReporthhidService, ReporthhidService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IReporthhidService, ReporthhidService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<ImyusersurveyteamdetailsService, MyusersurveyteamdetailsService>();
            services.AddTransient<ILocationMasterServiceM, LocationMasterServiceM>();
           // services.AddTransient<IEnumeratorLocationMasterServiceM, EnumeratorLocationMasterServiceM>();
            services.AddTransient<IEnumeratorLocationMasterServiceCM, EnumeratorLocationMasterServiceCM>();

            services.AddTransient<ISurveyPlanService, SurveyPlanService>();
            services.AddTransient<IPrimaryLinkSlNoService, PrimaryLinkSlNoMastersService>();
            services.AddTransient<ISurveyPlanService, SurveyPlanService>();
            services.AddTransient<IPrimaryLinkAllMastersService, PrimaryLinkAllMastersService>();
            services.AddTransient<IUserLocationService, UserLocationService>();

            services.AddTransient<IPMTService, PMTService>();
            services.AddTransient<IEnumeratorProfileService, EnumeratorProfileService>();
            services.AddTransient<IAssignSurveyManagerService, AssignSurveyManagerService>();
            services.AddTransient<IGlobalLinkSlNoService, GlobalLinkSlNoMastersService>();
            services.AddTransient<ISettlementwisetargetservice, Settlementwisetargetservice>();
            services.AddTransient<IBenificiaryReportService, BenificiaryReportService>();
            services.AddTransient<IBenificiaryPaymentReportService, BenificiaryPaymentReportService>();
            services.AddTransient<IDemograpicConsolidateReportService, DemograpicConsolidateReportService>();
            services.AddTransient<IEnumeratorWiseHhDataCollectionReportService, EnumeratorWiseHhDataCollectionReportService>();
            services.AddTransient<IGrievanceReportService, GrievanceReportService>();
            services.AddTransient<IDatasharingReportService, DatasharingReportservice>();
            services.AddTransient<IHhRejectionReportService, HhRejectionReportService>();
            services.AddTransient<IDatasharingService, DatasharingService>();
            services.AddTransient<IRegionReportService, RegionReportService>();
            services.AddTransient<IHhRejectionReportService, HhRejectionReportService>();
            services.AddTransient<IDataRequestReportService, DataRequestReportService>();
            services.AddTransient<IGrievanceStatusReportService, GrievanceStatusReportService>();
            services.AddTransient<IHhInterviewStatusReportService, HhInterviewStatusReportService>();
            services.AddTransient<IDataSharingOtherReportService, DataSharingOtherReportService>();
            services.AddTransient<IUserloginlogouttimeServices, UserLoginlouttimeService>();
            services.AddTransient<ILoginLogoutReportService, LoginLogoutReportService>();
            services.AddTransient<IExternalDataRequestServiceDup, ExternalDataRequestServiceDup>();
            services.AddTransient<IClusterMasterService, ClusterMasterService>();
            services.AddTransient<IMemberInformationReportService, MemberInformationReportService>();
            services.AddTransient<IForgetPasswordMasterService, ForgetPasswordMasterService>();
            services.AddTransient<ICopingStrategyMasterService, CopingStrategyMasterService>();
            return services;
        }
    }
}