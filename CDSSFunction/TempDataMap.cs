using System;
using System.Collections.Generic;
using System.Text;
using CDSSSystemData;

    /***************************************************
     * �����ˣ� XY
     * ����ʱ�䣺2009.3.16
     * �������ݣ�ӳ��ģ��
     * ����˵�������ݴ��������
     * *************************************************/

namespace CDSSFunction
{    
    public class TempDataMap
    {
        #region ӳ��ģ��
        public static string ObtainDataValueWithDataCode(string strDataCode)
        {
            switch (strDataCode)
            {
                case "B24.01"://AIDS
                    return "No";

                case "G44.0"://�Լ���ͷʹ
                    return "No";

                case "G03.952"://���������ۺ���
                    return "No";

                case "G43"://ƫͷʹ
                    return "No";

                case "H000001"://����
                    if(GlobalData.HeadacheAnnotation.HeadacheAura.Count > 0)
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }
                        

                case "Q28.001"://����������
                    return "No";

                case "H000002"://������ʹ
//                     foreach(HeadachePlus2 area in GlobalData.HeadacheAnnotation.HeadachePosition)
//                     {
//                         if(area.AspectName.Contains("��") || area.AspectName.Contains("��"))
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
                                   

                case "H000003"://ѹ����ʹ
                    if (GlobalData.HeadacheAnnotation.HeadacheType.Contains("ѹ��") || GlobalData.HeadacheAnnotation.HeadacheType.Contains("����") || GlobalData.HeadacheAnnotation.HeadacheType.Contains("��ʹ"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000004"://˫����ʹ
//                     foreach(HeadachePlus2 area in GlobalData.HeadacheAnnotation.HeadachePosition)
//                     {
//                         if (area.AspectName.Contains("˫��") || area.AspectName.Contains("ȫͷʹ"))
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
                case"H000107"://ͬ����������
                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("ͬ������ˮ��"))
                    {
                        return "Yes";
                    }
                    return "No";
                case"H000109"://ͬ��ͫ����С�������´�
                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("ͬ�������´�") || GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("ͬ��ͫ����С"))
                    {
                        return "Yes";
                    }
                    return "No";
                case"H000115"://ͬ���Ĥ��Ѫ
                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("ͬ���Ĥ��Ѫ/����"))
                    {
                        return "Yes";
                    }
                    return "No";
                case"H000108"://ͬ���沿����
                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("ͬ��ǰ��/�沿����"))
                    {
                        return "Yes";
                    }
                    return "No";
                case"H000116" ://ͬ�����������
                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("ͬ�����/����"))
                    {
                        return "Yes";
                    }
                    return "No";

                case"H000117"://������
                    if (GlobalData.HeadacheAnnotation.TimeFixed=="Yes")
                    {
                        return "Yes";
                    }
                    return "No";
                case"H000118"://���겻��
                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("�о��������궯"))
                    {
                        return "Yes";
                    }
                    return "No";
                case"H000112"://�о����ף���̸С���ľ��
                   foreach(  HeadachePlus2 aura in GlobalData.HeadacheAnnotation.HeadacheAura )
                   {
                    if(aura.AspectName == "�о�")
                    {
                        return "Yes";
                    }
                   }
                    return "No";
                case "H000111"://�Ӿ����ף���״��ɫ�ߣ�
                  foreach(  HeadachePlus2 aura in GlobalData.HeadacheAnnotation.HeadacheAura )
                   {
                    if(aura.AspectName == "�Ӿ�")
                    {
                        return "Yes";
                    }
                   }
                    return "No"; 

                    case "H000113"://�����ϰ�
                   foreach(  HeadachePlus2 aura in GlobalData.HeadacheAnnotation.HeadacheAura )
                   {
                    if(aura.AspectName == "�����ϰ�")
                    {
                        return "Yes";
                    }
                   }
                    return "No";

                    case "000003"://ͷʹ�ܴ���
//                     if (GlobalData.HeadacheAnnotation.HeadacheTrait == "���Ʒ���<5��")
//                    {
//                        return "3";
//                    }
//                     if (GlobalData.HeadacheAnnotation.HeadacheTrait == "���Ʒ���6-9��")
//                     {
//                         return "7";
//                     }
//                     if (GlobalData.HeadacheAnnotation.HeadacheTrait == "���Ʒ�������10��")
//                     {
//                         return "12";
//                     }
//                     if (GlobalData.HeadacheAnnotation.HeadacheTrait == "����ͷʹ")
//                     {
//                         return "15";
//                     }
//                         return "0";
                    return GlobalData.HeadacheAnnotation.HeadacheTrait.ToString();

                    case "000002"://ͷʹ����ʱ��
