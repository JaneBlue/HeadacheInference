using System;
using System.Collections.Generic;
using System.Text;


namespace CDSSSystemData
{
    /// <summary>
    /// 当前登录用户信息
    /// </summary>
    public class CDSSUserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID;
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName;
        /// <summary>
        /// 所属部门
        /// </summary>
        public string Department;
        /// <summary>
        /// 职务
        /// </summary>
        public string Title;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone;
        /// <summary>
        /// 单位
        /// </summary>
        public string Company;
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string MailAddress;
        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LastLoginTime;
        /// <summary>
        /// 登录次数
        /// </summary>
        public int LoginFrequency;
        /// <summary>
        /// 登录时连接DB的时间
        /// </summary>
        public DateTime LoginConnDBTime;
        /// <summary>
        /// 保存案例的时间
        /// </summary>
        public DateTime SaveCaseTime;
        /// <summary>
        /// 当前软件版本信息
        /// </summary>
        public string CurrentAppVer;

        public CDSSUserInfo()
        {
            Clear();
        }

        /// <summary>
        ///恢复默认值
        /// </summary>
        public void Clear()
        {
            this.UserID = String.Empty;
            this.UserName = String.Empty;
            this.Department = String.Empty;
            this.Title = String.Empty;
            this.Phone = String.Empty;
            this.Company = String.Empty;
            this.MailAddress = String.Empty;
            this.LastLoginTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            this.LoginFrequency = 0;
            this.LoginConnDBTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            this.SaveCaseTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            CurrentAppVer = String.Empty;
        }
    }

    #region 病人基本信息

    /// <summary>
    /// 病人基本信息
    /// </summary>
    public class CDSSPatBasicInfo
    {   
        /// <summary>
        /// 病人唯一识别号
        /// </summary>
        public string RecordID;
        /// <summary>
        /// 电子病历号
        /// </summary>
        public string EHRID;
        /// <summary>
        /// 就诊ID
        /// </summary>
        public int VisitID;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name;
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex;
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age;
        /// <summary>
        /// 初步诊断
        /// </summary>
        public string InitialDiagnosis;
        /// <summary>
        /// 备注
        /// </summary>
        public string  Remark;
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday;
        /// <summary>
        /// 家庭住址
        /// </summary>
        public string HomeAddress;
        /// <summary>
        /// 家庭电话
        /// </summary>
        public string HomePhone;
        /// <summary>
        /// 手机
        /// </summary>
        public string  MobilePhone;
        /// <summary>
        /// 身份证
        /// </summary>
        public string Identity;
        /// <summary>
        /// 职业
        /// </summary>
        public string Profession;
        /// <summary>
        /// 教育程度
        /// </summary>
        public string Education;
        /// <summary>
        /// 收入
        /// </summary>
        public string AnnualIncome;
       
        /// <summary>
        /// 身高
        /// </summary>
        public decimal Height;
        /// <summary>
        /// 体重
        /// </summary>
        public decimal Weight;
        public DateTime VisitDate;

        public CDSSPatBasicInfo()
        {
            Clear();
        }

        /// <summary>
        ///恢复默认值
        /// </summary>
        public void Clear()
        {
            RecordID = string.Empty;
            EHRID = string.Empty;
            VisitID = 0;
            Name = string.Empty;
            Sex = string.Empty;
            Age = 0;
            InitialDiagnosis = string.Empty;
            Remark = string.Empty;
            Birthday  = DateTime.Now.Date;
            HomeAddress = string.Empty;
            HomePhone = string.Empty;
            MobilePhone = string.Empty;
            Identity  = string.Empty;
            Profession = string.Empty;
            Education = string.Empty;
            AnnualIncome = string.Empty;
            Height = 0;
            Weight = 0;
            VisitDate = DateTime.Now.Date;
        }
    }

    #endregion
    #region 继发性头痛判断

    /// <summary>
    /// 继发性头痛指标
    /// </summary>
    public class CDSSSecondHeadacheSign
    {
        public bool SuddenHeadache;
        public bool Worsenheadache;
        public bool SystemSymbolHeadache;
        public bool NervousSystemHeadache;
        public bool CognitiveDisorderheadache;
        public bool Papilledemaheadache;
        public bool CoughHeadache;
        public bool  CancerAidsHeadache;
        public bool  AfterFiftyHeadache;
        public CDSSSecondHeadacheSign()
        {
            Clear();
        }
        public void Clear()
        {
            SuddenHeadache = false;
            Worsenheadache = false;
           SystemSymbolHeadache = false;
           NervousSystemHeadache = false;
           CognitiveDisorderheadache = false;
            Papilledemaheadache= false;
           CoughHeadache = false;
           CancerAidsHeadache = false;
           AfterFiftyHeadache = false;
        }
    }
    #endregion


    #region 头痛概述

    public class HeadachePlus1
    {
        public string Sympton;
        public string Strength;
    }

    public class HeadachePlus2 //先兆、前驱、诱发、缓解、头痛部位
    {
        public string Aspect;
        public string AspectName;
        public string Note;
    }
    
    public class CDSSHeadacheAnnotation
    {
        public string HeadacheTrait;

        public DateTime RecentTime;

        public string HeadacheNow;

        public DateTime BeginTime;

        public string BTNote;

        public string BeginForm;

        public string DayFrequency; // become useful  2012.8.20
        public string MonthFrequency;//add 2012.8.20
        public string MonthHeadache;//add 2012.8.20
        public string MHeadacheday;//add 2012.8.20
        public string HeadacheEveryDay;//add 2012.8.27
        public string WeekdayRelated;

        public string SeasonFixed;
        public string DayTimeFixed;

        public string TimeFixed;

        public string TFNote;

        public string MensesRelated;

        public string Description;

        public string  Frequency;

        public string FrequencyUnit;
        public string FrequencyDescription;

        public float LastTimeBefore;

        public string LastTimeBeforeUnit;

        public int LastTimeAfter;

        public string LastTimeAfterUnit;

        public int MarkNum;

        public string Markqualitative;

        public string WorsenByMenses;

        public string HeadacheType;

        public string EffectFrequency;

        public string EffectDegree;

        public string WorsenDegree;

        public string BedRelax;

        public string RegionChange;

        public string FirstRelief;  // new  2012.8.18 by fgj
        public string EveryRelief;// new  2012.8.18 by fgj
        public string CDSSResult; // new 2012.9.18 by fgj
        public string FinalResult;//new 2012.9.18 by fgj

      //  public List<HeadachePlus1> HeadacheCompanionSympton;  revised by fgj 2012.8.21
        public List<string> HeadacheCompanionSympton;
        public List<HeadachePlus2> HeadacheAura;// 头痛先兆

        public List<HeadachePlus2> HeadacheProdrome;

        public List<HeadachePlus2> HeadachePrecipitating;

        public List<HeadachePlus2> HeadacheRelaase;
        public List<HeadachePlus2> HeadachePosition;

        public int nHeadahce_Duration;//added by yzm 2013.5.30
        public string Unilateral;
        public string Bilateral;

        public CDSSHeadacheAnnotation()
        {
            HeadacheCompanionSympton = new List<string>();
            HeadacheAura = new List<HeadachePlus2>();
            HeadacheProdrome = new List<HeadachePlus2>();
            HeadachePrecipitating = new List<HeadachePlus2>();
            HeadachePosition = new List<HeadachePlus2>();
            HeadacheRelaase=new List<HeadachePlus2>();
            Clear();
        }
        public void Clear()
        {
            HeadacheTrait = string.Empty;
            RecentTime = DateTime.Now.Date;
            HeadacheNow = string.Empty;
            BeginTime = DateTime.Now.Date;
            BTNote = string.Empty;
            BeginForm = string.Empty;
            DayFrequency = string.Empty;
            MonthFrequency = string.Empty;//add 2012.8.20
            MonthHeadache = string.Empty;//add 2012.8.20
            MHeadacheday = string.Empty;//add 2012.8.20
            HeadacheEveryDay = string.Empty;//add 2012.8.27
            WeekdayRelated = string.Empty;
            TimeFixed = string.Empty;
            TFNote = string.Empty;
            MensesRelated = string.Empty;
            Description = string.Empty;
            Frequency = string.Empty;
            FrequencyUnit = string.Empty;
            FrequencyDescription = string.Empty;
            LastTimeBefore = 0;
            LastTimeBeforeUnit = string.Empty;
            LastTimeAfter = 0;
            LastTimeAfterUnit = string.Empty;
            MarkNum = 0;
            Markqualitative = string.Empty;
            WorsenByMenses = string.Empty;
            HeadacheType = string.Empty;
            EffectFrequency = string.Empty;
            EffectDegree = string.Empty;
            WorsenDegree = string.Empty;
            BedRelax = string.Empty;
            RegionChange = string.Empty;
            HeadacheCompanionSympton.Clear();
            HeadacheAura.Clear();
            HeadacheProdrome.Clear();
            HeadachePrecipitating.Clear();
            HeadachePosition.Clear();
            HeadacheRelaase.Clear();
            FirstRelief = string.Empty;//add 2012.8.20
            EveryRelief = string.Empty;//add 2012.8.20
            CDSSResult = string.Empty;  // new 2012.9.18 by fgj
           FinalResult = string.Empty;//new 2012.9.18 by fgj
           SeasonFixed = string.Empty;
          DayTimeFixed =string .Empty;
        }
    }

    #endregion

    #region 体格检查

    public class CDSSPhysicalExam
    {
        public string GeneralSituation; //DB

        public decimal Height;

        public decimal Temperature;

        public decimal Weight;

        public int HeartRate;

        public string HeartRhythm; //DB

        public int BreathRate;

        public int FirstSystolicPressure;

        public int FirstDiastolicPressure;

        public string FirstMeasurePosition;

        public string FirstMeasureRegion;

        public int SecondSystolicPressure;

        public int SecondDiastolicPressure;

        public string SecondMeasurePosition;

        public string SecondMeasureRegion;

        public string MentalStatus;

        public string EyeAppearance;

        public string FunduScope;

        public string VisualAcuity;

        public string Eyeshot;

        public string HeadNeck;

        public string Mater;

        public string Cardiovascular;

        public string Carotid;

        public string Lung;

        public string Adbomen;

        public string Orientation;

        public string Memory;

        public string Attention;

        public string Words;

        public string Behavior;

        public string Emotion;

        public string CranialNerve;

        public string Sport;

        public string Feeling;

        public string UnknowSport;

        public string CoordinateMovement;

        public string AutomaticNervousSystem;

        public string ANSNote;

        public string WalkPose;
        public CDSSPhysicalExam()
        {
            Clear();

        }
        public void Clear()
        {
            GeneralSituation = string.Empty;
            Height = 0;
            Temperature = 0;
            Weight = 0;
            HeartRate = 0;
            HeartRhythm = string.Empty;
            BreathRate = 0;
            FirstSystolicPressure=0;
            FirstDiastolicPressure = 0;
            FirstMeasurePosition = string.Empty;
            FirstMeasureRegion = string.Empty;
            SecondSystolicPressure = 0;
            SecondDiastolicPressure = 0;
            SecondMeasurePosition = string.Empty;
            SecondMeasureRegion = string.Empty;
            MentalStatus = string.Empty;
            EyeAppearance = string.Empty;
            FunduScope = string.Empty;
            VisualAcuity = string.Empty;
            Eyeshot = string.Empty;
            HeadNeck = string.Empty;
            Mater = string.Empty;
            Cardiovascular = string.Empty;
            Carotid = string.Empty;
            Lung = string.Empty;
            Adbomen = string.Empty;
            Orientation = string.Empty;
            Memory = string.Empty;
            Attention = string.Empty;
            Words = string.Empty;
            Behavior = string.Empty;
            Emotion = string.Empty;
            CranialNerve = string.Empty;
            Sport = string.Empty;
            Feeling = string.Empty;
            UnknowSport = string.Empty;
            CoordinateMovement = string.Empty;
            AutomaticNervousSystem = string.Empty;
            ANSNote = string.Empty;
            WalkPose = string.Empty;


        }
    }

    #endregion

    #region 既往评估/治疗
    public class PastTreatDept
    {
       public  string Department;
       public  string Effect;
    }
    public class PastExam
    {
       public  string ExamPart;
       public string ExamResult;
       public  DateTime ExamDate;
       public  string Description;
       public  string ExamID;
    }
    public class Drug
    {
        public string DrugRemedy;//数据库需要
        public string DrugKind;
        public string DrugName;
        public string DrugAmount;
        public string DrugUse;
        public string DrugEffect;
        public string DSideEffect;
        
    }
    public class PastTreatNonDrug
    {
        public string NonDrugRemedy;
    }
    public class CDSSPreviousTreatment
    {
        public List<PastTreatDept> PreviousDept;
        public List<PastExam> PreviousExam;
        public List<Drug> PreviousDefendDrug;
        public List<Drug> PreviousAcesodyneDrug;
        public List<PastTreatNonDrug> PreviousNonDrug;
        public CDSSPreviousTreatment()
        {
            PreviousDept = new List<PastTreatDept>();
            PreviousExam = new List<PastExam>();
            PreviousDefendDrug = new List<Drug>();
            PreviousAcesodyneDrug = new List<Drug>();
            PreviousNonDrug = new List<PastTreatNonDrug>();
            Clear();
        }
        public void Clear()
        {
            PreviousDept.Clear();
            PreviousExam.Clear();
            PreviousDefendDrug.Clear();
            PreviousAcesodyneDrug.Clear();
            PreviousNonDrug.Clear();
        }
    }

    #endregion

    #region 评估与诊断
    public class Dianosis
    {
        public string TypeI;
        public string TypeII;
        public string TypeIII;
        public DateTime DiagnoseTime;
    }
    public class CDSSEvaluationAndDiagnosis
    {
        public string MainSuit;
        public string DefendDrugEffect;
        public string AcesodyneEffect;
        public string NonDrugEffect;
        public string Problem;
        public List<Dianosis> HeadacheDiagnosis;
        public CDSSEvaluationAndDiagnosis()
        {
            HeadacheDiagnosis = new List<Dianosis>();
            Clear();
        }
        public void Clear()
        {
            MainSuit = string.Empty;
            DefendDrugEffect = string.Empty;
            AcesodyneEffect = string.Empty;
            NonDrugEffect = string.Empty;
            Problem = string.Empty;
            HeadacheDiagnosis.Clear();

        }
    }

    #endregion

    #region 治疗与处理

    public class RemedyDrug
    {
        public string DrugClass;
        public string Drugcategory;
        public string DName;
        public string DAmount;
        public string DUse;
        public string DEffect;
        public string DSideEffect;

    }
    public class RemedyUnDrug
    {
        public string AspectName;
        public string Note1;
        public string Note2;
    }
    public class CDSSTreatment
    {
        public List<Drug> CommonDrug;
        public List<Drug> DefendDrug;
        public List<Drug> Acutedrug;
        public List<RemedyUnDrug> NoDrugTreatment;
        public List<RemedyUnDrug> PatientEducate;
        public List<RemedyUnDrug> OtherPlan;
        public CDSSTreatment()
        {
            CommonDrug = new List<Drug>();
            DefendDrug = new List<Drug>();
            Acutedrug = new List<Drug>();
            NoDrugTreatment = new List<RemedyUnDrug>();
            PatientEducate = new List<RemedyUnDrug>();
            OtherPlan = new List<RemedyUnDrug>();
            Clear();
        }
        public void Clear()
        {

            CommonDrug.Clear();
            DefendDrug.Clear();
            Acutedrug.Clear();
            NoDrugTreatment.Clear();
            PatientEducate.Clear();
            OtherPlan.Clear();

        }
    }

    #endregion

    #region 近期生活和残障评估
    public class LifeQuality
    {
        public string Question1;  
        public string Question2;      
        public string Question3;    
        public string Question4;     
        public string Question5;      
        public string Question6;    
        public string Question7;     
        public string Question8;    
        public string Question9;      
        public string Question10;    
        public string Question11;   
        public string Question12;      
        public int Question13;
    }
    public class PhysicalDisability
    {
        public int Question1;
        public int Question2;
        public int Question3;
        public int Question4;
        public int Question5;
        public int Question6;
        public int Question7;
    }

    public class CDSSRecentLife
    {
        public List<LifeQuality> RecentLifeQuality;
        public List<PhysicalDisability> RecentDisability;
        public CDSSRecentLife()
        {
            RecentLifeQuality = new List<LifeQuality>();
            RecentDisability = new List<PhysicalDisability>();
            Clear();
        }
        public void Clear()
        {
            RecentDisability.Clear();
            RecentLifeQuality.Clear();
        }
    }

    #endregion

    #region 系统回顾
    public class BodyReview
    {
        public string Body;// 数据库
       public string Symptom;
       public string Note;
    }

    public class CDSSSystemiticEvaluation
    {
        public List<BodyReview> BodySituation;
        public List<BodyReview> Eye;
        public List<BodyReview> Ear;
        public List<BodyReview> Cardiovascular;
        public List<BodyReview> Breath;
        public List<BodyReview> GastrointestinalTract;
        public List<BodyReview> MaleSystem;
        public List<BodyReview> FemaleSystem;
        public List<BodyReview> MuscleBone;
        public List<BodyReview> Skin;
        public List<BodyReview> Neurology;
        public List<BodyReview> Spirit;
        public List<BodyReview> Incretion;
        public List<BodyReview> LymphaticSystem;
        public List<BodyReview> ImmuneSystem;
        public CDSSSystemiticEvaluation()
        {
            BodySituation = new List<BodyReview>();
            Eye = new List<BodyReview>();
            Ear = new List<BodyReview>();
            Cardiovascular = new List<BodyReview>();
            Breath = new List<BodyReview>();
            GastrointestinalTract = new List<BodyReview>();
            MaleSystem = new List<BodyReview>();
            FemaleSystem = new List<BodyReview>();
            MuscleBone = new List<BodyReview>();
            Skin = new List<BodyReview>();
            Neurology = new List<BodyReview>();
            Spirit = new List<BodyReview>();
            Incretion = new List<BodyReview>();
            LymphaticSystem = new List<BodyReview>();
            ImmuneSystem = new List<BodyReview>();
            Clear();
        }
        public void Clear()
        {
            BodySituation.Clear();
            Eye.Clear();
            Ear.Clear();
            Cardiovascular.Clear();
            Breath.Clear();
            GastrointestinalTract.Clear();
            MaleSystem.Clear();
            FemaleSystem.Clear();
            MuscleBone.Clear();
            Skin.Clear();
            Incretion.Clear();
            LymphaticSystem.Clear();
            ImmuneSystem.Clear();

        }
    }

    #endregion

    #region 生活方式和既往病史
    public class DiseaseBeore
    {
       public string  DiseaseKind;
       public string  Note;
    }
    public class CDSSLifeStyleAndDiseaseHistory
    {
        public string Smoke;
        public int SMBeginAge;
        public int SMAmount;
        public int SMYear;
        public int UnSMYear;
        public string Drink;
        public int DRAge;
        public int DRYear;
        public int UnDRYear;
        public int DRAmount;
        public string DRKind;
        public int TeaAmount;
        public int CofeAmount;
        public string ExerciseAmount;
        public string EXTime;
        public string EXDescription;
        public string SpecialDiet;
        public string DietKind;//若有多个选择，用逗号隔开
        public string WeightChange;
        public string WCDescription;
        public string OtherLifestyle;
        public List<DiseaseBeore> DiseaseHistory;
        public CDSSLifeStyleAndDiseaseHistory()
        {
            DiseaseHistory = new List<DiseaseBeore>();
            Clear();
        }
        public void Clear()
        {
            Smoke = string.Empty;
            SMBeginAge = 0;
            SMAmount = 0;
            SMYear = 0;
            UnSMYear = 0;
            Drink = string.Empty;
            DRAge = 0;
            DRYear = 0;
            UnDRYear = 0;
            DRAmount = 0;
            DRKind = string.Empty;
            TeaAmount = 0;
            CofeAmount = 0;
            ExerciseAmount = string.Empty;
            EXTime = string.Empty;
            EXDescription = string.Empty;
            SpecialDiet = string.Empty;
            DietKind = string.Empty;
            WeightChange = string.Empty;
            WCDescription = string.Empty;
            OtherLifestyle = string.Empty;
            DiseaseHistory.Clear();

        }
    }

    #endregion

    #region 家族史

    public class RelativeOfHeadache
    {
        public string people;
    }
    public class DetailInfo
    {
        public string DiseaseClassify;
        public string Note;//心脏病需要在两个描述中加分号

    }
    
    public class CDSSFamilyHistory
    {
        public string HeadacheRelative;
        public string SimilarHeadache;
        public List<DetailInfo> Realtives;
        public List<DetailInfo> Diseases;
        public CDSSFamilyHistory()
        {
            Realtives = new List<DetailInfo>();
            Diseases = new List<DetailInfo>();
            Clear();
        }
        public void Clear()
        {
            HeadacheRelative = string.Empty;
            SimilarHeadache = string.Empty;
            Realtives.Clear();
            Diseases.Clear();
        }
    }

    #endregion

    #region 诊断结果

    /// <summary>
    /// 一种疾病的诊断结论
    /// </summary>
    public class CDSSOneDiseaseDiagnosedResult
    {
        /// <summary>
        /// 疾病名称
        /// </summary>
        public string Name;
        /// <summary>
        /// 结论
        /// </summary>
        public string Result;
        /// <summary>
        /// 治疗目标
        /// </summary>
        public string TreatmentTarget;
        /// <summary>
        /// 治疗建议
        /// </summary>
        public string TreatmentSuggestion;
        /// <summary>
        /// 自我监测
        /// </summary>
        public string SelfCheck;
        /// <summary>
        /// 所缺数据
        /// </summary>
        public string DataNeeded;
        /// <summary>
        /// 诊断过程
        /// </summary>
        public string DiagnosisSteps;

        public CDSSOneDiseaseDiagnosedResult()
        {
            Clear();
        }

        /// <summary>
        /// 恢复默认值
        /// </summary>
        public void Clear()
        {
            Name = String.Empty;
            Result = String.Empty;
            TreatmentTarget = String.Empty;
            TreatmentSuggestion = String.Empty;
            SelfCheck = String.Empty;
            DataNeeded = String.Empty;
            DiagnosisSteps = String.Empty;
        }

        public CDSSOneDiseaseDiagnosedResult Clone()
        {
            CDSSOneDiseaseDiagnosedResult newResult = new CDSSOneDiseaseDiagnosedResult();
            newResult.Name = this.Name;
            newResult.Result = this.Result;
            newResult.TreatmentTarget = this.TreatmentTarget;
            newResult.TreatmentSuggestion = this.TreatmentSuggestion;
            newResult.SelfCheck = this.SelfCheck;
            newResult.DataNeeded = this.DataNeeded;
            newResult.DiagnosisSteps = this.DiagnosisSteps;

            return newResult;
        }
    }

    /// <summary>
    /// 多种疾病诊断结论列表
    /// </summary>
    public class CDSSDiseaseDiagnosedResultList : List<CDSSOneDiseaseDiagnosedResult> { }


    /// <summary>
    /// 诊断结论
    /// </summary>
    public class CDSSDiagnosedResult
    {
        /// <summary>
        /// 是否有代谢综合征
        /// </summary>
        public string HasMS;
        /// <summary>
        /// 代谢综合征危险度积分
        /// </summary>
        public string RiskDegreeCode;
        /// <summary>
        /// 代谢综合征危险度
        /// </summary>
        public string RiskDegree;
        /// <summary>
        /// 各种疾病的推理结果(医生确认后的结论)
        /// </summary>
        public CDSSDiseaseDiagnosedResultList DiseaseDiagnosedResultList;
        /// <summary>
        /// 各种疾病的推理结果(推理机得出的结论)
        /// </summary>
        public CDSSDiseaseDiagnosedResultList ReasoningDiseaseDiagnosedResultList;

        public List<string> Diseases;

        public CDSSDiagnosedResult()
        {
            DiseaseDiagnosedResultList = new CDSSDiseaseDiagnosedResultList();
            ReasoningDiseaseDiagnosedResultList = new CDSSDiseaseDiagnosedResultList();
            Diseases = new List<string>();
            Clear();
        }

        /// <summary>
        /// 恢复默认值
        /// </summary>
        public void Clear()
        {
            HasMS = String.Empty;
            RiskDegreeCode = String.Empty;
            RiskDegree = String.Empty;
            DiseaseDiagnosedResultList.Clear();
            ReasoningDiseaseDiagnosedResultList.Clear();
            Diseases.Clear();
        }


    }

    #endregion
}
