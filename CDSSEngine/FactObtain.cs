using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using CDSSvMRDataDef;
using System.Configuration;
using CDSSCLIPSEngine;

namespace CDSSEngine
{
    class FactObtain
    {
        /// <summary>
        /// 根据疾病获取数据模型
        /// </summary>
        /// <param name="oInputDataModel"></param>
        /// <returns></returns>
        public static bool ObtainFactWithDisease(ref vMRClsDef.InputDataModel oInputDataModel)
        {
            return ClipsFactObtain.ObtainDataModelWithEventFromCLIPSDataModel(ref oInputDataModel);
        }

        /// <summary>
        /// 根据Symptoms获取数据模型
        /// </summary>
        /// <param name="oInputDataModel"></param>
        /// <returns></returns>
        public static bool ObtainFactWithSymptoms(ref vMRClsDef.InputDataModel oInputDataModel)
        {
            return ClipsFactObtain.ObtainDataModelWithSymptomsFromCLIPSDataModel(ref oInputDataModel);
        }

        public static bool ObtainEventList(ref List<vMRClsDef.TriggeringEvent> lstTriggeringEvent)
        {
            if (ClipsFactObtain.lstTriggeringEvents.Count == 0)
            {
                ClipsFactObtain.ObtainTriggeringEventListFromCLIPSDataModel();
            }

            lstTriggeringEvent.AddRange(ClipsFactObtain.lstTriggeringEvents);
            return true;
        }

        public static bool ObtainConcludeWithEvent(string strEvent, ref List<vMRClsDef.DataModel> lstNewFact)
        {
            return ClipsFactObtain.ObtainConcludeWithEventFromCLIPSDataModel(strEvent, ref lstNewFact);
        }
    }
}
