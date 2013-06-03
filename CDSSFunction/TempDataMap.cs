using System;
using System.Collections.Generic;
using System.Text;
using CDSSSystemData;

    /***************************************************
     * 创建人： XY
     * 创建时间：2009.3.16
     * 创建内容：映射模块
     * 创建说明：数据传入推理机
     * *************************************************/

namespace CDSSFunction
{    
    public class TempDataMap
    {
        #region 映射模块
        public static string ObtainDataValueWithDataCode(string strDataCode)
        {
            switch (strDataCode)
            {
                case "B24.01"://AIDS
                    return "No";

                case "G44.0"://丛集性头痛
                    return "No";

                case "G03.952"://假性脑瘤综合征
                    return "No";

                case "G43"://偏头痛
                    return "No";

                case "H000001"://先兆
                    if(GlobalData.HeadacheAnnotation.HeadacheAura.Count > 0)
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }
                        

                case "Q28.001"://动静脉畸形
                    return "No";

                case "H000002"://单侧性痛
//                     foreach(HeadachePlus2 area in GlobalData.HeadacheAnnotation.HeadachePosition)
//                     {
//                         if(area.AspectName.Contains("左") || area.AspectName.Contains("右"))
//                         {
//                             return "Yes";
//                         }
//                     }

                    if (GlobalData.HeadacheAnnotation.Unilateral == "Yes" )
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }
                                   

                case "H000003"://压迫样痛
                    if (GlobalData.HeadacheAnnotation.HeadacheType.Contains("压迫") || GlobalData.HeadacheAnnotation.HeadacheType.Contains("紧箍") || GlobalData.HeadacheAnnotation.HeadacheType.Contains("胀痛"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000004"://双侧性痛
//                     foreach(HeadachePlus2 area in GlobalData.HeadacheAnnotation.HeadachePosition)
//                     {
//                         if (area.AspectName.Contains("双侧") || area.AspectName.Contains("全头痛"))
//                         {
//                             return "Yes";
//                         }
//                     }
                    if (GlobalData.HeadacheAnnotation.Bilateral == "Yes")
                    {
                        return "Yes";
                    } 
                    else
                    {
                        return "No";
                    }

                    // add by fgj
                case"H000107"://同侧眼睑浮肿
                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("同侧眼睑水肿"))
                    {
                        return "Yes";
                    }
                    return "No";
                case"H000109"://同侧瞳孔缩小或眼睑下垂
                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("同侧眼睑下垂") || GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("同侧瞳孔缩小"))
                    {
                        return "Yes";
                    }
                    return "No";
                case"H000115"://同侧结膜充血
                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("同侧结膜充血/流泪"))
                    {
                        return "Yes";
                    }
                    return "No";
                case"H000108"://同侧额、面部出汗
                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("同侧前额/面部出汗"))
                    {
                        return "Yes";
                    }
                    return "No";
                case"H000116" ://同侧鼻塞或流涕
                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("同侧鼻塞/流涕"))
                    {
                        return "Yes";
                    }
                    return "No";

                case"H000117"://周期性
                    if (GlobalData.HeadacheAnnotation.TimeFixed=="Yes")
                    {
                        return "Yes";
                    }
                    return "No";
                case"H000118"://烦躁不安
                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("感觉不安或躁动"))
                    {
                        return "Yes";
                    }
                    return "No";
                case"H000112"://感觉先兆（针刺感、麻木）
                   foreach(  HeadachePlus2 aura in GlobalData.HeadacheAnnotation.HeadacheAura )
                   {
                    if(aura.AspectName == "感觉")
                    {
                        return "Yes";
                    }
                   }
                    return "No";
                case "H000111"://视觉先兆（点状、色斑）
                  foreach(  HeadachePlus2 aura in GlobalData.HeadacheAnnotation.HeadacheAura )
                   {
                    if(aura.AspectName == "视觉")
                    {
                        return "Yes";
                    }
                   }
                    return "No"; 

                    case "H000113"://言语障碍
                   foreach(  HeadachePlus2 aura in GlobalData.HeadacheAnnotation.HeadacheAura )
                   {
                    if(aura.AspectName == "语言障碍")
                    {
                        return "Yes";
                    }
                   }
                    return "No";

                    case "000003"://头痛总次数
//                     if (GlobalData.HeadacheAnnotation.HeadacheTrait == "类似发作<5次")
//                    {
//                        return "3";
//                    }
//                     if (GlobalData.HeadacheAnnotation.HeadacheTrait == "类似发作6-9次")
//                     {
//                         return "7";
//                     }
//                     if (GlobalData.HeadacheAnnotation.HeadacheTrait == "类似发作超过10次")
//                     {
//                         return "12";
//                     }
//                     if (GlobalData.HeadacheAnnotation.HeadacheTrait == "持续头痛")
//                     {
//                         return "15";
//                     }
//                         return "0";
                    return GlobalData.HeadacheAnnotation.HeadacheTrait.ToString();

                    case "000002"://头痛持续时间