//                     if (GlobalData.HeadacheAnnotation.BeginTime != null)
//                     {
//                         TimeSpan ts = DateTime.Now - GlobalData.HeadacheAnnotation.BeginTime;
//                         int month = ts.Days / 30;
//                         return month.ToString();
//                     }
//                     return "0";
                       return GlobalData.HeadacheAnnotation.nHeadahce_Duration.ToString();

                    case "H000123"://ͷʹ�Ƿ�ÿ�췢��
                    if (GlobalData.HeadacheAnnotation.HeadacheEveryDay== "��")
                    {
                        return "Yes";
                    }
                    if (GlobalData.HeadacheAnnotation.HeadacheEveryDay == "��")
                    {
                        return "No";
                    }
                    return "No";
                    case "000013"://ͷʹ�Ƿ�ÿ�·���
                    if (GlobalData.HeadacheAnnotation.MonthHeadache == "��")
                    {
                        return "Yes";
                    }
                    if (GlobalData.HeadacheAnnotation.MonthHeadache == "��")
                    {
                        return "No";
                    }
                    return "No";
                  case "000009"://ͷʹ����������
                    if (GlobalData.HeadacheAnnotation.TimeFixed=="Yes")
                    {
                        return "Yes";
                    }
                    return "No";
                  case "000005"://ͷʹÿ��Ƶ��
                    if (GlobalData.HeadacheAnnotation.DayFrequency!="")
                    {
                        return GlobalData.HeadacheAnnotation.DayFrequency;
                    }
            
                    return "0";
                    
                  case "000008"://ͷʹÿ��ʱ��
                    if (GlobalData.HeadacheAnnotation.MHeadacheday != "")
                    {
                        return GlobalData.HeadacheAnnotation.MHeadacheday;
                    }
                    return "0";
                  case "000006"://ͷʹÿ��Ƶ��
                  
                       return GlobalData.HeadacheAnnotation.MonthFrequency;
                
                  case "000007"://ͷʹÿ�γ���ʱ��
                       Double time=0;
                       if(GlobalData.HeadacheAnnotation.LastTimeBeforeUnit=="����")
                       {
                     
                            time = GlobalData.HeadacheAnnotation.LastTimeBefore / 60.0;
                        }
                         if(GlobalData.HeadacheAnnotation.LastTimeBeforeUnit=="Сʱ")
                         {
                             time = GlobalData.HeadacheAnnotation.LastTimeBefore;
                         }
                         if(GlobalData.HeadacheAnnotation.LastTimeBeforeUnit=="��")
                         {
                            time = GlobalData.HeadacheAnnotation.LastTimeBefore * 24;
                         }
                    return time.ToString();
                  case "H000119"://����̹��ҩ���ܷ�ҩʱ��
                  foreach (Drug drug in GlobalData.PreviousTreatment.PreviousAcesodyneDrug)
                  {
                      if (drug.DrugKind == "��̹��")
                      {
                          return drug.DSideEffect;
                      }
                  }
                  return "0";
                  case "H000120"://����̹��ҩ��ÿ�·�ҩʱ��
                  foreach (Drug drug in GlobalData.PreviousTreatment.PreviousAcesodyneDrug)
                  {
                      if (drug.DrugKind == "��̹��")
                      {
                          return drug.DrugEffect;
                      }
                  }

                  return "0";
                  case "000012"://ÿ�η����Ƿ񻺽�
                  if (GlobalData.HeadacheAnnotation.EveryRelief == "��")
                  {
                      return "Yes";
                  }
                  if (GlobalData.HeadacheAnnotation.EveryRelief == "��")
                  {
                      return "No";
                  }
                  return "No";
                  case "H000121"://������̹��ҩ���ܷ�ҩʱ��
                 
                  foreach (Drug drug in GlobalData.PreviousTreatment.PreviousAcesodyneDrug)
                  {
                      if (drug.DrugKind != "��̹��")
                      {
                          return drug.DSideEffect;
                      }
                  }
                  return "0";
                  case "H000122"://������̹��ҩ��ÿ�·�ҩʱ��
                  foreach (Drug drug in GlobalData.PreviousTreatment.PreviousAcesodyneDrug)
                  {
                      if (drug.DrugKind != "��̹��")
                      {
                          return drug.DrugEffect;
                      }
                  }

                  return "0";
                  case "000014"://���շ�����������ʱ��
                  if (GlobalData.HeadacheAnnotation.FirstRelief == "��")
                    {
                        return "Yes";
                    }
                  if (GlobalData.HeadacheAnnotation.FirstRelief == "��")
                    {
                        return "No";
                    }
                      return "No";
                    //case "000004"://����ͷʹ����ʱ��
                    //return "No";





                case "H000005"://����
                    return "No";

                case "H000006"://Ż��
                    
                        if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("Ż��"))
                        {
                            return "Yes";
                        }
                    

                    return "No";

                case "H000007"://��������Ӿ�
                      if (GlobalData.HeadacheAnnotation.WorsenDegree.Contains("����") || GlobalData.HeadacheAnnotation.WorsenDegree=="")
                    {
                        return "No";
                    }
                    else
                    {
                        return "Yes";
                    }

                case "E23.613"://��������
                    return "No";

                case "H000008"://ͷʹ�̶�-�ж�
                    if(GlobalData.HeadacheAnnotation.Markqualitative.Contains("��"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000009"://ͷʹ�̶�-���
                    if(GlobalData.HeadacheAnnotation.Markqualitative.Contains("��"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000010"://ͷʹ�̶�-�ض�
                    if(GlobalData.HeadacheAnnotation.Markqualitative.Contains("��"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000011"://�����ڻ����ͷʹ                    
                    return "No";

                case "H000012"://������������
                    return "No";

                case "H000013"://����

                    if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("����") )
                        {
                            return "Yes";
                        }
                    

                    return "No";

                case "H000014"://���Ƿ
                    foreach(HeadachePlus2 sympton in GlobalData.HeadacheAnnotation.HeadacheProdrome)
                    {
                        if(sympton.AspectName.Contains("���Ƿ"))
                        {
                            return "Yes";
                        }
                    }

                    return "No";

                case "H000015"://������ʹ
                    if(GlobalData.HeadacheAnnotation.HeadacheType.Contains("����"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "G43.0"://������ƫͷʹ
                    return "No";

                case "H000016"://�޷�����ע����
                    foreach(HeadachePlus2 sympton in GlobalData.HeadacheAnnotation.HeadacheProdrome)
                    {
                        if(sympton.AspectName.Contains("ע�����ϰ�"))
                        {
                            return "Yes";
                        }
                    }

                    return "No";

                case "G43.1"://������ƫͷʹ
                    return "No";

                case "H000017"://�����Ը�Ⱦ
                    return "No";

                case "H000018"://�ɿ��ԡ����������շ���ͷʹ
                    return "No";

                case "H000019"://η��
                   
                        if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("η��") )
                        {
                            return "Yes";
                        }
                   

                     return "No";

                case "H000020"://η��
                    
                        if (GlobalData.HeadacheAnnotation.HeadacheCompanionSympton.Contains("�³�") )
                        {
                            return "Yes";
                        }
                  

                    return "No";

                case "H000021"://ƣ��
                    return "No";

                case "H000022"://Ƥ�㾲��/�����Ѫ˨�γ�
                    return "No";

                case "H000023"://Ƥ��
                    return "No";

                case "H000024"://ӲĤ��Ѫ��
                    return "No";

                case "H000025"://��ϵͳ����֢״������
                    return "No";

                case "H000026"://ͻȻ������ͷʹ
                    if (GlobalData.HeadacheAnnotation.BeginForm.Contains("ͻȻ"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000027"://ϵͳ�Ը�Ⱦ
                    return "No";

                case "H000028"://ϵͳ�Բ�������
                    return "No";

                case "G44.2"://������ͷʹ
                    return "No";

                case "H000029"://�����֯����
                    return "No";

                case "I61.902"://�Գ�Ѫ
                    return "No";

                case "I64.04"://������
                    return "No";

                case "H000030"://������
                    return "No";

                case "H000031"://��ɫ�԰�
                    return "No";

                case "H000032"://����
                    foreach(HeadachePlus2 sympton in GlobalData.HeadacheAnnotation.HeadacheProdrome)
                    {
                        if(sympton.AspectName.Contains("����"))
                        {
                            return "Yes";
                        }
                    }

                    return "No";

                case "H000033"://����Ĥ��ǻ��Ѫ
                    return "No";

                case "I77.605"://Ѫ����
                    return "No";

                case "H000034"://����ͷˮ��
                    if (GlobalData.PhysicalExam.FunduScope.Contains("����ͷˮ��"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000035"://�Ӿ�ģ��
                    return "No";

                case "H000036"://��֪�ϰ�
                    return "No";

                case "H000037"://ת�ư�
                    return "No";

                case "H000038"://����ʹ��ҩ��
                    return "No";

                case "H000039"://�𽥼��ص�ͷʹ
                    if (GlobalData.HeadacheAnnotation.BeginForm.Contains("�𽥼���"))
                    {
                        return "Yes";
                    }
                    else
                    {
                        return "No";
                    }

                case "H000040"://��ʹ
                    return "No";

                case "H000041"://­��ռλ����
                    return "No";

                case "H000042"://­�ڸ�Ⱦ
                    return "No";

                case "H000043": //��ǿֱ
                    return "No";;

                case "H000044": //������Ӳ
                    foreach(HeadachePlus2 sympton in GlobalData.HeadacheAnnotation.HeadacheProdrome)
                    {
                        if(sympton.AspectName.Contains("������Ӳ"))
                        {
                            return "Yes";
                        }
                    }

                    return "No";

                case "H000045": //Ƶ��
                    return "No";

                case "M31.601": //�ڶ�����
                    return "No";

                case "I10": //��Ѫѹ
                    return "No";

                case "D000001": //ͷʹ���
                    return MappingDignoseConclusion("Headache_Diagnosis");

                case "H000124":
                    if (GlobalData.HeadacheAnnotation.HeadacheType.Contains("����"))
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
        /// ӳ����Ͻ��۵������
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
