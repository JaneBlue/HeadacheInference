using System;
using System.Collections.Generic;
using System.Text;
using CDSSvMRDataDef;
using CDSSEngine;
using CDSSSystemData;

namespace CDSSFunction
{
    public class Interface
    {
        public static vMRClsDef.IEvMRInput oDiagnoseIEvMRInput = new vMRClsDef.IEvMRInput();
        public static vMRClsDef.IEvMROutput oDiagnoseIEvMROutput = new vMRClsDef.IEvMROutput();

        public static vMRClsDef.IEvMRInput oTherpayIEvMRInput = new vMRClsDef.IEvMRInput();
        public static vMRClsDef.IEvMROutput oTherpayIEvMROutput = new vMRClsDef.IEvMROutput();

        public static vMRClsDef.IEvMRInput oSelfMonitorIEvMRInput = new vMRClsDef.IEvMRInput();
        public static vMRClsDef.IEvMROutput oSelfMonitorIEvMROutput = new vMRClsDef.IEvMROutput();

        public static vMRClsDef.IEvMRInput oMSEvaluationIEvMRInput = new vMRClsDef.IEvMRInput();
        public static vMRClsDef.IEvMROutput oMSEvaluationIEvMROutput = new vMRClsDef.IEvMROutput();

        public static vMRClsDef.IEvMRInput oRiskEvaluationIEvMRInput = new vMRClsDef.IEvMRInput();
        public static vMRClsDef.IEvMROutput oRiskEvaluationIEvMROutput = new vMRClsDef.IEvMROutput();

        public static vMRClsDef.IEvMRInput oDietaryIEvMRInput = new vMRClsDef.IEvMRInput();
        public static vMRClsDef.IEvMROutput oDietaryIEvMROutput = new vMRClsDef.IEvMROutput();

        public static vMRClsDef.IEvMRInput oPhysicalActivityIEvMRInput = new vMRClsDef.IEvMRInput();
        public static vMRClsDef.IEvMROutput oPhysicalActivityIEvMROutput = new vMRClsDef.IEvMROutput();

        public static void ClearIEInAndOut()
        {
            oDiagnoseIEvMRInput = new vMRClsDef.IEvMRInput();
            oDiagnoseIEvMROutput = new vMRClsDef.IEvMROutput();

            oTherpayIEvMRInput = new vMRClsDef.IEvMRInput();
            oTherpayIEvMROutput = new vMRClsDef.IEvMROutput();

            oSelfMonitorIEvMRInput = new vMRClsDef.IEvMRInput();
            oSelfMonitorIEvMROutput = new vMRClsDef.IEvMROutput();

            oMSEvaluationIEvMRInput = new vMRClsDef.IEvMRInput();
            oMSEvaluationIEvMROutput = new vMRClsDef.IEvMROutput();

            oRiskEvaluationIEvMRInput = new vMRClsDef.IEvMRInput();
            oRiskEvaluationIEvMROutput = new vMRClsDef.IEvMROutput();

            oDietaryIEvMRInput = new vMRClsDef.IEvMRInput();
            oDietaryIEvMROutput = new vMRClsDef.IEvMROutput();

            oPhysicalActivityIEvMRInput = new vMRClsDef.IEvMRInput();
            oPhysicalActivityIEvMROutput = new vMRClsDef.IEvMROutput();
        }
        /// <summary>
        /// 规则更新接口
        /// </summary>
        /// <returns></returns>
        public static bool RuleUpdate()
        {
            return vMRFunDef.KnowledgeUpdate();
        }

        /// <summary>
        /// 从推理引擎模块获取CDSS支持的触发事件
        /// </summary>
        /// <param name="lstEventModels"></param>
        /// <returns></returns>
        public static bool ObtainInfernceEvents(ref List<FunctionTypeDef.EventModels> lstEventModels)
        {
            //TODO:获取CDSS支持的触发事件
            List<vMRClsDef.TriggeringEvent> lstInferenceEvents = new List<vMRClsDef.TriggeringEvent>();
            vMRFunDef.ObtainInferEvents(ref lstInferenceEvents);

            for (int i = 0; i < lstInferenceEvents.Count; i++ )
            {
                FunctionTypeDef.EventModels oEventModel = new FunctionTypeDef.EventModels();
                oEventModel.strEventENName = lstInferenceEvents[i].oEvent.strEventName;
                oEventModel.oDisease.strDiseaseCNName = lstInferenceEvents[i].oDisease.strDiseaseCNName;
                oEventModel.em_InferenceResultType 
                    = DataMapper.MapInferResultTypevMRtoFunction(lstInferenceEvents[i].m_emInferenceResultType);
                lstEventModels.Add(oEventModel);
            }
            return true;
        }

