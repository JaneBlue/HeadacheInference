using System;
using System.Collections.Generic;
using System.Text;
using CDSSvMRDataDef;

namespace CDSSCLIPSEngine
{
    class ClipsEventsDef
    {
        //�¼�Ӣ��������
        public const string CONST_EVENTENNAME_HeadacheDiagnosis = "Headache_Diagnosis_Event";

        public static void MapEvent(string strEventName, ref vMRClsDef.TriggeringEvent oTriggeringEvent)
        {
            switch(strEventName)
            {
                case ClipsEventsDef.CONST_EVENTENNAME_HeadacheDiagnosis:
                    oTriggeringEvent.oDisease.strDiseaseCNName = "Headache_Diagnosis_Event";
                    oTriggeringEvent.m_emInferenceResultType = vMRClsDef.EnumInferenceResultType.DIAGNOSIS;
                    return;
                default:
                    return;
            }
          
        }
    }
}
