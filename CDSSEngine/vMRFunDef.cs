using System;
using System.Collections.Generic;
using System.Text;
using CDSSvMRDataDef;

namespace CDSSEngine
{
    public class vMRFunDef
    {
        /// <summary>
        /// 从知识库获取数据模型
        /// </summary>
        /// <param name="oIEvMRInputDataModel"></param>
        /// <returns></returns>
        public static bool vMRDataModelFromIEtoUI(ref vMRClsDef.IEvMRInput oIEvMRInputDataModel)
        {
            for (int i = 0; i < oIEvMRInputDataModel.lstInputDataModel.Count; i++)
            {
                vMRClsDef.InputDataModel oInputDataModel = new vMRClsDef.InputDataModel();
                oInputDataModel.oTriggeringEvent 
                    = oIEvMRInputDataModel.lstInputDataModel[i].oTriggeringEvent;
                //首先根据事件获取DataModel
                FactObtain.ObtainFactWithDisease(ref oInputDataModel);
                oIEvMRInputDataModel.lstInputDataModel[i].lstDataModel.AddRange(oInputDataModel.lstDataModel);
                //将来需求，根据Symptom获取DataModel;
                oInputDataModel.lstDataModel.Clear();
                FactObtain.ObtainFactWithSymptoms(ref oInputDataModel);
                oIEvMRInputDataModel.lstInputDataModel[i].lstDataModel.AddRange(oInputDataModel.lstDataModel);
            }
            return true;
        }

        /// <summary>
        /// 推理引擎端决策代理服务具体实现，UI端调用
        /// </summary>
        /// <param name="oIEvMRInputDataValue"></param>
        /// <param name="oIEvMROutput"></param>
        /// <returns></returns>
        public static bool vMRDataValueFromUItoIE(vMRClsDef.IEvMRInput oIEvMRInputDataValue, ref vMRClsDef.IEvMROutput oIEvMROutput)
        {
            oIEvMROutput.oRoles = oIEvMRInputDataValue.oRoles;
            foreach(vMRClsDef.InputDataModel oInputDataModel in oIEvMRInputDataValue.lstInputDataModel)
            {
                List<vMRClsDef.DataModel> lstDataModelForIE = new List<vMRClsDef.DataModel>();
                vMRClsDef.OutputInfo oIEOutputInfo = new vMRClsDef.OutputInfo();
                FactConstruct.FormFactInDataModel(oInputDataModel, ref lstDataModelForIE);
                oIEOutputInfo.oTriggeringEvent = oInputDataModel.oTriggeringEvent;
                InferenceService.BeginInference(oIEvMROutput.oRoles, lstDataModelForIE, ref oIEOutputInfo);
                ExplanationService.BeginExplanation();
                oIEvMROutput.lstOutputInfo.Add(oIEOutputInfo);
            }
            return true;
        }

        /// <summary>
        /// UI端决策代理引擎服务具体实现，推理引擎端调用
        /// </summary>
        /// <param name="oIEvMROutput"></param>
        /// <returns></returns>
        public static bool OutputFromIEtoUI(ref vMRClsDef.IEvMROutput oIEvMROutput)
        {
            return true;
        }

        /// <summary>
        /// 推理引擎端决策代理服务具体实现，UI端调用
        /// </summary>
        /// <returns></returns>
        public static bool KnowledgeUpdate()
        {
            return false;
            //知识更新接口，参数尚不能确定。
        }

        /// <summary>
        /// 获取可以进行推理的事件
        /// </summary>
        /// <param name="oInferEvents"></param>
        /// <returns></returns>
        public static bool ObtainInferEvents(ref List<vMRClsDef.TriggeringEvent> oInferEvents)
        {
            return FactObtain.ObtainEventList(ref oInferEvents);
        }
    }
}
