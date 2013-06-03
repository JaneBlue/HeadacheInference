using System;
using System.Collections.Generic;
using System.Text;
using CDSSvMRDataDef;

namespace CDSSEngine
{
    public class vMRFunDef
    {
        /// <summary>
        /// ��֪ʶ���ȡ����ģ��
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
                //���ȸ����¼���ȡDataModel
                FactObtain.ObtainFactWithDisease(ref oInputDataModel);
                oIEvMRInputDataModel.lstInputDataModel[i].lstDataModel.AddRange(oInputDataModel.lstDataModel);
                //�������󣬸���Symptom��ȡDataModel;
                oInputDataModel.lstDataModel.Clear();
                FactObtain.ObtainFactWithSymptoms(ref oInputDataModel);
                oIEvMRInputDataModel.lstInputDataModel[i].lstDataModel.AddRange(oInputDataModel.lstDataModel);
            }
            return true;
        }

        /// <summary>
        /// ��������˾��ߴ���������ʵ�֣�UI�˵���
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
        /// UI�˾��ߴ�������������ʵ�֣���������˵���
        /// </summary>
        /// <param name="oIEvMROutput"></param>
        /// <returns></returns>
        public static bool OutputFromIEtoUI(ref vMRClsDef.IEvMROutput oIEvMROutput)
        {
            return true;
        }

        /// <summary>
        /// ��������˾��ߴ���������ʵ�֣�UI�˵���
        /// </summary>
        /// <returns></returns>
        public static bool KnowledgeUpdate()
        {
            return false;
            //֪ʶ���½ӿڣ������в���ȷ����
        }

        /// <summary>
        /// ��ȡ���Խ���������¼�
        /// </summary>
        /// <param name="oInferEvents"></param>
        /// <returns></returns>
        public static bool ObtainInferEvents(ref List<vMRClsDef.TriggeringEvent> oInferEvents)
        {
            return FactObtain.ObtainEventList(ref oInferEvents);
        }
    }
}
