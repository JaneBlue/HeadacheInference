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
            //触发事件的中文名信息获取
            oOutputInfo.oTriggeringEvent.oEvent.strEventCNName = ClipsFactObtain.ObtainEventCNNamewithEventName(oOutputInfo);
            //诊断或治疗结构化推理结论
            oOutputInfo.oInference.lstStructedInferMessage.AddRange(lstNewFact);

            //诊断、治疗和自我监测非结构化推理结论
            for(int i = 0; i < oClipsInferResult.Recommendations.Count; i++)
            {
                vMRClsDef.UnStructMessage oRecommendation = new vMRClsDef.UnStructMessage();
                oRecommendation.strUnStructMessage = oClipsInferResult.Recommendations[i];
                oOutputInfo.oInference.lstUnstructedInferenceMessage.Add(oRecommendation);                   
            }

            //推理所缺数据
            for(int j = 0; j < oClipsInferResult.DataNotice.Data.Count; j++)
            {
                vMRClsDef.DataModel oShortDataModel = new vMRClsDef.DataModel();
                oShortDataModel.strDataName = oClipsInferResult.DataNotice.Data[j];
                oShortDataModel.strDataCNName = ClipsFactObtain.ObtainDataCNNamewithDataName(oOutputInfo, oShortDataModel.strDataName);
                oOutputInfo.lstShortDataModel.Add(oShortDataModel);
            }

            //解释过程
            for(int k =0; k < oClipsInferResult.lstInInterpretation.Count; k++)
            {
                ExplanationService.ConstructExplanation(oClipsInferResult.lstInInterpretation[k], ref oOutputInfo);
            }
                      
        }
    }
}
