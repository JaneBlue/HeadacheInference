using System;
using System.Collections.Generic;
using System.Text;

namespace CDSSSystemData
{
    public static class GlobalData
    {
        /// <summary>
        /// 当前登录用户信息
        /// </summary>
        public static CDSSUserInfo UserInfo = new CDSSUserInfo();
        /// <summary>
        /// 病人基本信息
        /// </summary>
        public static CDSSPatBasicInfo PatBasicInfo = new CDSSPatBasicInfo();
        /// <summary>
        /// 继发性头痛
        /// </summary>
        public static CDSSSecondHeadacheSign SheadacheSign = new CDSSSecondHeadacheSign();


        /// <summary>
        /// 头痛概述
        /// </summary>
        public static CDSSHeadacheAnnotation HeadacheAnnotation = new CDSSHeadacheAnnotation();
       

        /// <summary>
        /// 体格检查
        /// </summary>
        public static  CDSSPhysicalExam PhysicalExam = new CDSSPhysicalExam();

        /// <summary>
        /// 既往评估/治疗
        /// </summary>
        public static CDSSPreviousTreatment PreviousTreatment = new CDSSPreviousTreatment();
       


        /// <summary>
        /// 评估与诊断
        /// </summary>
        public static CDSSEvaluationAndDiagnosis EvaluationAndDiagnosis = new CDSSEvaluationAndDiagnosis();
       

        /// <summary>
        /// 治疗处理
        /// </summary>
        public static CDSSTreatment Treatment = new CDSSTreatment();
        


        /// <summary>
        /// 近期生活和残障评估
        /// </summary>
        public static CDSSRecentLife RecentLife = new CDSSRecentLife();
    

        /// <summary>
        /// 系统回顾
        /// </summary>
        public static CDSSSystemiticEvaluation SystemiticEvaluation = new CDSSSystemiticEvaluation();
       


        /// <summary>
        /// 生活方式和病史
        /// </summary>
        public static CDSSLifeStyleAndDiseaseHistory LifeStyleAndDiseaseHistory = new CDSSLifeStyleAndDiseaseHistory();
        


        /// <summary>
        /// 家族史
        /// </summary>
        public static CDSSFamilyHistory FamilyHistory = new CDSSFamilyHistory();

        public static CDSSDiagnosedResult DiagnosedResult = new CDSSDiagnosedResult();
       
       
        /// <summary>
        /// 清空当前加载的病人的所有数据
        /// </summary>
        public static void Clear()
        {
            PatBasicInfo.Clear();
            SheadacheSign.Clear();
            HeadacheAnnotation.Clear();
            PhysicalExam.Clear();
            PreviousTreatment.Clear();
            EvaluationAndDiagnosis.Clear();
            Treatment.Clear();
            RecentLife.Clear();
            SystemiticEvaluation.Clear();
            LifeStyleAndDiseaseHistory.Clear();
            FamilyHistory.Clear();
            DiagnosedResult.Clear();
        }
    }
}
