using System;
using System.Collections.Generic;
using System.Text;
using CDSSCLIPSEngine;
using CDSSvMRDataDef;

namespace CDSSEngine
{
    class ExplanationService
    {

        public static bool BeginExplanation()
        {
            //¿Õ´úÂë£¬¿ÉÀ©Õ¹
            return true;
        }

        public static void ConstructExplanation(ClipsEngine.Interpretation oClipsInterpration,ref vMRClsDef.OutputInfo oOutputInfo)
        {
            vMRClsDef.CLIPSInterpretation oIEInterpration = new vMRClsDef.CLIPSInterpretation();
            oIEInterpration.lstFactUsed.AddRange(oClipsInterpration.lstFactUsed);
            oIEInterpration.lstRecomm.AddRange(oClipsInterpration.lstRecomm);
            oIEInterpration.strInterpretationIndex = oClipsInterpration.strInterpretationIndex;
            oOutputInfo.oExplanation.lstClipsInterpretation.Add(oIEInterpration);
        }
    }
}
