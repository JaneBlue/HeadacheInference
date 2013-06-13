using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using CDSSFunction;
using CDSSSystemData;

namespace HeadacheInferenceWebservice
{
   
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

   
    public class InferenceService : System.Web.Services.WebService
    {

        [WebMethod]
        public bool DoInference(InputData InputDataValue, ref string strResult)
        {
            
            //把传入的数据放入全局变量
            PutdataintoGlobalData(InputDataValue);

            //推理
            RuleBase.Diagnosis();

            strResult = GlobalData.DiagnosedResult.DiseaseDiagnosedResultList[0].Result;

            return true;
        }

        public bool PutdataintoGlobalData(InputData InputDataValue)
        {
            //把InputDataValue的值放进Globaldata里面
            //先兆
            GlobalData.HeadacheAnnotation.Clear();
            foreach (HeadacheAura aura in InputDataValue.m_HeadacheAuraList)
            {
                HeadachePlus2 headacheaura = new HeadachePlus2();
                headacheaura.Aspect = "HeadacheAura";
                if (aura == HeadacheAura.Hemi_Visual_Aura)
                {
                    headacheaura.AspectName = "单侧视觉";
                    headacheaura.Note = "单侧视觉先兆";

                }
                else if (aura == HeadacheAura.Bilateral_Visual_Aura)
                {
                    headacheaura.AspectName = "双侧视觉";
                    headacheaura.Note = "双侧视觉先兆";

                }
                else if (aura == HeadacheAura.Feeling_Aura)
                {
                    headacheaura.AspectName = "感觉";
                    headacheaura.Note = "感觉先兆";

                }
                else if (aura == HeadacheAura.Allolalia)
                {
                    headacheaura.AspectName = "语言障碍";
                    headacheaura.Note = "言语障碍";

                }
                else if (aura == HeadacheAura.Dyscinesia)
                {
                    headacheaura.AspectName = "运动障碍";
                    headacheaura.Note = "运动障碍";

                }
                GlobalData.HeadacheAnnotation.HeadacheAura.Add(headacheaura);

            }           
            //头痛每次持续时间
            GlobalData.HeadacheAnnotation.LastTimeBefore = InputDataValue.m_nHeadache_Duration_PerTime;
            //头痛每次持续时间的单位
            GlobalData.HeadacheAnnotation.LastTimeBeforeUnit = InputDataValue.m_nHeadache_Duration_PerTime_Unit;

            //头痛类型
            GlobalData.HeadacheAnnotation.HeadacheType = InputDataValue.m_nHeadahceProperty.ToString();
            //头痛总次数
            GlobalData.HeadacheAnnotation.HeadacheTrait = InputDataValue.m_nHeadache_TotalNumber.ToString();


            //头痛总持续时间
            GlobalData.HeadacheAnnotation.nHeadahce_Duration = InputDataValue.m_nHeadache_Duration;

            //头痛每月持续时间
            if (InputDataValue.m_nHeadache_Monthly_Duration < 1)
            {
                GlobalData.HeadacheAnnotation.MHeadacheday = "0";
            }
            else if (InputDataValue.m_nHeadache_Monthly_Duration >= 1 && InputDataValue.m_nHeadache_Monthly_Duration <= 15)
            {
                GlobalData.HeadacheAnnotation.MHeadacheday = "9";
            }
            else if(InputDataValue.m_nHeadache_Monthly_Duration > 15)
            {
                GlobalData.HeadacheAnnotation.MHeadacheday = "20";
            }

            GlobalData.PreviousTreatment.PreviousAcesodyneDrug.Clear();

            if (InputDataValue.m_nTriptan_Drugin_Monthly !=0 && InputDataValue.m_nTriptan_Total_Drugin_Duration != 0)
            {
                 Drug drug = new Drug();
                 drug.DrugEffect = InputDataValue.m_nTriptan_Drugin_Monthly.ToString();        //曲普坦类每月服药时长;
                 drug.DSideEffect = InputDataValue.m_nTriptan_Total_Drugin_Duration.ToString();//曲普坦类总服药时长;
                 GlobalData.PreviousTreatment.PreviousAcesodyneDrug.Add(drug);
            }
           
            if (InputDataValue.m_nNon_Triptan_Total_Drugin_Duration != 0 && InputDataValue.m_nNon_Triptan_Drugin_Monthly != 0 )
            {
                Drug drug = new Drug();
                drug.DSideEffect = InputDataValue.m_nNon_Triptan_Total_Drugin_Duration.ToString();          //非曲普坦类药物总服药时长
                drug.DrugEffect = InputDataValue.m_nNon_Triptan_Drugin_Monthly.ToString();                  //非曲普坦类药物每月服药时长
                GlobalData.PreviousTreatment.PreviousAcesodyneDrug.Add(drug);
            }

            if (InputDataValue.m_HeadacheLocation == HeadacheLocation.Uni_Pain)
            {
                GlobalData.HeadacheAnnotation.Unilateral = "Yes";
            }

            if (InputDataValue.m_HeadacheLocation == HeadacheLocation.Bi_Pain)
            {
                GlobalData.HeadacheAnnotation.Bilateral = "Yes";
            }

            if (InputDataValue.m_bPeriodism == true)
            {
                GlobalData.HeadacheAnnotation.TimeFixed = "Yes";
            }
            else
            {
                GlobalData.HeadacheAnnotation.TimeFixed = "No";
            }

            if (InputDataValue.m_bWorsen_By_Physicial_Activity == false)
            {
                GlobalData.HeadacheAnnotation.WorsenDegree = "从无";
            }
            else
            {
                GlobalData.HeadacheAnnotation.WorsenDegree = "else";
            }

            if (InputDataValue.m_bDaily_Headache == true)
            {
                GlobalData.HeadacheAnnotation.HeadacheEveryDay = "是";
            }

            if (InputDataValue.m_bDaily_Headache == false)
            {
                GlobalData.HeadacheAnnotation.HeadacheEveryDay = "否";
            }

            if (InputDataValue.m_nHeadacheDegree == HeadacheDegree.Mild)
            {
                GlobalData.HeadacheAnnotation.Markqualitative = "轻";
            }
            else if(InputDataValue.m_nHeadacheDegree == HeadacheDegree.Middle)
            {
                GlobalData.HeadacheAnnotation.Markqualitative = "中";
            }
            else if (InputDataValue.m_nHeadacheDegree == HeadacheDegree.Heavy)
            {
                GlobalData.HeadacheAnnotation.Markqualitative = "重";
            }

            if(InputDataValue.m_nHeadahceProperty == HeadacheProperty.Pulse_Pain)
            {
                GlobalData.HeadacheAnnotation.HeadacheType = "搏动";
            }
            else if(InputDataValue.m_nHeadahceProperty == HeadacheProperty.Pressure_Pain)
            {
                GlobalData.HeadacheAnnotation.HeadacheType = "压迫";
            }
            else if(InputDataValue.m_nHeadahceProperty == HeadacheProperty.Electric_Shock_Like_Pain)
            {
                GlobalData.HeadacheAnnotation.HeadacheType = "过电";
            }

            foreach (HeadacheAssociatedSymptoms AssociatedSymptoms in InputDataValue.m_HeadacheAssociatedSymptonList)
            {
                if (AssociatedSymptoms == HeadacheAssociatedSymptoms.Nausea)
                {
                    GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Add("恶心");
                }
                if (AssociatedSymptoms == HeadacheAssociatedSymptoms.Vomit)
                {
                    GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Add("呕吐");
                }
                if (AssociatedSymptoms == HeadacheAssociatedSymptoms.Fair_Of_Sound)
                {
                    GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Add("畏声");
                }
                if (AssociatedSymptoms == HeadacheAssociatedSymptoms.Fire_Of_Light)
                {
                    GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Add("畏光");
                }
                if (AssociatedSymptoms == HeadacheAssociatedSymptoms.Blocked_or_Watery_Nose)
                {
                    GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Add("同侧鼻塞/流涕");
                }
                if(AssociatedSymptoms == HeadacheAssociatedSymptoms.Conjunctival_congestion_or_Tears)
                {
                    GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Add("同侧结膜充血/流泪");
                }
                if (AssociatedSymptoms == HeadacheAssociatedSymptoms.Dysphoria)
                {
                    GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Add("感觉不安或躁动");
                }
                if (AssociatedSymptoms == HeadacheAssociatedSymptoms.Frontal_facial_Sweating)
                {
                    GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Add("同侧前额/面部出汗");
                }
                if (AssociatedSymptoms == HeadacheAssociatedSymptoms.Ipsilateral_Heyelids_Swelling)
                {
                    GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Add("同侧眼睑水肿");
                }
                if (AssociatedSymptoms == HeadacheAssociatedSymptoms.Miosis_or_Blepharoptosis)
                {
                    GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Add("同侧眼睑下垂");
                }
                
            }

           

//             foreach (HeadacheAura aura in InputDataValue.m_HeadacheAuraList)
//             {
//                 if(aura == HeadacheAura.Allolalia)
//                 {
//                     HeadachePlus2 auravision = new HeadachePlus2();
//                     auravision.AspectName = "语言障碍";
//                     GlobalData.HeadacheAnnotation.HeadacheAura.Add(auravision); 
//                 }
//                 if(aura == HeadacheAura.Bilateral_Visual_Aura)
//                 {
//                     HeadachePlus2 auravision = new HeadachePlus2();
//                     auravision.AspectName = "双侧视觉";
//                     GlobalData.HeadacheAnnotation.HeadacheAura.Add(auravision);
//                 }
//                 if(aura == HeadacheAura.Dyscinesia)
//                 {
//                     HeadachePlus2 auravision = new HeadachePlus2();
//                     auravision.AspectName = "运动障碍";
//                     GlobalData.HeadacheAnnotation.HeadacheAura.Add(auravision);
//                 }
//                 if(aura == HeadacheAura.Feeling_Aura)
//                 {
//                     HeadachePlus2 auravision = new HeadachePlus2();
//                     auravision.AspectName = "感觉";
//                     GlobalData.HeadacheAnnotation.HeadacheAura.Add(auravision);
//                 }
//                 if(aura == HeadacheAura.Hemi_Visual_Aura)
//                 {
//                     HeadachePlus2 auravision = new HeadachePlus2();
//                     auravision.AspectName = "单侧视觉";
//                     GlobalData.HeadacheAnnotation.HeadacheAura.Add(auravision);
//                 }
//             }

            return true;
        }

       
    }

