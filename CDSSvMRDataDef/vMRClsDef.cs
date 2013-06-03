using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CDSSvMRDataDef
{
    public class vMRClsDef
    {
        public class IEvMRInput//推理机输入数据类，获取推理所需的数据
        {
            public Role oRoles;//角色信息
            public List<InputDataModel> lstInputDataModel;//推理机输入数据模型

            public IEvMRInput()
            {
                oRoles = new Role();
                lstInputDataModel = new List<InputDataModel>();
            }
        }

        public class IEvMROutput//推理机输出信息类，输入推理机推理结果
        {
            public Role oRoles;//角色信息
            public List<OutputInfo> lstOutputInfo;//推理机输出信息模型

            public IEvMROutput()
            {
                oRoles = new Role();
                lstOutputInfo = new List<OutputInfo>();
            }
        }

        public class Role //角色类,用于标识IE输入信息
        {
            public Patient oPatient;//患者信息
            public Clinician oClinician;//医生信息

            public Role()
            {
                oPatient = new Patient();
                oClinician = new Clinician();
            }
        }

        public class Patient//患者类定义，用于标识IE输入信息，以患者为单位
        {
            public string strPatID;//患者ID，可以作为唯一标识符
            //以下信息属于辅助标识，可以不具备
            public string strPatName;//姓名          
            public string strPatSex;//性别
            public DateTime dtPatBirthday;//出生年月
            public string strPatBirthAddress;//地址

            public Patient()
            {
                strPatID = string.Empty;
                strPatName = string.Empty;
                strPatSex = string.Empty;
                dtPatBirthday = new DateTime();
                strPatBirthAddress = string.Empty;
            }
        }

        public class Clinician//医生类定义，用于标识IE输入信息，确定所使用知识的类型
        {
            public string strClinicianLevel;//用于标识CDSS的不同服务对象，可以预定义编码，也可以用枚举变量表示

            public Clinician()
            {
                strClinicianLevel = string.Empty;
            }
        }

        public class TriggeringEvent//触发推理信息类，作为入口信息，获取推理所需的信息并触发推理
        {
            public Event oEvent;
            public Disease oDisease;//疾病类对象，用来触发以疾病为入口的推理
            public Symptoms oSymptoms;//症状类对象，用来触发以症状为入口的推理
            //如果还有其他入口对象，可以进一步扩展
            public EnumInferenceType m_emInferenceType;
            public EnumInferenceResultType m_emInferenceResultType;
            public string strRuleName;


            public TriggeringEvent()
            {
                oEvent = new Event();
                oDisease = new Disease();
                oSymptoms = new Symptoms();
                m_emInferenceType = EnumInferenceType.PRIMARY;
                m_emInferenceResultType = EnumInferenceResultType.OTHER;
                strRuleName = string.Empty;
            }
        }

        public class Event
        {
            public string strEventName;
            public string strEventCNName;
            public string strEventCode;

            public Event()
            {
                strEventName = string.Empty;
                strEventCNName = string.Empty;
                strEventCode = string.Empty;
            }
        }

        public class Disease//疾病类
        {
            public string strDiseaseCode;//疾病编码，可作为唯一标识
            public string strDiseaseName;//疾病名称
            public string strDiseaseCNName;

            public Disease()
            {
                strDiseaseCode = string.Empty;
                strDiseaseName = string.Empty;
                strDiseaseCNName = string.Empty;
            }
        }

        public class Symptoms//症状类
        {
            public List<DataModel> lstSymptoms;//症状lsit

            public Symptoms()
            {
                lstSymptoms = new List<DataModel>();
            }
        }

        public class InputDataModel//推理机输入数据模型类
        {
            public TriggeringEvent oTriggeringEvent;//数据与触发事件相关
            public List<DataModel> lstDataModel;//数据模型list
            public InputDataModel()
            {
                oTriggeringEvent = new TriggeringEvent();
                lstDataModel = new List<DataModel>();
            }
        }

        public class OutputInfo//推理机输入结论类
        {
            public TriggeringEvent oTriggeringEvent;//输出结论与触发事件相关
            public Inference oInference;//推理机输出结论list
            public Explanation oExplanation;//解释器解释结果对象
            public List<DataModel> lstShortDataModel;//需补充的数据list

            public OutputInfo()
            {
                oTriggeringEvent = new TriggeringEvent();
                oInference = new Inference();
                oExplanation = new Explanation();
                lstShortDataModel = new List<DataModel>();
            }
        }

        public class DataModel//数据模型类
        {
            public string strDataCode;//数据编码，可作为数据的唯一标识
            public EnumDataSourceType m_emDataSourceType;//数据来源类型
            public EnumDataType m_emDataType;//数据结果类型
            public string strDataName;//数据名称
            public string strDataCNName;
            public string strDataValue;//数据值
            public Condition oDataCondtion;//数据有效条件
            public Unit oDataUnit;//数据单位

            public DataModel()
            {
                strDataCode = string.Empty;
                m_emDataSourceType = EnumDataSourceType.OTHER;
                m_emDataType = EnumDataType.OTHER;
                strDataName = string.Empty;
                strDataCNName = string.Empty;
                strDataValue = string.Empty;
                oDataCondtion = new Condition();
                oDataUnit = new Unit();
            }
        }

        public class UnStructMessage//非结构化消息类，用以表示推理结论和解释过程中的非结构化信息
        {
            public string strUnStructMessageCode;//非结构化消息编码
            public string strUnStructMessage;//非结构化消息具体内容

            public UnStructMessage()
            {
                strUnStructMessageCode = string.Empty;
                strUnStructMessage = string.Empty;
            }
        }

        public class Inference//推理结果信息类
        {
            public List<DataModel> lstStructedInferMessage;//结构化的推理结论
            public List<UnStructMessage> lstUnstructedInferenceMessage;//非结构化结论list

            public Inference()
            {
                lstStructedInferMessage = new List<DataModel>();
                lstUnstructedInferenceMessage = new List<UnStructMessage>();
            }
        }

        public class Explanation//解释结论类
        {
            public List<UnStructMessage> lstExplanationMessage;//解释结论list
            //未完，可能涉及到xml文件的传输
            public List<CLIPSInterpretation> lstClipsInterpretation;
            public Explanation()
            {
                lstExplanationMessage = new List<UnStructMessage>();
                lstClipsInterpretation = new List<CLIPSInterpretation>();
            }
        }

        public class CLIPSInterpretation
        {
            public string strInterpretationIndex;
            public List<string> lstRecomm;
            public List<string> lstFactUsed;

            public CLIPSInterpretation()
            {
                strInterpretationIndex = string.Empty;
                lstRecomm = new List<string>();
                lstFactUsed = new List<string>();
            }
        }

        public class Unit//数据单位类
        {
            public string strUnitCode;//数据单位编码
            public string strUnitName;//数据单位名称 

            public Unit()
            {
                strUnitCode = string.Empty;
                strUnitName = string.Empty;
            }
        }

        public class Condition//数据有效条件类
        {
            public DateTime dtStartTime;//起始时间
            public DateTime dtEndTime;//终止时间
            public DateTime dtIntervalTime;//时间间隔

            public Condition()
            {
                dtStartTime = new DateTime();
                dtEndTime = new DateTime();
                dtIntervalTime = new DateTime();
            }
        }

        public enum EnumDataType//数据类型定义
        {
            OTHER = 0,//其他
            INT = 1,//整型
            DOUBLE = 2,//double型
            FLOAT = 3,//float型
            BOOL = 4,//bool型
            STRING = 5//string型        
        }

        public enum EnumDataSourceType //数据源类型定义
        {
            OTHER = 0,
            BASICINFO = 1,//患者基本信息
            PATHISTORY = 2,//患者病史信息
            LAB = 3,//患者检验信息
            EXAM = 4,//患者检查信息
            PHYSICAL = 5 //患者体检信息
        }

        public enum EnumInferenceResultType//推理结果类型定义
        {
            OTHER = 0,
            DIAGNOSIS = 1,//诊断结论
            THERAPY = 2,//治疗建议
            ADVERSEEVENT = 3,//药物相互作用
            SELFMONITOR = 4,//自我监测建议
            DIETARY = 5,//饮食
            PHYSICALACTIVITY = 6,//运动
            RISKEVALUATION = 7,
            MSEVALUATION = 8
            //目前这么多，可以继续添加,与vMR class进行映射
        }

        //推理类型
        public enum EnumInferenceType
        {
            PRIMARY = 1,
            SECONDTIME = 2,
            NEEDSECONDTIME = 3,
        }

    }
}
