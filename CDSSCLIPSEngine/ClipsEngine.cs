using System;
using System.Collections.Generic;
using System.Text;
using ProAi.Clips;
using System.Collections;
using CDSSvMRDataDef;
using System.Configuration;
using System.IO;
using System.Xml;

namespace CDSSCLIPSEngine
{
    public class ClipsEngine
    {
        public RuleEngine m_oRuleEngine;

        public struct CodeFull
        {
            public string DisplayFullContent;
            public string DisplaySimpleContent;
            public string CodeName;
            public CodeFull(string strDisplayFullContent, string strDisplaySimpleContent, string strCodeName)
            {
                DisplayFullContent = strDisplayFullContent;
                DisplaySimpleContent = strDisplaySimpleContent;
                CodeName = strCodeName;
            }
        }

        public struct CodeSimple
        {
            public string DisplayContent;
            public string CodeName;
            public CodeSimple(string strDisplayContent, string strCodeName)
            {
                DisplayContent = strDisplayContent;
                CodeName = strCodeName;
            }
        }

        public struct QuestionChoices
        {
            public CodeFull Question;
            public List<CodeSimple> Choices;
        }

        public struct Options
        {
            public List<string> NextRuleFiles;
            public List<QuestionChoices> Questions;
            public void Init()
            {
                NextRuleFiles = new List<string>();
                Questions = new List<QuestionChoices>();
            }
        }

        public struct DataVacancy
        {
            public List<string> Data;
            public string CurrentRuleFile;
            public void Init()
            {
                Data = new List<string>();
                CurrentRuleFile = string.Empty;
            }
        }

        public struct Result
        {
            public List<string> Recommendations;
            public DataVacancy DataNotice;
            public Options InterChoices;
            public List<Interpretation> lstInInterpretation;
            public List<DiseaseCriterion> lstPreDiagnose;

            public void Init()
            {
                Recommendations = new List<string>();
                DataNotice = new DataVacancy();
                DataNotice.Init();
                InterChoices = new Options();
                InterChoices.Init();
                lstInInterpretation = new List<Interpretation>();
                lstPreDiagnose = new List<DiseaseCriterion>();
            }
        }

        public struct Interpretation
        {
            public string strInterpretationIndex;
            public List<string> lstRecomm;
            public List<string> lstFactUsed;

            public Interpretation(string strInterpretationIndex)
            {
                this.strInterpretationIndex = strInterpretationIndex;
                lstRecomm = new List<string>();
                lstFactUsed = new List<string>();
            }
        }

        public struct DiseaseCriterion
        {
            public string strDisease;
            public List<string> lstCriterion;
        }

        private Result m_stInferResult;

        public Result InferResult
        {
            get
            {
                return m_stInferResult;
            }
            set
            {
                m_stInferResult = value;
            }
        }




        //事实修改标志
        public enum EnumFactChangeFlag
        {
            Add = 0,
            Modified
        };

        private int FactIndexMax = -1;
        public struct FactInfo
        {
            public string FactValue;
            public int FactIndex;
            public EnumFactChangeFlag FactChangeFlag;
            public FactInfo(string strFactValue, int nFactIndex, EnumFactChangeFlag emFactChangeFlag)
            {
                FactValue = strFactValue;
                FactIndex = nFactIndex;
                FactChangeFlag = emFactChangeFlag;
            }
        }

        public Hashtable HTFactInfo = new Hashtable();

        public ClipsEngine()
        {
            m_oRuleEngine = new RuleEngine();
            m_stInferResult = new Result();
            m_stInferResult.Init();

        }