    public enum HeadacheAssociatedSymptoms
    {
        Nausea,                           //恶心
        Vomit,                            //呕吐
        Fair_Of_Sound,                    //畏声
        Fire_Of_Light,                    //畏光
        Ipsilateral_Heyelids_Swelling,    //同侧眼睑浮肿
        Miosis_or_Blepharoptosis,         //同侧瞳孔缩小或睑下垂
        Conjunctival_congestion_or_Tears, //同侧结膜充血或流泪
        Frontal_facial_Sweating,          //同侧额、面部出汗
        Blocked_or_Watery_Nose,           //同侧鼻塞或流涕
        Dysphoria                         //烦躁不安

    }

    public enum HeadacheAura
    {
        Hemi_Visual_Aura,                 //单侧视觉先兆
        Bilateral_Visual_Aura,            //双侧视觉先兆(点状、色斑、线形闪光幻觉、视野缺损)
        Feeling_Aura,                     //感觉先兆(针刺感、麻木)
        Allolalia,                        //言语障碍
        Dyscinesia                        //运动障碍
    }

    public enum HeadacheLocation
    {
        Uni_Pain = 0,                    //单侧痛
        Bi_Pain                          //双侧痛
    }

    public enum HeadacheDegree
    {
        Mild,                            //轻
        Middle,                          //中
        Heavy                            //重
    }

