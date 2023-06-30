using SRIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using SRIS.Domain.Entities.MasterEntities;
using SRIS.Domain.Entities.MasterDepenciesEntities;
using SRIS.Domain.Entities.Grievance;
using SRIS.Domain.Entities.PMT;
using SRIS.Domain.Entities.SurveyPlanning;
using SRIS.Domain.Entities.Household;

namespace SRIS.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<Master> masters { get; set; }
        DbSet<ConfigureCommitee> m_grievance_configurecomittee { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<RelationMaster> m_master_relation { get; set; }
        DbSet<DeviceMngtMaster> m_master_deviceconfig { get; set; }
        DbSet<GlobalLinkMaster> m_adm_globallink { get; set; }
        DbSet<PrimaryLinkMaster> m_adm_primarylink { get; set; }
        DbSet<AccessLinkMaster> m_adm_linkaccess { get; set; }
        DbSet<MyUser> m_um_user { get; set; }

        //DbSet<PMTMaster> m_master_pmt { get; set; }
        //public DbSet<PMTMaster> m_pmt_category { get; set; }
        DbSet<PmtMasterN> m_pmt_category { get; set; }
        DbSet<Quantile> m_master_quantile { get; set; }
        public DbSet<ResortFoodCoping> m_master_resortfoodCoping { get; set; }
        DbSet<DocumentTypeMaster> m_master_documentType { get; set; }
        DbSet<NationalityMaster> m_master_nationalitytbl { get; set; }
        DbSet<OccupancyStatusMaster> m_master_occupancyStatus { get; set; }

        //changes by banaja on 13082021
        public DbSet<Incomeaiddetail> t_hhr_incomeaiddetail { get; set; }
        public DbSet<Incomesource> t_hhr_incomesource { get; set; }
        public DbSet<Housing> t_hhr_housing { get; set; }
        public DbSet<Chronicediseasedetails> t_hhr_chronicediseasedetails { get; set; }
        public DbSet<Demographicmember> t_hhr_demographicmember { get; set; }
        public DbSet<Employment> t_hhr_employment { get; set; }
        public DbSet<Education> t_hhr_education { get; set; }
        public DbSet<Livelyhoodcopingdetail> t_hhr_livelyhoodcopingdetail { get; set; }
        public DbSet<Incomeorgdetail> t_hhr_incomeorgdetail { get; set; }
        public DbSet<Cultivationresponsibility> t_hhr_cultivationresponsibility { get; set; }
        public DbSet<Impactofshocks> t_hhr_impactofshocks { get; set; }
        public DbSet<breedinglivestock> t_hhr_breedinglivestock { get; set; }
        public DbSet<Distance> t_hhr_distance { get; set; }
        public DbSet<Health> t_hhr_health { get; set; }
        public DbSet<Identitydocuments> t_hhr_identitydocuments { get; set; }
        public DbSet<MasterModule> m_master_module { get; set; }
        public DbSet<PMTParameterMaster> t_pmt_pmtparameter { get; set; }
        public DbSet<Survey_Plan> t_survey_surveyplanning { get; set; }
        public DbSet<MasterQuestion> M_Master_Questionnaire { get; set; }
        public DbSet<PMTConfigurationMaster> t_pmt_configuration { get; set; }
        public DbSet<PMTConfigCoefficient> t_pmt_config_coefficient { get; set; }
        public DbSet<ParameterMasterItem> m_masterparameter { get; set; }
        public DbSet<UserLogin_Logout_time> m_user_login_logout_time { get; set; }
        public DbSet<NotificationMasterTable> t_all_notification { get; set; }


        public DbSet<DoyouhaveBirthCertificate> m_master_doyouhavebirthcertificate { get; set; }
        public DbSet<Isfatherliveinhouse> m_master_Isfatherliveinhouse { get; set; }
        public DbSet<Ismotherstillalive> m_master_Ismotherstillalive { get; set; }
        public DbSet<Ismotherliveinhouse> m_master_Ismotherliveinhouse { get; set; }
        public DbSet<Gender> m_master_gender { get; set; }
        public DbSet<Isfatherstillalive> m_master_isfatherstillalive { get; set; }
        //end

        #region--------Mater Entities---------------------
        DbSet<ResidenceMaster> M_Master_Residence { get; set; }
        public DbSet<MaritalStatus> m_master_maritalstatus { get; set; }
        public DbSet<LevelMaster> m_adm_level { get; set; }
        public DbSet<LevelDetails> m_adm_leveldetails { get; set; }
        public DbSet<ResidenceStatus> m_master_residencestatus { get; set; }
        public DbSet<Nationality> m_master_nationality { get; set; }
        public DbSet<DocumentType> m_master_documentTypeapi { get; set; }
        public DbSet<Ethnicity> m_master_ethnicitymaster { get; set; }
        public DbSet<UpdaterequestDetails> t_update_requestdetail { get; set; }
        DbSet<EthnicityMaster> m_master_ethnicity { get; set; }
        public DbSet<Selfcareingdifficulty> m_master_Selfcareingdifficulty { get; set; }
        public DbSet<NeverAttendSchool> m_master_neverattendschool { get; set; }
        //public DbSet<Grade> m_master_grade { get; set; }
        public DbSet<ReasonForStopSchool> m_master_reasonforstopschool { get; set; }
        public DbSet<Disease> m_master_disease { get; set; }
        public DbSet<SeeingDifficulty> m_master_seeingdifficulty { get; set; }

        public DbSet<MainJobActivity> m_master_mainjobactivity { get; set; }
        public DbSet<WorkingFreequency> m_master_workingfreequency { get; set; }
        public DbSet<WorkingSector> m_master_workingsector { get; set; }
        public DbSet<WorkingStatus> m_master_workingstatus { get; set; }
        public DbSet<ReasonForNotWorking> m_master_reasonfornotworking { get; set; }
        public DbSet<WallSubCategory> m_master_wallsubcategory { get; set; }
        public DbSet<WallCategory> m_master_wallcategory { get; set; }
        public DbSet<RoffingMaterialCategory> m_master_roffingmaterialcategory { get; set; }
        public DbSet<FlooringMaterialCategory> m_master_flooringmaterialcategory { get; set; }
        public DbSet<LightingSource> m_master_lightingsource { get; set; }
        public DbSet<CookingFuel> m_master_cookingfuel { get; set; }
        public DbSet<ToiletType> m_master_toilettype { get; set; }
        public DbSet<DrinkingSource> m_master_drinkingsource { get; set; }
        public DbSet<DisposeRubbish> m_master_disposerubbish { get; set; }
        public DbSet<TransportationMode> m_master_transportationmode { get; set; }
        public DbSet<MainIncomeSource> m_master_incomesource { get; set; }
        public DbSet<AidType> m_hhr_aid { get; set; }
        public DbSet<AidFreequency> m_master_aid_freequency { get; set; }
        public DbSet<OrganizatonType> m_master_organizatontype { get; set; }

        public DbSet<LiveStock> m_master_livestock { get; set; }
        public DbSet<LiveliHood> m_master_livelihood { get; set; }
        public DbSet<Shocks> m_master_shocks { get; set; }
        public DbSet<shocksSeverityMaster> m_master_severity { get; set; }
        public DbSet<CopingStrategyMaster> m_master_coping { get; set; }

        public DbSet<GradeLevelMaster> m_master_grade { get; set; }

        public DbSet<ResonforNeverAttendSchool> m_master_reasonforneverattendschool { get; set; }
        //public DbSet<WallSubCategory> m_master_wallsubcategory { get; set; }
        public DbSet<FlooringMaterialSubCategory> m_master_flooringmaterialsubcategory { get; set; }
        public DbSet<RoffingMaterialSubCategory> m_master_roffingmaterialsubcategory { get; set; }
        public DbSet<ServicesMaster> m_master_services { get; set; }
        public DbSet<ConstrMatCategory> m_master_constrmatcategory { get; set; }
        public DbSet<ConstrMatSubCategory> m_master_constrmatsubcategory { get; set; }

        public DbSet<MediumMaster> m_master_medium { get; set; }
        public DbSet<Crop> m_master_crop { get; set; }
        public DbSet<GrievanceComplaints> t_grievance_registration { get; set; }
        public DbSet<GrievanceResolution> m_grievance_resolution { get; set; }
        public DbSet<ConfigureGrievance> m_grievance_configuregrievance { get; set; }
        public DbSet<GrievanceResolutionStatus> m_grievance_resolutionstatus { get; set; }

        #endregion
        #region--------Survey Planning Entities---------------------
        DbSet<assigneddevice> t_survey_assigneddevice { get; set; }
        public DbSet<TSurveyEnumerationArea> t_survey_enumerationarea { get; set; }
        public DbSet<MSurveyEnumerationArea> m_survey_enumerationarea { get; set; }
        public DbSet<SettlementWiseTarget> t_survey_settlementwisetarget { get; set; }

        #endregion
        #region Grievance Module 
        DbSet<RegisterMember> m_grievance_registermember { get; set; }
        DbSet<ConfigurePosition> m_grievance_configureposition { get; set; }
        DbSet<GrievanceForward> t_grievance_forward { get; set; }
        DbSet<GrievanceStatus> t_grievance_status { get; set; }
        DbSet<GrievanceAssignSurveyManager> t_grievance_assignsurveymanager { get; set; }
        #endregion
        public DbSet<UserRoleMaster> m_um_UserRole { get; set; }
        public DbSet<placeofbirth> m_master_placeofbirth { get; set; }
        public DbSet<AssignLinkToRoleMaster> m_adm_assignlinkrolewise { get; set; }
        public DbSet<RegisterHouseholdServey> t_hhr_registerhousehold { get; set; }
        public DbSet<SurveyTeamMaster> m_survey_team { get; set; }
        public DbSet<SurveyTeamDetails> t_survey_teamdetail { get;set;}
        public DbSet<UMUserLocation> t_user_userlocation { get; set; }
        public DbSet<UpdCatagoryDetails> t_update_updatecatagorydetails { get; set; }

        #region PMT Results
        DbSet<PMTResult> t_pmt_pmtresult { get; set; }
        DbSet<PMTResultParameter> t_pmt_pmtresult_parameter { get; set; }
        DbSet<PMTScore> T_PMT_PMTScore { get; set; }
        DbSet<ExternalDataOther> t_datarequest_GenerateData1 { get; set; }
        #endregion

        #region Feedback
        DbSet<Paymentprogramdtls> t_feedback_paymentprogramdtls { get; set; }
        DbSet<PaymentDetail> t_feedback_paymentdetail { get; set; }
        DbSet<ProgramDetails> t_feedback_programdtls { get; set; }
        DbSet<BeneficiaryDetail> t_feedback_benificiarydetail { get; set; }
        #endregion
        DbSet<Purpose> m_master_purpose { get; set; }
        DbSet<RelationsToProjectMaster> m_master_relationofproject { get; set; }
        public DbSet<HearingDifficulty> m_master_Hearingdifficulty { get; set; }
        public DbSet<WalkingDifficulty> m_master_Walkingdifficulty { get; set; }
        public DbSet<RememberingDifficulty> m_master_Rememberingdifficulty { get; set; }
        public DbSet<CommunicatingDifficulty> m_master_Communicatingdifficulty { get; set; }
        public DbSet<Assets> m_master_asset { get; set; }
        public DbSet<ContactType> m_master_Contacttype { get; set; }
        public DbSet<TypeOfSchoolEntities> m_master_Schooltype { get; set; }
        public DbSet<EcologyMasterEntity> m_master_typeofecology { get; set; }
        public DbSet<SecondIncomeSourceMasterEntity> m_master_second_incomesource { get; set; }
        public DbSet<ReadWriteAnyLanguageMasterEntity> m_master_readwriteanylanguage { get; set; }
        public DbSet<ResortLivelihoodCopingMasterEnity> m_master_resortLivelhoodCoping { get; set; }
        public DbSet<LastLevelGradeMasterEntity> m_master_lastlevelgrade { get; set; }
        public DbSet<CopingTypeMasterEntity> m_master_copingtype { get; set; }

    }
}