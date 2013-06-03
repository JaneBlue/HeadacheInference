using System;
using System.Collections.Generic;
using System.Text;
using CDSSvMRDataDef;

namespace CDSSFunction
{
    public class StructedIEResult
    {
        public static List<StructedConclude> lstStructedConclude = new List<StructedConclude>();

        public class StructedConclude
        {
            public FunctionTypeDef.EventModels oEventModel;
            public List<vMRClsDef.DataModel> lstConclude;

            public StructedConclude()
            {
                oEventModel = new FunctionTypeDef.EventModels();
                lstConclude = new List<vMRClsDef.DataModel>();
            }
        }

        public static void ClearIEStructedInfo()
        {
            lstStructedConclude.Clear();
        }

        public static void AddIEStructedInfo(vMRClsDef.IEvMROutput oIEvMROutput)
        {
            foreach(vMRClsDef.OutputInfo oOutputInfo in oIEvMROutput.lstOutputInfo)
            {
                StructedConclude oStructedIEInfo = new StructedConclude();
                oStructedIEInfo.oEventModel.strEventENName = oOutputInfo.oTriggeringEvent.oEvent.strEventName;
                oStructedIEInfo.oEventModel.strEventCNName = oOutputInfo.oTriggeringEvent.oEvent.strEventCNName;
                oStructedIEInfo.lstConclude.AddRange(oOutputInfo.oInference.lstStructedInferMessage);

                lstStructedConclude.Add(oStructedIEInfo);
            }

        }

    }
}