    public enum HeadacheProperty
    {
        Pulse_Pain,                      //搏动痛
        Pressure_Pain,                   //压迫痛
        Electric_Shock_Like_Pain         //过电样痛
    }


    public static class RuleBase
    {
        public static bool Diagnosis()
        {
            GlobalData.DiagnosedResult.Clear();

            List<FunctionTypeDef.EventModels> lstEventModels = new List<FunctionTypeDef.EventModels>();
            CDSSFunction.Interface.ObtainInfernceEvents(ref lstEventModels);
            CDSSFunction.Interface.SetInferenceNeededEvents(lstEventModels);
            CDSSFunction.Interface.InfernceExplanationExecute();

            return true;
        }
    }

   

    public class InputData
    {
        public float m_nHeadache_Duration_PerTime;                               //头痛每次持续时间
        public string m_nHeadache_Duration_PerTime_Unit;                       //头痛每次持续时间的单位
        public string m_strHeadacheType;                                       //头痛类型
        public int m_nHeadache_TotalNumber;                                    //头痛总次数
        public int m_nHeadache_Duration;                                       //头痛总持续时间，比如多少年，多少个月
        public int m_nHeadache_Monthly_Duration;                               //头痛每月持续时长
        public int m_nTriptan_Total_Drugin_Duration;                           //曲普坦类药物总服药时长
        public int m_nTriptan_Drugin_Monthly;                                  //曲普坦类药物每月服药时长
        public int m_nNon_Triptan_Total_Drugin_Duration;                       //非曲普坦类药物总服药时长
        public int m_nNon_Triptan_Drugin_Monthly;                              //非曲普坦类药物每月服药时长

