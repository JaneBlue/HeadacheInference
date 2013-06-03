using System;
using System.Collections.Generic;
using System.Text;

namespace CDSSFunction
{
    public class FunctionTypeDef
    {
        /// <summary>
        /// �������¼�����
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
        /// ���������֢״����
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

        public enum EnumInferenceResultType//���������Ͷ���
        {
            OTHER = 0,
            DIAGNOSIS = 1,//��Ͻ���
            THERAPY = 2,//���ƽ���
            ADVERSEEVENT = 3,//ҩ���໥����
            SELFMONITOR = 4,//���Ҽ�⽨��
            DIETARY = 5,//��ʳ
            PHYSICALACTIVITY = 6,//�˶�
            RISKEVALUATION = 7,
            MSEVALUATION = 8
        }

        //��������
        public enum EnumInferenceType
        {
            PRIMARY = 1,
            SECONDTIME = 2,
            NEEDSECONDTIME = 3,
        }
    }
}
