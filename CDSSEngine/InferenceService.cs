using System;
using System.Collections.Generic;
using System.Text;
using CDSSvMRDataDef;
using CDSSCLIPSEngine;

namespace CDSSEngine
{
    class InferenceService
    {
        /// <summary>
        /// �������������������
        /// </summary>
        /// <param name="oRoles"></param>
        /// <param name="lstDataModelForIE"></param>
        /// <param name="oIEOutputInfo"></param>
        /// <returns></returns>
        public static bool BeginInference(
            vMRClsDef.Role oRoles,
            List<vMRClsDef.DataModel> lstDataModelForIE, 
            ref vMRClsDef.OutputInfo oIEOutputInfo)
        {
            ForwardsInference(oRoles, lstDataModelForIE, ref oIEOutputInfo);
            BackwardsInference();
            return true;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="oRoles"></param>
        /// <param name="lstDataModelForIE"></param>
        /// <param name="oIEOutputInfo"></param>
        /// <returns></returns>
        public static bool ForwardsInference(
            vMRClsDef.Role oRoles, 
            List<vMRClsDef.DataModel> lstDataModelForIE,
            ref vMRClsDef.OutputInfo oIEOutputInfo)
        {

            string strRuleLevel = ChooseRuleLevelWithRole(oRoles);
            if (strRuleLevel != string.Empty)
            {
                return ReasonWithCLIPSEngine(strRuleLevel, lstDataModelForIE, ref oIEOutputInfo);
            }
            else
            {
                return false;
            }

            
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public static bool BackwardsInference()
        {
            //��������ʵ��
            //�մ��룬����չ
            return true;
        }

        /// <summary>
        /// ����User��ɫѡ��Rule Level
        /// </summary>
        /// <param name="oRoles"></param>
        /// <returns></returns>
        public static string ChooseRuleLevelWithRole(vMRClsDef.Role oRoles)
        {
            string strRoleLevel = oRoles.oClinician.strClinicianLevel;
            switch (strRoleLevel)
            {
                default:
                    //���ݽ�ɫѡ�����
                    return "LEVEL_CLINICIANS";
            }
        }

        private static ClipsEngine oClipsEngine = new ClipsEngine();

        /// <summary>
        /// ʹ��CLIPS���������������
        /// </summary>
        /// <param name="strRuleLevel"></param>
        /// <param name="lstDataModelForIE"></param>
        /// <param name="oIEOutputInfo"></param>
        /// <returns></returns>
        public static bool ReasonWithCLIPSEngine(string strRuleLevel, List<vMRClsDef.DataModel> lstDataModelForIE,
            ref vMRClsDef.OutputInfo oIEOutputInfo)
        {
            //ClipsEngine oClipsEngine = new ClipsEngine();
            oClipsEngine.Clear();
            List<vMRClsDef.DataModel> lstNewFact = new List<vMRClsDef.DataModel>();
            FactObtain.ObtainConcludeWithEvent(oIEOutputInfo.oTriggeringEvent.oEvent.strEventName, ref lstNewFact);
            if (oIEOutputInfo.oTriggeringEvent.m_emInferenceType 
                == vMRClsDef.EnumInferenceType.PRIMARY)
            {
                oClipsEngine.DoInference(strRuleLevel, lstDataModelForIE, ref lstNewFact, oIEOutputInfo.oTriggeringEvent);
                InferenceResultConstruct.ConstructInferResult(oClipsEngine.InferResult, lstNewFact, ref oIEOutputInfo);
                return true;
            }
            else if (oIEOutputInfo.oTriggeringEvent.m_emInferenceType 
                == vMRClsDef.EnumInferenceType.SECONDTIME)
            {
                //GoOnInference();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