//                     if (GlobalData.HeadacheAnnotation.BeginTime != null)
//                     {
//                         TimeSpan ts = DateTime.Now - GlobalData.HeadacheAnnotation.BeginTime;
//                         int month = ts.Days / 30;
//                         return month.ToString();
//                     }
//                     return "0";
                       return GlobalData.HeadacheAnnotation.nHeadahce_Duration.ToString();

                    case "H000123"://头痛是否每天发作
                    if (GlobalData.HeadacheAnnotation.HeadacheEveryDay== "是")
                    {
                        return "Yes";
                    }
                    if (GlobalData.HeadacheAnnotation.HeadacheEveryDay == "否")
                    {
                        return "No";
                    }
                    return "No";
                    case "000013"://头痛是否每月发作
                    if (GlobalData.HeadacheAnnotation.MonthHeadache == "是")
                    {
                        return "Yes";
                    }
                    if (GlobalData.HeadacheAnnotation.MonthHeadache == "否")
                    {
                        return "No";
                    }
                    return "No";
                  case "000009"://头痛有无周期性
                    if (GlobalData.HeadacheAnnotation.TimeFixed=="Yes")
                    {
                        return "Yes";
                    }
                    return "No";
                  case "000005"://头痛每天频率
                    if (GlobalData.HeadacheAnnotation.DayFrequency!="")
                    {
                        return GlobalData.HeadacheAnnotation.DayFrequency;
                    }
            
                    return "0";
                    
                  case "000008"://头痛每月时长
                    if (GlobalData.HeadacheAnnotation.MHeadacheday != "")
                    {
                        return GlobalData.HeadacheAnnotation.MHeadacheday;
                    }
                    return "0";
                  case "000006"://头痛每月频率
                  
                       return GlobalData.HeadacheAnnotation.MonthFrequency;
                
                  case "000007"://头痛每次持续时长
                       Double time=0;
                       if(GlobalData.HeadacheAnnotation.LastTimeBeforeUnit=="分钟")
                       {
                     
                            time = GlobalData.HeadacheAnnotation.LastTimeBefore / 60.0;
                        }
                         if(GlobalData.HeadacheAnnotation.LastTimeBeforeUnit=="小时")
                         {
                             time = GlobalData.HeadacheAnnotation.LastTimeBefore;
                         }
                         if(GlobalData.HeadacheAnnotation.LastTimeBeforeUnit=="天")
                         {
                            time = GlobalData.HeadacheAnnotation.LastTimeBefore * 24;
                         }
                    return time.ToString();
                  case "H000119"://曲普坦类药物总服药时长
                  foreach (Drug drug in GlobalData.PreviousTreatment.PreviousAcesodyneDrug)
                  {
                      if (drug.DrugKind == "曲坦类")
                      {
                          return drug.DSideEffect;
                      }
                  }
                  return "0";
                  case "H000120"://曲普坦类药物每月服药时长
                  foreach (Drug drug in GlobalData.PreviousTreatment.PreviousAcesodyneDrug)
                  {
                      if (drug.DrugKind == "曲坦类")
                      {
                          return drug.DrugEffect;
                      }
                  }

                  return "0";
                  case "000012"://每次发作是否缓解
                  if (GlobalData.HeadacheAnnotation.EveryRelief == "是")
                  {
                      return "Yes";
                  }
                  if (GlobalData.HeadacheAnnotation.EveryRelief == "否")
                  {
                      return "No";
                  }
                  return "No";
                  case "H000121"://非曲普坦类药物总服药时长
                 
                  foreach (Drug drug in GlobalData.PreviousTreatment.PreviousAcesodyneDrug)
                  {
                      if (drug.DrugKind != "曲坦类")
                      {
                          return drug.DSideEffect;
                      }
                  }
                  return "0";
                  case "H000122"://非曲普坦类药物每月服药时长
                  foreach (Drug drug in GlobalData.PreviousTreatment.PreviousAcesodyneDrug)
                  {
                      if (drug.DrugKind != "曲坦类")
                      {
                          return drug.DrugEffect;
                      }
                  }

                  return "0";
                  case "000014"://首日发作缓解所用时间
                  if (GlobalData.HeadacheAnnotation.FirstRelief == "是")
                    {
                        return "Yes";
                    }
                  if (GlobalData.HeadacheAnnotation.FirstRelief == "否")
                    {
                        return "No";
                    }
                      return "No";
                    //case "000004"://首日头痛发作时间
                    //return "No";





                case "H000005"://发热
                    return "No";

                case "H000006"://呕吐
                    
                        if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("呕吐"))
                        {
                            return "Yes";
                        }
                    

                    return "No";

                case "H000007"://因体力活动加剧
                      if (GlobalData.HeadacheAnnotation.WorsenDegree.Contains("从无") || GlobalData.HeadacheAnnotation.WorsenDegree=="")
                    {
                        return "No";
                    }
                    else
                    {
                        return "Yes";
                    }

                case "E23.613"://垂体卒中
                    return "No";

                case "H000008"://头痛程度-中度
                    if(GlobalData.HeadacheAnnotation.Markqualitative.Contains("中"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000009"://头痛程度-轻度
                    if(GlobalData.HeadacheAnnotation.Markqualitative.Contains("轻"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000010"://头痛程度-重度
                    if(GlobalData.HeadacheAnnotation.Markqualitative.Contains("重"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000011"://妊娠期或产后头痛                    
                    return "No";

                case "H000012"://对声、光敏感
                    return "No";

                case "H000013"://恶心

                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("恶心") )
                        {
                            return "Yes";
                        }
                    

                    return "No";

                case "H000014"://打哈欠
                    foreach(HeadachePlus2 sympton in GlobalData.HeadacheAnnotation.HeadacheProdrome)
                    {
                        if(sympton.AspectName.Contains("打哈欠"))
                        {
                            return "Yes";
                        }
                    }

                    return "No";

                case "H000015"://搏动性痛
                    if(GlobalData.HeadacheAnnotation.HeadacheType.Contains("搏动"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "G43.0"://无先兆偏头痛
                    return "No";

                case "H000016"://无法集中注意力
                    foreach(HeadachePlus2 sympton in GlobalData.HeadacheAnnotation.HeadacheProdrome)
                    {
                        if(sympton.AspectName.Contains("注意力障碍"))
                        {
                            return "Yes";
                        }
                    }

                    return "No";

                case "G43.1"://有先兆偏头痛
                    return "No";

                case "H000017"://机会性感染
                    return "No";

                case "H000018"://由咳嗽、用力动作诱发的头痛
                    return "No";

                case "H000019"://畏光
                   
                        if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("畏光") )
                        {
                            return "Yes";
                        }
                   

                     return "No";

                case "H000020"://畏声
                    
                        if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("怕吵") )
                        {
                            return "Yes";
                        }
                  

                    return "No";

                case "H000021"://疲劳
                    return "No";

                case "H000022"://皮层静脉/静脉窦血栓形成
                    return "No";

                case "H000023"://皮疹
                    return "No";

                case "H000024"://硬膜下血肿
                    return "No";

                case "H000025"://神经系统局灶症状和体征
                    return "No";

                case "H000026"://突然发生的头痛
                    if (GlobalData.HeadacheAnnotation.BeginForm.Contains("突然"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000027"://系统性感染
                    return "No";

                case "H000028"://系统性病变征象
                    return "No";

                case "G44.2"://紧张型头痛
                    return "No";

                case "H000029"://结缔组织疾病
                    return "No";

                case "I61.902"://脑出血
                    return "No";

                case "I64.04"://脑卒中
                    return "No";

                case "H000030"://脑外伤
                    return "No";

                case "H000031"://脸色苍白
                    return "No";

                case "H000032"://虚弱
                    foreach(HeadachePlus2 sympton in GlobalData.HeadacheAnnotation.HeadacheProdrome)
                    {
                        if(sympton.AspectName.Contains("虚弱"))
                        {
                            return "Yes";
                        }
                    }

                    return "No";

                case "H000033"://蛛网膜下腔出血
                    return "No";

                case "I77.605"://血管炎
                    return "No";

                case "H000034"://视乳头水肿
                    if (GlobalData.PhysicalExam.FunduScope.Contains("视乳头水肿"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000035"://视觉模糊
                    return "No";

                case "H000036"://认知障碍
                    return "No";

                case "H000037"://转移癌
                    return "No";

                case "H000038"://过度使用药物
                    return "No";

                case "H000039"://逐渐加重的头痛
                    if (GlobalData.HeadacheAnnotation.BeginForm.Contains("逐渐加重"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000040"://钝痛
                    return "No";

                case "H000041"://颅内占位病变
                    return "No";

                case "H000042"://颅内感染
                    return "No";

                case "H000043": //颈强直
                    return "No";;

                case "H000044": //颈部僵硬
                    foreach(HeadachePlus2 sympton in GlobalData.HeadacheAnnotation.HeadacheProdrome)
                    {
                        if(sympton.AspectName.Contains("颈部僵硬"))
                        {
                            return "Yes";
                        }
                    }

                    return "No";

                case "H000045": //频率
                    return "No";

                case "M31.601": //内动脉炎
                    return "No";

                case "I10": //高血压
                    return "No";

                case "D000001": //头痛诊断
                    return MappingDignoseConclusion("Headache_Diagnosis");

                case "H000124":
                    if (GlobalData.HeadacheAnnotation.HeadacheType.Contains("过电"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 映射诊断结论到推理机
        /// </summary>
        /// <param name="DignoseConclusionMapper"></param>
        /// <returns></returns>
        private static string MappingDignoseConclusion(string DignoseConclusionMapper)
        {
            for (int i = 0; i < StructedIEResult.lstStructedConclude.Count; i++)
            {
                for (int j = 0; j < StructedIEResult.lstStructedConclude[i].lstConclude.Count; j++)
                {
                    if (StructedIEResult.lstStructedConclude[i].lstConclude[j].strDataName == DignoseConclusionMapper)
                    {
                        if (StructedIEResult.lstStructedConclude[i].lstConclude[j].strDataValue != "NULL")
                        {
                            return StructedIEResult.lstStructedConclude[i].lstConclude[j].strDataValue;
                        }
                        else
                        {
                            return "NO";
                        }

                    }
                }
            }
            return "NO";
        }
        
        #endregion
    }
}
