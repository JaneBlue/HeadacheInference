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
        /// 调用推理引擎进行推理
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
        /// 正向推理
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
        /// 反向推理
        /// </summary>
        /// <returns></returns>
        public static bool BackwardsInference()
        {
            //反向推理实现
            //空代码，可扩展
            return true;
        }

        /// <summary>
        /// 根据User角色选择Rule Level
        /// </summary>
        /// <param name="oRoles"></param>
        /// <returns></returns>
        public static string ChooseRuleLevelWithRole(vMRClsDef.Role oRoles)
        {
            string strRoleLevel = oRoles.oClinician.strClinicianLevel;
            switch (strRoleLevel)
            {
                default:
                    //根据角色选择规则
                    return "LEVEL_CLINICIANS";
            }
        }

        private static ClipsEngine oClipsEngine = new ClipsEngine();

        /// <summary>
        /// 使用CLIPS推理引擎进行推理
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