        public void Clear()
        {
            m_oRuleEngine.UserFunctionManager.UnDefineFunction("Recommendation");
            m_oRuleEngine.UserFunctionManager.UnDefineFunction("DataNotify");
            m_oRuleEngine.UserFunctionManager.UnDefineFunction("PromptChoice");
            m_oRuleEngine.UserFunctionManager.UnDefineFunction("FileLoadNotify");
            m_oRuleEngine.UserFunctionManager.UnDefineFunction("OperateFact");
            m_oRuleEngine.UserFunctionManager.UnDefineFunction("InterpretationIndex");
            m_oRuleEngine.UserFunctionManager.UnDefineFunction("FactUsed");
            m_oRuleEngine.UserFunctionManager.UnDefineFunction("PreDiagnose");
            m_oRuleEngine.UserFunctionManager.UnDefineFunction("OperateNumberFact");
            m_oRuleEngine.Clear();
            //m_oRuleEngine.Reset();
            
            FactIndexMax = -1;
            HTFactInfo.Clear();
            m_stInferResult.Init();
        }

        public RuleEngine RuleEngineObj
        {
            get
            {
                if (m_oRuleEngine == null)
                    m_oRuleEngine = new RuleEngine();

                return m_oRuleEngine;
            }
        }

        /// <summary>
        /// 根据推理类型，选择CLIPS推理入口文件
        /// </summary>
        /// <param name="strRuleLevel"></param>
        /// <param name="oTriggeringEvent"></param>
        /// <returns></returns>
        public static string ObtainRuleEntrance(string strRuleLevel, vMRClsDef.TriggeringEvent oTriggeringEvent)
        {
            if (strRuleLevel == "LEVEL_CLINICIANS")
            {
                switch (oTriggeringEvent.m_emInferenceResultType)
                {
                    case vMRClsDef.EnumInferenceResultType.DIAGNOSIS:
                    case vMRClsDef.EnumInferenceResultType.THERAPY:
                    case vMRClsDef.EnumInferenceResultType.SELFMONITOR:
                    case vMRClsDef.EnumInferenceResultType.MSEVALUATION:
                        return "Entrance.clp";
                    case vMRClsDef.EnumInferenceResultType.DIETARY:
                        return "MS_DietDataJudge.clp";
                    case vMRClsDef.EnumInferenceResultType.PHYSICALACTIVITY:
                        return "MS_SportDataJudge.clp";
                    case vMRClsDef.EnumInferenceResultType.RISKEVALUATION:
                        return "MS_MSRiskDegreeEvaluation.clp";
                    default:
                        return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }

        }

        /// <summary>
        /// Clips推理接口调用
        /// </summary>
        /// <param name="strRuleLevel"></param>
        /// <param name="lstDataModelForIE"></param>
        /// <param name="lstNewFact"></param>
        /// <param name="oTriggeringEvent"></param>
        /// <returns></returns>
        public bool DoInference(string strRuleLevel, List<vMRClsDef.DataModel> lstDataModelForIE,
            ref List<vMRClsDef.DataModel> lstNewFact, vMRClsDef.TriggeringEvent oTriggeringEvent)
        {
            bool bRet = true;
            string strRuleEntrance = ObtainRuleEntrance(strRuleLevel, oTriggeringEvent);
            UserDefinedFun();
            m_oRuleEngine.Watch("all");
            //////////////////////////////////////////////////////////////////////////
            string strfilepath = AppDomain.CurrentDomain.BaseDirectory + ClipsConfig.ReadConfig("Filepath");

            //////////////////////////////////////////////////////////////////////////
            m_oRuleEngine.Load(strfilepath + strRuleEntrance); //load rule
            m_oRuleEngine.Load(strfilepath + "function.clp"); //load deffunction
            DataObject d = m_oRuleEngine.CreateDataObject();
            OperateFact("filepath", "\"" + strfilepath.Replace("\\", "\\\\") + "\"");//load fact filepath

            //load fact of data
            foreach (vMRClsDef.DataModel oDataModel in lstDataModelForIE)
            {
                OperateFact(oDataModel.strDataName, oDataModel.strDataValue);
            }

            //bool bDribbleOn = m_oRuleEngine.DribbleOn("..\\Rule\\out.txt");
            string strIEProcessName = 
                System.DateTime.Now.ToString("yyyyMMddHHmmss") + "_" 
                + oTriggeringEvent.oEvent.strEventName;
            //////////////////////////////////////////////////////////////////////////
            string strLogPath = AppDomain.CurrentDomain.BaseDirectory + ClipsConfig.ReadConfig("LogPath");
            string strLogFlag = AppDomain.CurrentDomain.BaseDirectory + ClipsConfig.ReadConfig("LogFlag");
            //////////////////////////////////////////////////////////////////////////
            string strIELogDirectory = strLogPath + "IELog\\";

            //如果日志文件目录不存在，则创建该目录
            if (Directory.Exists(strIELogDirectory) == false)
            {
                Directory.CreateDirectory(strIELogDirectory);
            }
            strIELogDirectory = strIELogDirectory + strIEProcessName + ".txt";
            if (strLogFlag == "1")
            {
                bool bDribbleOn = m_oRuleEngine.DribbleOn(strIELogDirectory);
            }

            int nRunRet = m_oRuleEngine.Run(-1);
            m_oRuleEngine.DribbleOff();
            GetNewAddFact(ref lstNewFact);

            return bRet;
        }

        /// <summary>
        /// 获取clips推理过程中新生成的facts
        /// </summary>
        /// <param name="lstNewFact"></param>
        private void GetNewAddFact(ref  List<vMRClsDef.DataModel> lstNewFact)
        {
            for (int i = 0; i < lstNewFact.Count; i++)
            {
                vMRClsDef.DataModel oDataModel = new vMRClsDef.DataModel();
                oDataModel = lstNewFact[i];
                if (HTFactInfo.Contains(oDataModel.strDataName) == true)
                {
                    FactInfo fi = (FactInfo)HTFactInfo[oDataModel.strDataName];
                    lstNewFact[i].strDataValue = fi.FactValue;
                }
            }

        }

        //public bool ConInference(List<string> strNextRuleFileList, List<vMRClsDef.DataModel> oDataModelList)
        //{
        //    //must clear the result at first
        //    m_stInferResult.Init();

        //    bool bRet = true;

        //    /************************
        //    //Remarked by yy，200712220
        //    //if it is not by webservice,there is no need to define these functions again because of these functions is still existed.
        //    //UserDefinedFun();
        //    ***********************/

        //    m_oRuleEngine.Watch("all");

        //    for (int i = 0; i < strNextRuleFileList.Count; i++)
        //    {
        //        if (strNextRuleFileList[i] != string.Empty)
        //        {
        //            m_oRuleEngine.Load(strNextRuleFileList[i]); //load rule
        //        }
        //    }

        //    //load fact of data

        //    /****************************
        //    ////Remarked by yy，20080111
        //    ////if it is not by webservice,there is no need to load the fact existed before the interaction.
        //    //this.FactIndexMax = -1;
        //    //HTFactInfo.Clear();
        //    ////交互前引擎中已存在的事实
        //    //foreach (System.Collections.DictionaryEntry f in HTFactInfo)
        //    //{
        //    //    FactInfo fi =(FactInfo)f.Value;
        //    //    OperateFact(f.Key.ToString(), fi.FactValue);
        //    //}
        //    ****************************/

        //    //交互中新添的事实
        //    foreach (CDataModel oDataModel in oDataModelList)
        //    {
        //        OperateFact(oDataModel.DataName, oDataModel.DataValue);
        //    }

        //    //TODO: DribbleFile to be Dubug
        //    bool bDribbleOn = m_oRuleEngine.DribbleOn(ConfigurationManager.AppSettings["OUT_PATH"]);
        //    int nRunRet = m_oRuleEngine.Run(-1);
        //    m_oRuleEngine.DribbleOff();

        //    return bRet;

        //}

        private void OperateFact(string strName, string strValue)
        {
            if (HTFactInfo.Contains(strName) == false)
            {
                //该事实尚未存在
                string strFact = string.Format("({0} {1})", strName, strValue);
                bool b = m_oRuleEngine.LoadFactsFromString(strFact, -1);
                if (b == true)
                {
                    //同时需要更新最大事实索引地址，将事实信息添加到hashtable中。
                    FactIndexMax++;
                    HTFactInfo.Add(strName, new FactInfo(strValue, FactIndexMax, EnumFactChangeFlag.Add));
                }
            }
            else
            {   //已有该事实存在
                FactInfo fi = (FactInfo)HTFactInfo[strName];
                if (fi.FactValue != strValue)
                {   //事实的值有更新
                    //由于没有modify命令可用，所以先撤销事实，再添加事实，因此事实索引地址也被更新
                    string strRetractFact = string.Format("(retract {0})", fi.FactIndex);
                    DataObject d = m_oRuleEngine.CreateDataObject();
                    m_oRuleEngine.Eval(strRetractFact, d);
                    string strFact = string.Format("({0} {1})", strName, strValue);
                    bool b = m_oRuleEngine.LoadFactsFromString(strFact, -1);
                    if (b == true)
                    {
                        //同时需要更新最大事实索引地址，更新hashtable信息。
                        FactIndexMax++;
                        HTFactInfo[strName] = new FactInfo(strValue, FactIndexMax, EnumFactChangeFlag.Modified);
                    }
                }
            }
        }

        private void UserDefinedFun()
        {
            bool retRecommendation = m_oRuleEngine.UserFunctionManager.DefineFunction("Recommendation", new UserDefFun.DynamicFunctionCall(Recommendation));
            bool retDataNotify = m_oRuleEngine.UserFunctionManager.DefineFunction("DataNotify", new UserDefFun.DynamicFunctionCall(DataNotify));
            bool retPromptChoice = m_oRuleEngine.UserFunctionManager.DefineFunction("PromptChoice", new UserDefFun.DynamicFunctionCall(PromptChoice));
            bool retFileLoadNotify = m_oRuleEngine.UserFunctionManager.DefineFunction("FileLoadNotify", new UserDefFun.DynamicFunctionCall(FileLoadNotify));
            bool retOperateFact = m_oRuleEngine.UserFunctionManager.DefineFunction("OperateFact", new UserDefFun.DynamicFunctionCall(OperateFact));
            bool retInterpretationIndex = m_oRuleEngine.UserFunctionManager.DefineFunction("InterpretationIndex", new UserDefFun.DynamicFunctionCall(InterpretationIndex));
            bool retFactUsed = m_oRuleEngine.UserFunctionManager.DefineFunction("FactUsed", new UserDefFun.DynamicFunctionCall(FactUsed));
            bool retPreDiagnose = m_oRuleEngine.UserFunctionManager.DefineFunction("PreDiagnose", new UserDefFun.DynamicFunctionCall(PreDiagnose));
            bool retOperateNumberFact = m_oRuleEngine.UserFunctionManager.DefineFunction("OperateNumberFact", new UserDefFun.DynamicFunctionCall(OperateNumberFact));
        }

        #region user-defined functions

        public void OperateFact(RuleEngine env, ProAi.Clips.DataObject obj)
        {
            //规则中回调函数的参数说明：

            //RtnString(1):事实名
            //RtnString(2):事实值

            OperateFact(env.UserFunctionManager.RtnString(1), env.UserFunctionManager.RtnString(2).ToString());
        }

        public void OperateNumberFact(RuleEngine env, ProAi.Clips.DataObject obj)
        {
            OperateFact(env.UserFunctionManager.RtnString(1), env.UserFunctionManager.RtnDouble(2).ToString());
        }

        public void Recommendation(RuleEngine env, ProAi.Clips.DataObject obj)
        {
            m_stInferResult.Recommendations.Add(env.UserFunctionManager.RtnString(1));
            //m_stInferResult.lstInInterpretation[m_stInferResult.lstInInterpretation.Count - 1].lstRecomm.Add(env.UserFunctionManager.RtnString(1));
        }

        public void DataNotify(RuleEngine env, ProAi.Clips.DataObject obj)
        {
            String[] strData = env.UserFunctionManager.RtnString(1).Split('+');
            for (int i = 0; i < strData.Length; i++)
            {
                string strDatum = strData.GetValue(i).ToString();
                if (strDatum != "NULL" && !m_stInferResult.DataNotice.Data.Contains(strDatum))
                {
                    m_stInferResult.DataNotice.Data.Add(strDatum);
                }
            }
        }

        public void FileLoadNotify(RuleEngine env, ProAi.Clips.DataObject obj)
        {
            switch (env.UserFunctionManager.RtnString(2))
            {
                case "DataNotify":
                    m_stInferResult.DataNotice.CurrentRuleFile = env.UserFunctionManager.RtnString(1);
                    break;

                case "PromptChoice":
                    m_stInferResult.InterChoices.NextRuleFiles.Add(env.UserFunctionManager.RtnString(1));
                    break;
            }
        }

        public void PromptChoice(RuleEngine env, ProAi.Clips.DataObject obj)
        {
            //规则中回调函数的参数说明：

            //RtnString(1):QuestionContent 问题详细内容，提示用户的信息
            //RtnString(2):QuestionContent 问题简要内容，提示用户的信息
            //RtnString(3):QuestionFactName问题，在规则中用到的事实的名称

            //RtnString(4):Choice1  可选项1，提示用户的信息
            //RtnString(5):AllowedValue1 可选项1，在规则中用到的值

            //RtnString(6):Choice2
            //RtnString(7):AllowedValue2

            //......

            //RtnString(2N+2):ChoiceN
            //RtnString(2N+3):AllowedValueN
            QuestionChoices stQC = new QuestionChoices();
            stQC.Question = new CodeFull(env.UserFunctionManager.RtnString(1), env.UserFunctionManager.RtnString(2), env.UserFunctionManager.RtnString(3));

            stQC.Choices = new List<CodeSimple>();
            int nStart = 4;//参数从第4个开始为choice,每2个为一组
            for (int i = nStart; i < env.UserFunctionManager.ArgCount; i = i + 2)
            {
                stQC.Choices.Add(new CodeSimple(env.UserFunctionManager.RtnString(i), env.UserFunctionManager.RtnString(i + 1)));
            }

            m_stInferResult.InterChoices.Questions.Add(stQC);
        }

        public void FactUsed(RuleEngine env, ProAi.Clips.DataObject obj)
        {
            for (int i = 1; i <= env.UserFunctionManager.ArgCount; i++)
            {
                m_stInferResult.lstInInterpretation[m_stInferResult.lstInInterpretation.Count - 1].lstFactUsed.Add(env.UserFunctionManager.RtnString(i));
            }
        }

        public void InterpretationIndex(RuleEngine env, ProAi.Clips.DataObject obj)
        {
            Interpretation oInterpret = new Interpretation(env.UserFunctionManager.RtnString(1));
            m_stInferResult.lstInInterpretation.Add(oInterpret);
        }

        public void PreDiagnose(RuleEngine env, ProAi.Clips.DataObject obj)
        {
            string strDiseaseName = env.UserFunctionManager.RtnString(1);
            string strCriterion = env.UserFunctionManager.RtnString(2);

            for (int i = 0; i < m_stInferResult.lstPreDiagnose.Count; i++)
            {
                //如果已经拟诊此疾病，则添加到诊断依据中
                if (m_stInferResult.lstPreDiagnose[i].strDisease == strDiseaseName)
                {
                    m_stInferResult.lstPreDiagnose[i].lstCriterion.Add(strCriterion);
                    return;
                }
            }

            //如果是新拟诊，则创建新的结构体，添加到推理结果中。
            DiseaseCriterion oDC = new DiseaseCriterion();
            oDC.strDisease = strDiseaseName;
            oDC.lstCriterion = new List<string>();
            oDC.lstCriterion.Add(strCriterion);
            m_stInferResult.lstPreDiagnose.Add(oDC);
        }

        #endregion

    }
}
