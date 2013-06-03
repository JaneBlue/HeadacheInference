using System;
using System.Collections.Generic;
using System.Text;
using CDSSvMRDataDef;

namespace CDSSEngine
{
    class FactConstruct
    {
        public static void FormFactInDataModel(vMRClsDef.InputDataModel oInputDataModel, ref List<vMRClsDef.DataModel> lstDataModelForIE)
        {
            //Add Diesease into DataModels 
            vMRClsDef.DataModel oDataModel = new vMRClsDef.DataModel();
            oDataModel.strDataName = oInputDataModel.oTriggeringEvent.oEvent.strEventName ;
            oDataModel.m_emDataType = vMRClsDef.EnumDataType.STRING;
            oDataModel.strDataValue = "on";
            lstDataModelForIE.Add(oDataModel);
            
            //Add Symptoms into DataModels
            lstDataModelForIE.AddRange(oInputDataModel.oTriggeringEvent.oSymptoms.lstSymptoms);
            
            //Add DataModels into DataModels
            lstDataModelForIE.AddRange(oInputDataModel.lstDataModel);
        }
    }
}