        /// <summary>
        /// 设置需要推理的事件
        /// </summary>
        /// <param name="lstCDSSEvent"></param>
        /// <returns></returns>
        public static bool SetInferenceNeededEvents(List<FunctionTypeDef.EventModels> lstCDSSEvents)
        {
            ClearIEInAndOut();

            vMRClsDef.Role oRole = new vMRClsDef.Role();
            oRole.oClinician.strClinicianLevel = GlobalData.UserInfo.UserID;
            oRole.oPatient.strPatName = GlobalData.PatBasicInfo.Name;
            oRole.oPatient.strPatID = GlobalData.PatBasicInfo.Identity;
            oRole.oPatient.dtPatBirthday = GlobalData.PatBasicInfo.Birthday;
            oRole.oPatient.strPatSex =  GlobalData.PatBasicInfo.Sex;

            for(int i = 0; i < lstCDSSEvents.Count; i++)
            {
                vMRClsDef.InputDataModel oInputDataModel = new vMRClsDef.InputDataModel();
                oInputDataModel.oTriggeringEvent.oEvent.strEventName
                    = lstCDSSEvents[i].strEventENName;
                oInputDataModel.oTriggeringEvent.oDisease.strDiseaseCNName = lstCDSSEvents[i].oDisease.strDiseaseCNName;
                oInputDataModel.oTriggeringEvent.m_emInferenceType
                    = DataMapper.MapInferTypeFuntionDeftovMR(lstCDSSEvents[i].em_InferneceType);
                oInputDataModel.oTriggeringEvent.m_emInferenceResultType
                    = DataMapper.MapInferResultTypeFuntiontovMR(lstCDSSEvents[i].em_InferenceResultType);
                if(lstCDSSEvents[i].em_InferenceResultType == FunctionTypeDef.EnumInferenceResultType.DIAGNOSIS)
                {
                    oDiagnoseIEvMRInput.oRoles = oRole;
                    oDiagnoseIEvMRInput.lstInputDataModel.Add(oInputDataModel);
                }
                else if(lstCDSSEvents[i].em_InferenceResultType == FunctionTypeDef.EnumInferenceResultType.THERAPY)
                {
                    oTherpayIEvMRInput.oRoles = oRole;
                    oTherpayIEvMRInput.lstInputDataModel.Add(oInputDataModel);
                }

                else if (lstCDSSEvents[i].em_InferenceResultType == FunctionTypeDef.EnumInferenceResultType.SELFMONITOR)
                {
                    oSelfMonitorIEvMRInput.oRoles = oRole;
                    oSelfMonitorIEvMRInput.lstInputDataModel.Add(oInputDataModel);
                }

                else if(lstCDSSEvents[i].em_InferenceResultType == FunctionTypeDef.EnumInferenceResultType.MSEVALUATION)
                {
                    oMSEvaluationIEvMRInput.oRoles = oRole;
                    oMSEvaluationIEvMRInput.lstInputDataModel.Add(oInputDataModel);

                }

                else if(lstCDSSEvents[i].em_InferenceResultType == FunctionTypeDef.EnumInferenceResultType.RISKEVALUATION)
                {
                    oRiskEvaluationIEvMRInput.oRoles = oRole;
                    oRiskEvaluationIEvMRInput.lstInputDataModel.Add(oInputDataModel);
                }

                else if(lstCDSSEvents[i].em_InferenceResultType == FunctionTypeDef.EnumInferenceResultType.DIETARY)
                {
                    oDietaryIEvMRInput.oRoles = oRole;
                    oDietaryIEvMRInput.lstInputDataModel.Add(oInputDataModel);
                }

                else if(lstCDSSEvents[i].em_InferenceResultType == FunctionTypeDef.EnumInferenceResultType.PHYSICALACTIVITY)
                {
                    oPhysicalActivityIEvMRInput.oRoles = oRole;
                    oPhysicalActivityIEvMRInput.lstInputDataModel.Add(oInputDataModel);
                }
            }
            return true;
        }

        /// <summary> 
        /// 推理接口调用
        /// </summary>
        /// <returns></returns>
        public static bool InfernceExplanationExecute()
        {
            StructedIEResult.ClearIEStructedInfo();
            GlobalData.DiagnosedResult.Clear();

            IEExecute(ref oDiagnoseIEvMRInput, ref oDiagnoseIEvMROutput);

            IEExecute(ref oMSEvaluationIEvMRInput, ref oMSEvaluationIEvMROutput);

            IEExecute(ref oRiskEvaluationIEvMRInput, ref oRiskEvaluationIEvMROutput);

            IEExecute(ref oTherpayIEvMRInput, ref oTherpayIEvMROutput);

            IEExecute(ref oSelfMonitorIEvMRInput, ref oSelfMonitorIEvMROutput);

            IEExecute(ref oDietaryIEvMRInput, ref oDietaryIEvMROutput);

            IEExecute(ref oPhysicalActivityIEvMRInput, ref oPhysicalActivityIEvMROutput);

            return true;
        }

        public static bool IEExecute(ref vMRClsDef.IEvMRInput oIEvMRInput, ref vMRClsDef.IEvMROutput oIEvMROutput)
        {
            if (ObtainDataModel(ref oIEvMRInput))
            {

                if (DataMapper.MapDataToFact(ref oIEvMRInput))
                {
                    if (vMRFunDef.vMRDataValueFromUItoIE(oIEvMRInput, ref oIEvMROutput))
                    {
                        //获取推理解释结果成功
                        //结果转换为UI可用形式
                        StructedIEResult.AddIEStructedInfo(oIEvMROutput);
                        DataMapper.MapIEOutputToUI(oIEvMRInput, oIEvMROutput);
                        return true;
                    }
                    else
                    {
                        //获取推理解释结果失败
                        return false;
                    }
                }
                else
                {
                    //获取Fact失败
                    return false;
                }
            }
            else
            {
                //获取DataModel失败
                return false;
            }
        }

        /// <summary>
        /// 获取推理所需的DataModels
        /// </summary>
        /// <returns></returns>
        private static bool ObtainDataModel(ref vMRClsDef.IEvMRInput oIEvMRInput)
        {
            if (!ObtainDataModelFromBuffer(ref oIEvMRInput))
            {
                return vMRFunDef.vMRDataModelFromIEtoUI(ref oIEvMRInput);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 从缓冲区获取DataModels
        /// </summary>
        /// <returns></returns>
        private static bool ObtainDataModelFromBuffer(ref vMRClsDef.IEvMRInput oIEvMRInput)
        {
            //TODO:从缓冲区获取datamodel
            return false;
        }
    }
}
