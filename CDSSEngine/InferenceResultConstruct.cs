using System;
using System.Collections.Generic;
using System.Text;
using CDSSCLIPSEngine;
using CDSSvMRDataDef;

namespace CDSSEngine
{
    public class InferenceResultConstruct
    {
        public static void ConstructInferResult(ClipsEngine.Result oClipsInferResult, 
            List<vMRClsDef.DataModel> lstNewFact,ref vMRClsDef.OutputInfo oOutputInfo)
        {
            //�����¼�����������Ϣ��ȡ
            oOutputInfo.oTriggeringEvent.oEvent.strEventCNName = ClipsFactObtain.ObtainEventCNNamewithEventName(oOutputInfo);
            //��ϻ����ƽṹ���������
            oOutputInfo.oInference.lstStructedInferMessage.AddRange(lstNewFact);

            //��ϡ����ƺ����Ҽ��ǽṹ���������
            for(int i = 0; i < oClipsInferResult.Recommendations.Count; i++)
            {
                vMRClsDef.UnStructMessage oRecommendation = new vMRClsDef.UnStructMessage();
                oRecommendation.strUnStructMessage = oClipsInferResult.Recommendations[i];
                oOutputInfo.oInference.lstUnstructedInferenceMessage.Add(oRecommendation);                   
            }

            //������ȱ����
            for(int j = 0; j < oClipsInferResult.DataNotice.Data.Count; j++)
            {
                vMRClsDef.DataModel oShortDataModel = new vMRClsDef.DataModel();
                oShortDataModel.strDataName = oClipsInferResult.DataNotice.Data[j];
                oShortDataModel.strDataCNName = ClipsFactObtain.ObtainDataCNNamewithDataName(oOutputInfo, oShortDataModel.strDataName);
                oOutputInfo.lstShortDataModel.Add(oShortDataModel);
            }

            //���͹���
            for(int k =0; k < oClipsInferResult.lstInInterpretation.Count; k++)
            {
                ExplanationService.ConstructExplanation(oClipsInferResult.lstInInterpretation[k], ref oOutputInfo);
            }
                      
        }
    }
}
