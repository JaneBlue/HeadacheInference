using System;
using System.Collections.Generic;
using System.Text;

namespace CDSSFunction
{
    public class FunctionTypeDef
    {
        /// <summary>
        /// 推理触发事件定义
        /// </summary>
        public class EventModels
        {
            public string strEventENName;
            public string strEventCNName;

            public Disease oDisease;
            public List<Symptom> lstSymptoms;
            public EnumInferenceType em_InferneceType;
            public EnumInferenceResultType em_InferenceResultType;

            public EventModels()
            {
                strEventENName = string.Empty;
                strEventCNName = string.Empty;

                oDisease = new Disease();
                lstSymptoms = new List<Symptom>();
                em_InferneceType = EnumInferenceType.PRIMARY;
                em_InferenceResultType = EnumInferenceResultType.OTHER;
            }
            
        }

        public class Disease
        {
            public string strDiseaseName;
            public string strDiseaseCNName;
            public string strDiseaseCode;

            public Disease()
            {
                strDiseaseName = string.Empty;
                strDiseaseCNName = string.Empty;
                strDiseaseCode = string.Empty;
            }
        }

        /// <summary>
        /// 触发推理的症状定义
        /// </summary>
        public class Symptom
        {
            public string strSymptomENName;
            public string strSymptomCNName;
            public string strSymptomCode;
            public string strSymptomValue;

            public Symptom()
            {
                strSymptomCNName = string.Empty;
                strSymptomENName = string.Empty;
                strSymptomCode = string.Empty;
                strSymptomValue = string.Empty;
            }
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
