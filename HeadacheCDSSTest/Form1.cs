using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace HeadacheCDSSTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDiagnosis_Click(object sender, EventArgs e)
        {

              localhost.InputData InputDataValue = new localhost.InputData();
              InputDataValue.m_nHeadache_Duration = int.Parse(textBoxDuration.Text);
              InputDataValue.m_nHeadache_Duration_PerTime = float.Parse(textBoxDurationPertime.Text);                      //头痛每次持续时间
              if (comboBoxUnit.SelectedIndex == 0)
              {
                  InputDataValue.m_nHeadache_Duration_PerTime_Unit = "秒";
              }
              else if(comboBoxUnit.SelectedIndex == 1)
              {
                  InputDataValue.m_nHeadache_Duration_PerTime_Unit = "分";
              }
              else if (comboBoxUnit.SelectedIndex == 2)
              {
                  InputDataValue.m_nHeadache_Duration_PerTime_Unit = "小时";
              }
              else
              {
                  InputDataValue.m_nHeadache_Duration_PerTime_Unit = "天";
              }

            
              InputDataValue.m_nHeadache_TotalNumber =  int.Parse(textBoxNumber.Text);                                    //头痛总次数

              InputDataValue.m_nHeadache_Monthly_Duration = int.Parse(textBoxdayperMonth.Text);                          //头痛每月持续时长

               if (comboBoxDrugType.SelectedIndex == 0)//曲普坦类
               {
                  InputDataValue.m_nTriptan_Total_Drugin_Duration =  int.Parse(textBoxDugMonth.Text);                           //曲普坦类药物总服药时长
                  InputDataValue.m_nTriptan_Drugin_Monthly =  int.Parse(textBoxDrugDayPerMonth.Text);  //曲普坦类药物每月服药时长
                  InputDataValue.m_nNon_Triptan_Total_Drugin_Duration = 0;                              //非曲普坦类药物总服药时长
                  InputDataValue.m_nNon_Triptan_Drugin_Monthly = 0 ;                                     //非曲普坦类药物每月服药时长
               } 
               else//非曲普坦类
               {
                   InputDataValue.m_nTriptan_Total_Drugin_Duration = 0 ;                           //曲普坦类药物总服药时长
                   InputDataValue.m_nTriptan_Drugin_Monthly = 0 ;  //曲普坦类药物每月服药时长
                   InputDataValue.m_nNon_Triptan_Total_Drugin_Duration = int.Parse(textBoxDugMonth.Text);                              //非曲普坦类药物总服药时长
                   InputDataValue.m_nNon_Triptan_Drugin_Monthly = int.Parse(textBoxDrugDayPerMonth.Text);   
               }

               if(comboBoxLocation.SelectedIndex == 0)
               {
                  InputDataValue.m_HeadacheLocation = localhost.HeadacheLocation.Uni_Pain; //头痛部位 
               }
               else
               {
                   InputDataValue.m_HeadacheLocation = localhost.HeadacheLocation.Bi_Pain;
               }


               if (comboBoxzhouqixing.SelectedIndex == 0 )//头痛是否周期性
               {
                  InputDataValue.m_bPeriodism = true;
               } 
               else
               {
                   InputDataValue.m_bPeriodism = false;
               }

               if (comboBoxWork.SelectedIndex == 0)
               {
                  InputDataValue.m_bWorsen_By_Physicial_Activity = true;                                                //头痛是否因体力活动加剧
               } 
               else
               {
                   InputDataValue.m_bWorsen_By_Physicial_Activity = false;
               }
                                                                                
               if (comboBoxchengdu.SelectedIndex == 0)
               {
                  InputDataValue.m_nHeadacheDegree = localhost.HeadacheDegree.Mild;                                                              //头痛程度
               } 
               else if(comboBoxchengdu.SelectedIndex == 1)
               {
                   InputDataValue.m_nHeadacheDegree = localhost.HeadacheDegree.Middle;
               }
               else
               {
                   InputDataValue.m_nHeadacheDegree = localhost.HeadacheDegree.Heavy;
               }

               if (comboBoxproperty.SelectedIndex == 0)
               {
                  InputDataValue.m_nHeadahceProperty = localhost.HeadacheProperty.Pulse_Pain;                                                             //头痛性质
               } 
               else if(comboBoxproperty.SelectedIndex == 1)
               {
                   InputDataValue.m_nHeadahceProperty = localhost.HeadacheProperty.Pressure_Pain; 
               }
               else
               {
                   InputDataValue.m_nHeadahceProperty = localhost.HeadacheProperty.Electric_Shock_Like_Pain; 
               }
               
              if (comboBoxDalilyHeadache.SelectedIndex == 0)
              {
                 InputDataValue.m_bDaily_Headache = true;
              }
              else
              {
                  InputDataValue.m_bDaily_Headache = false;
              }

                 List<localhost.HeadacheAssociatedSymptoms> HeadacheAssociatedSymptonList = new List<localhost.HeadacheAssociatedSymptoms>();

                 if (checkBoxexin.Checked == true)
                 {
                     HeadacheAssociatedSymptonList.Add(localhost.HeadacheAssociatedSymptoms.Nausea);
                 }
                 if (checkBoxotu.Checked == true)
                 {
                     HeadacheAssociatedSymptonList.Add(localhost.HeadacheAssociatedSymptoms.Vomit);
                 }
                 if (checkBoxweisheng.Checked == true)
                 {
                     HeadacheAssociatedSymptonList.Add(localhost.HeadacheAssociatedSymptoms.Fair_Of_Sound);
                 }
                 if (checkBoxweiguang.Checked == true)
                 {
                     HeadacheAssociatedSymptonList.Add(localhost.HeadacheAssociatedSymptoms.Fire_Of_Light);
                 }
                 if (checkBox1.Checked == true)
                 {
                     HeadacheAssociatedSymptonList.Add(localhost.HeadacheAssociatedSymptoms.Ipsilateral_Heyelids_Swelling);
                 }
                 if (checkBox2.Checked == true)
                 {
                     HeadacheAssociatedSymptonList.Add(localhost.HeadacheAssociatedSymptoms.Miosis_or_Blepharoptosis);
                 }
                 if (checkBox3.Checked == true)
                 {
                     HeadacheAssociatedSymptonList.Add(localhost.HeadacheAssociatedSymptoms.Conjunctival_congestion_or_Tears);
                 }
                 if (checkBox4.Checked == true)
                 {
                     HeadacheAssociatedSymptonList.Add(localhost.HeadacheAssociatedSymptoms.Frontal_facial_Sweating);
                 }
                 if (checkBox5.Checked == true)
                 {
                     HeadacheAssociatedSymptonList.Add(localhost.HeadacheAssociatedSymptoms.Blocked_or_Watery_Nose);
                 }

                 InputDataValue.m_HeadacheAssociatedSymptonList =  HeadacheAssociatedSymptonList.ToArray();


                 List<localhost.HeadacheAura> HeadacheAuraList = new List<localhost.HeadacheAura>();
        
                 if (radioButton1.Checked == true)
                 {
                     HeadacheAuraList.Add(localhost.HeadacheAura.Hemi_Visual_Aura);
                 }
                 if (radioButton2.Checked == true)
                 {
                     HeadacheAuraList.Add(localhost.HeadacheAura.Bilateral_Visual_Aura);
                 }
                 if (radioButton3.Checked == true)
                 {
                     HeadacheAuraList.Add(localhost.HeadacheAura.Feeling_Aura);
                 }
                 if (radioButton4.Checked == true)
                 {
                     HeadacheAuraList.Add(localhost.HeadacheAura.Allolalia);
                 }

                 InputDataValue.m_HeadacheAuraList = HeadacheAuraList.ToArray();
       
            string strReslut = null;
         
            localhost.InferenceService test = new localhost.InferenceService();
            test.DoInference(InputDataValue, ref strReslut);

            labelResult.Text = strReslut;



        }

      
    }
}