        public List<HeadacheAssociatedSymptoms> m_HeadacheAssociatedSymptonList = new List<HeadacheAssociatedSymptoms>();                 //头痛伴随症状
        public List<HeadacheAura> m_HeadacheAuraList = new List<HeadacheAura>();                                           //头痛先兆
        public HeadacheLocation m_HeadacheLocation;                                             //头痛部位
        
        public bool m_bPeriodism;                                                                  //头痛是否周期性
        public bool m_bWorsen_By_Physicial_Activity;                                                //头痛是否因体力活动加剧
        public HeadacheDegree m_nHeadacheDegree;                                                    //头痛程度
        public HeadacheProperty m_nHeadahceProperty;                                                //头痛性质
        public bool m_bDaily_Headache;                                                              //首日发作即每日头痛

        public InputData()
        {
            m_nHeadache_Duration_PerTime = 0;                               //头痛每次持续时间
            m_nHeadache_Duration_PerTime_Unit = "";
            m_strHeadacheType = "";                                       //头痛类型
            m_nHeadache_TotalNumber = 0;                                    //头痛总次数
            m_nHeadache_Duration = 0;                                       //头痛总持续时间，比如多少年，多少个月
            m_nHeadache_Monthly_Duration = 0;                               //头痛每月持续时长
            m_nTriptan_Total_Drugin_Duration = 0;                           //曲普坦类药物总服药时长
            m_nTriptan_Drugin_Monthly = 0;                                  //曲普坦类药物每月服药时长
            m_nNon_Triptan_Total_Drugin_Duration = 0;                       //非曲普坦类药物总服药时长
            m_nNon_Triptan_Drugin_Monthly = 0;                              //非曲普坦类药物每月服药时长

                
            m_bPeriodism = false;                                                                  //头痛是否周期性
            m_bWorsen_By_Physicial_Activity = false;                                                //头痛是否因体力活动加剧
            m_bDaily_Headache = false;                                                              //首日发作即每日头痛
        }
    

    }


}
