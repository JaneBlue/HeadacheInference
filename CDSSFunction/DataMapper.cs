using System;
using System.Collections.Generic;
using System.Text;
using CDSSvMRDataDef;
using CDSSSystemData;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.IO;
using System.Xml;
using System.Configuration;


namespace CDSSFunction
{
    class DataMapper
    {
        /// <summary>
        /// DataModel code与SystemData映射，并对oIEvMRInput进行赋值
        /// </summary>
        /// <param name="oIEvMRInput"></param>
        /// <returns></returns>
        public static bool MapDataToFact(ref vMRClsDef.IEvMRInput oIEvMRInput)
        {
            //TODO 数据映射具体实现
            for(int i = 0; i < oIEvMRInput.lstInputDataModel.Count; i++)
            {
                for(int j = 0; j < oIEvMRInput.lstInputDataModel[i].lstDataModel.Count; j++)
                {
                    string strStandDataCode
                        = oIEvMRInput.lstInputDataModel[i].lstDataModel[j].strDataCode;

                    //string strClassName 
                    //    = MappingToClassFromXml.ObtainClassNameWithDataCode(strStandDataCode);
                    //if (strClassName != string.Empty)
                    //{
                    //    object objClassDataValue = DynamicMapperToSystemData.GetMapperValue(strClassName);
                    //    if (objClassDataValue != null)
                    //    {
                    //        oIEvMRInput.lstInputDataModel[i].lstDataModel[j].strDataValue
                    //            = objClassDataValue.ToString();
                    //    }
                    //    else
                    //    {
                    //        oIEvMRInput.lstInputDataModel[i].lstDataModel[j].strDataValue
                    //        = "NULL";
                    //    }

                    //}
                    //else
                    //{
                    //    oIEvMRInput.lstInputDataModel[i].lstDataModel[j].strDataValue = "NULL";
                    //}

                    oIEvMRInput.lstInputDataModel[i].lstDataModel[j].strDataValue
                    = TempDataMap.ObtainDataValueWithDataCode(strStandDataCode);
                }
            }
            
            return true;
        }

        public static void MapIEOutputToUI(vMRClsDef.IEvMRInput oIEvMRInput, vMRClsDef.IEvMROutput oIEvMROutput)
        {
            //TODO IE输出结果映射，供界面显示
            foreach(vMRClsDef.OutputInfo oOutputInfo in oIEvMROutput.lstOutputInfo)
            {
                int i;
                for ( i = 0; i < oIEvMRInput.lstInputDataModel.Count; i++)
                {
                    if(oOutputInfo.oTriggeringEvent.oEvent.strEventCNName 
                        == oIEvMRInput.lstInputDataModel[i].oTriggeringEvent.oEvent.strEventCNName)
                    {
                        break;
                    }
                }
                FormatResult(oIEvMRInput.lstInputDataModel[i], oOutputInfo);
            }
        }

        public static void FormatResult(vMRClsDef.InputDataModel oIEInputDataModel, vMRClsDef.OutputInfo oOutputInfo)
        {
            switch (oOutputInfo.oTriggeringEvent.m_emInferenceResultType)
            {
                case vMRClsDef.EnumInferenceResultType.DIAGNOSIS:
                    FormatDiagnosiResult(oIEInputDataModel, oOutputInfo);
                    //FormatExplanation(oIEInputDataModel, oOutputInfo);
                    break;
                //case vMRClsDef.EnumInferenceResultType.MSEVALUATION:
                //    FormatMSEvaluationResult(oOutputInfo);
                //    break;
                //case vMRClsDef.EnumInferenceResultType.THERAPY:
                //    FormatTherpayResult(oIEInputDataModel, oOutputInfo);
                //    break;
                //case vMRClsDef.EnumInferenceResultType.SELFMONITOR:
                //    FormatSelfMonitorResult(oIEInputDataModel, oOutputInfo);
                //    break;
                //case vMRClsDef.EnumInferenceResultType.RISKEVALUATION:
                //    FormatMSRiskEvaluationResult(oOutputInfo);
                //    break;
                //case vMRClsDef.EnumInferenceResultType.DIETARY:
                //    FormatDietary(oIEInputDataModel, oOutputInfo);
                //    break;
                //case vMRClsDef.EnumInferenceResultType.PHYSICALACTIVITY:
                //    FormatPhysicalActivity(oIEInputDataModel, oOutputInfo);
                //    break;
                default:
                    break;
            }
        }

        public static void FormatDiagnosiResult(vMRClsDef.InputDataModel oIEInputDataModel, vMRClsDef.OutputInfo oOutputInfo)
        {
            int iResultIndex = DiseaseInfoExisted(oOutputInfo);

            string result = string.Empty;
            string tmpresult = string.Empty;
            for (int i = 0; i < oOutputInfo.oInference.lstStructedInferMessage.Count; i++)
            {
                tmpresult = oOutputInfo.oInference.lstStructedInferMessage[i].strDataValue;

                if (tmpresult != "")
                    result = result + MapStructedInfoToCN(tmpresult) + " ";
            }
            GlobalData.DiagnosedResult.DiseaseDiagnosedResultList[iResultIndex].Result = result;
            FormatShortDataInfo(oIEInputDataModel, oOutputInfo, ref GlobalData.DiagnosedResult.DiseaseDiagnosedResultList[iResultIndex].DataNeeded);
        }

        public static int DiseaseInfoExisted(vMRClsDef.OutputInfo oOutputInfo)
        {
            for (int i = 0; i < GlobalData.DiagnosedResult.DiseaseDiagnosedResultList.Count; i++)
            {
                if (GlobalData.DiagnosedResult.DiseaseDiagnosedResultList[i].Name == oOutputInfo.oTriggeringEvent.oDisease.strDiseaseCNName)
                {
                    return i;
                }
            }

            CDSSOneDiseaseDiagnosedResult oOneDiseaseDiagnosedResult = new CDSSOneDiseaseDiagnosedResult();
            oOneDiseaseDiagnosedResult.Name = oOutputInfo.oTriggeringEvent.oDisease.strDiseaseCNName;
            GlobalData.DiagnosedResult.DiseaseDiagnosedResultList.Add(oOneDiseaseDiagnosedResult);

            return GlobalData.DiagnosedResult.DiseaseDiagnosedResultList.Count - 1;
        }

        public static string MapStructedInfoToCN(string Result)
        {
            switch (Result)
            {
                case "Migraine_Without_Aura":
                    return "无先兆性偏头痛";
                case "Migraine_With_Aura":
                    return "先兆性偏头痛";
                case "Chronic_Migraine":
                    return "慢性偏头痛";
                case "Probable_Migraine":
                    return "很可能的偏头痛";
                case "Status_Migrainosus":
                    return "偏头痛持续状态";
                case "Retinal_Migraine":
                    return "视网膜性偏头痛";

        
                 case "Infrequent_Episodic_Tension-type_Headache":
                    return "偶尔发作性紧张型头痛";
                 case "Frequent_Episodic_Tension-type_Headache":
                    return "频繁阵发性紧张型头痛";
                case "Chronic_Tension-type_Headache":
                    return "慢性紧张型头痛";
                case "Probable_Tension_Type_Headache":
                    return "很可能的紧张型头痛";


                case"Cluster_Headache_and_Other_Trigeminal_Autonomic_Cephalalgias":
                    return "丛集性头痛和其他原发性三叉神经痛";
                case "Cluster_Headache":
                    return "丛集性头痛";
                case "Paroxysmal_Hemicrania":
                    return "阵发性偏侧头痛";
                case "SUNCT":
                    return "SUNCT";
                case "Probable_SUNCT":
                    return "很可能的SUNCT";
                case "Probable_Cluster_Headache":
                    return "很可能的丛集性头痛";
                case "Probable_Paroxysmal_Hemicrania":
                    return "很可能的阵发性偏侧头痛";


                case"New_Daily_Persistent_Headache":
                    return "新发每日持续性头痛";
                case "Other_Primary_Headaches":
                    return "其他原发性头痛";


                case "Other_Chronic_Daily_Headache":
                    return "其他慢性每日头痛";

                case "Medication-overuse_Headache":
                    return "药物滥用引起的头痛";

                case "Cranial_Neuralgias_and_Central_Causes_of_Facial_Pain":
                    return "颅神经痛和中枢源性面痛";

                case "Other_Headache":
                    return "其他类型的头痛";
                default:
                    return "";
            }
        }        

        public static void FormatShortDataInfo(vMRClsDef.InputDataModel oIEInputDataModel, vMRClsDef.OutputInfo oOutputInfo, ref string strExistShortData)
        {
            //string strShortData = string.Empty;
            for(int i = 0; i < oOutputInfo.lstShortDataModel.Count; i++)
            {
                string strDataName = oOutputInfo.lstShortDataModel[i].strDataName;
                foreach(vMRClsDef.DataModel oDataModel in oIEInputDataModel.lstDataModel)
                {
                    //BugDB00005686 revised by wbf 2009-03-26
                    if(oDataModel.strDataName == strDataName)
                    {
                        if (!strExistShortData.Contains(oDataModel.strDataCNName))
                        {
                            strExistShortData += oDataModel.strDataCNName + " ";
                        }
                    }
                }
            }
        }

        public static vMRClsDef.EnumInferenceType MapInferTypeFuntionDeftovMR(
            FunctionTypeDef.EnumInferenceType em_InferenceType)
        {
            switch(em_InferenceType)
            {
                case FunctionTypeDef.EnumInferenceType.PRIMARY:
                    return vMRClsDef.EnumInferenceType.PRIMARY;
                case FunctionTypeDef.EnumInferenceType.NEEDSECONDTIME:
                    return vMRClsDef.EnumInferenceType.NEEDSECONDTIME;
                case FunctionTypeDef.EnumInferenceType.SECONDTIME:
                    return vMRClsDef.EnumInferenceType.SECONDTIME;
                default:
                    return vMRClsDef.EnumInferenceType.PRIMARY;
            }
        }

        public static vMRClsDef.EnumInferenceResultType MapInferResultTypeFuntiontovMR(
            FunctionTypeDef.EnumInferenceResultType em_InferResultType)
        {
            switch(em_InferResultType)
            {
                case FunctionTypeDef.EnumInferenceResultType.DIAGNOSIS:
                    return vMRClsDef.EnumInferenceResultType.DIAGNOSIS;
                case FunctionTypeDef.EnumInferenceResultType.THERAPY:
                    return vMRClsDef.EnumInferenceResultType.THERAPY;
                case FunctionTypeDef.EnumInferenceResultType.SELFMONITOR:
                    return vMRClsDef.EnumInferenceResultType.SELFMONITOR;
                case FunctionTypeDef.EnumInferenceResultType.MSEVALUATION:
                    return vMRClsDef.EnumInferenceResultType.MSEVALUATION;
                case FunctionTypeDef.EnumInferenceResultType.RISKEVALUATION:
                    return vMRClsDef.EnumInferenceResultType.RISKEVALUATION;
                case FunctionTypeDef.EnumInferenceResultType.ADVERSEEVENT:
                    return vMRClsDef.EnumInferenceResultType.ADVERSEEVENT;
                case FunctionTypeDef.EnumInferenceResultType.DIETARY:
                    return vMRClsDef.EnumInferenceResultType.DIETARY;
                case FunctionTypeDef.EnumInferenceResultType.PHYSICALACTIVITY:
                    return vMRClsDef.EnumInferenceResultType.PHYSICALACTIVITY;
                case FunctionTypeDef.EnumInferenceResultType.OTHER:
                    return vMRClsDef.EnumInferenceResultType.OTHER;
                default:
                    return vMRClsDef.EnumInferenceResultType.OTHER;
            }
        }

        public static FunctionTypeDef.EnumInferenceResultType MapInferResultTypevMRtoFunction(
            vMRClsDef.EnumInferenceResultType em_vMRInferResult)
        {
            switch(em_vMRInferResult)
            {
                case vMRClsDef.EnumInferenceResultType.DIAGNOSIS:
                    return FunctionTypeDef.EnumInferenceResultType.DIAGNOSIS;
                case vMRClsDef.EnumInferenceResultType.THERAPY:
                    return FunctionTypeDef.EnumInferenceResultType.THERAPY;
                case vMRClsDef.EnumInferenceResultType.SELFMONITOR:
                    return FunctionTypeDef.EnumInferenceResultType.SELFMONITOR;
                case vMRClsDef.EnumInferenceResultType.MSEVALUATION:
                    return FunctionTypeDef.EnumInferenceResultType.MSEVALUATION;
                case vMRClsDef.EnumInferenceResultType.RISKEVALUATION:
                    return FunctionTypeDef.EnumInferenceResultType.RISKEVALUATION;
                case vMRClsDef.EnumInferenceResultType.DIETARY:
                    return FunctionTypeDef.EnumInferenceResultType.DIETARY;
                case vMRClsDef.EnumInferenceResultType.PHYSICALACTIVITY:
                    return FunctionTypeDef.EnumInferenceResultType.PHYSICALACTIVITY;
                default:
                    return FunctionTypeDef.EnumInferenceResultType.OTHER;
             }

        }
    }


    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public class DynamicMapperToSystemData
    {
        public const string CONST_IMPORT_CDSS_SYSTEM_DATA_DLL = "CDSSSystemData.dll";
        public const string CONST_IMPORT_CDSS_SYSTEM_DATA_NAMESPACE = "CDSSSystemData";
        public const string CONST_IMPORT_SYSTEM_DLL = "System.dll";
        public const string CONST_IMPORT_SYSTEM_NAMESPACE = "System";
        public const string CONST_GENERATECODE_DLL = "ObtainSystemData.dll";
        public const string CONST_GENERATECODE_NAMESPACE = "CDSSDynamicCode";
        public const string CONST_GENERATECODE_CLASSNAME = "ObtainSystemData";
        public const string CONST_GENERATECODE_METHODNAME_OBTAIN_SYSTEM_DATA
            = "GetDataValue";

        /// <summary>
        /// 根据映射的类名获取CDSSSystemData.GlobalData中成员数据
        /// 返回值类型不定，由CDSSSystemData.GlobalData中成员数据类型决定
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object GetMapperValue(string strClassName)
        {
            CodeSnippetCompileUnit unit = ConstructAndCompileCode(strClassName);

            ICodeCompiler compiler = new CSharpCodeProvider().CreateCompiler();
            CompilerParameters para = new CompilerParameters();
            para.ReferencedAssemblies.Add(CONST_IMPORT_SYSTEM_DLL);
            para.ReferencedAssemblies.Add(CONST_IMPORT_CDSS_SYSTEM_DATA_DLL);
            para.GenerateInMemory = true;
            para.GenerateExecutable = false;

            CompilerResults cr = compiler.CompileAssemblyFromDom(para, unit);

            if (cr.Errors.Count > 0)
            {
                string str = "编译文件出错： " + cr.PathToAssembly + ": \r\n";
                foreach (CompilerError ce in cr.Errors)
                    str = ce.ToString();
                return false;
            }
            else
            {
                Assembly asm = cr.CompiledAssembly;
                Type type = asm.GetType(
                    CONST_GENERATECODE_NAMESPACE + "." + CONST_GENERATECODE_CLASSNAME);
                MethodInfo mi = type.GetMethod(
                    CONST_GENERATECODE_METHODNAME_OBTAIN_SYSTEM_DATA, BindingFlags.Public | BindingFlags.Instance);
                object obj = asm.CreateInstance(
                    CONST_GENERATECODE_NAMESPACE + "." + CONST_GENERATECODE_CLASSNAME);
                return mi.Invoke(obj, null);
            }

        }

        /// <summary>
        /// 构建获取CDSSSystemData GlobalData中数据的动态code,并编译运行
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static CodeSnippetCompileUnit ConstructAndCompileCode(string value)
        {
            CodeNamespace CurrentNameSpace
                = InitializeNameSpace(CONST_GENERATECODE_NAMESPACE);
            CodeTypeDeclaration ctd = CreateClass(CONST_GENERATECODE_CLASSNAME);
            CurrentNameSpace.Types.Add(ctd);
            CodeMemberMethod mtd = CreateMethod(
                CONST_GENERATECODE_METHODNAME_OBTAIN_SYSTEM_DATA);
            ctd.Members.Add(mtd);

            mtd.Statements.Add(new CodeSnippetExpression("return" + "\n" + value));

            CSharpCodeProvider provider = new CSharpCodeProvider();
            ICodeGenerator codeGen = provider.CreateGenerator();
            string codeSnippet = GenerateCode(codeGen, CurrentNameSpace);

            CodeSnippetCompileUnit unit = new CodeSnippetCompileUnit(codeSnippet);
            return unit;
        }

        /// <summary>
        /// 初始化动态code的NameSpace
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private static CodeNamespace InitializeNameSpace(string Name)
        {
            CodeNamespace CurrentNameSpace = new CodeNamespace(Name);
            CurrentNameSpace.Imports.Add(
                new CodeNamespaceImport(CONST_IMPORT_SYSTEM_NAMESPACE));
            CurrentNameSpace.Imports.Add(
                new CodeNamespaceImport(CONST_IMPORT_CDSS_SYSTEM_DATA_NAMESPACE));
            return CurrentNameSpace;
        }

        /// <summary>
        /// 创建类
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private static CodeTypeDeclaration CreateClass(string Name)
        {
            CodeTypeDeclaration ctd = new CodeTypeDeclaration(Name);
            ctd.IsClass = true;
            ctd.Attributes = MemberAttributes.Public;
            return ctd;
        }

        /// <summary>
        /// 创建方法
        /// </summary>
        /// <param name="strMethodName"></param>
        /// <returns></returns>
        private static CodeMemberMethod CreateMethod(string strMethodName)
        {
            CodeMemberMethod method = new CodeMemberMethod();
            method.Name = strMethodName;
            method.Attributes = MemberAttributes.Public;
            method.ReturnType = new CodeTypeReference("System.Object");
            return method;
        }

        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="CodeGenerator"></param>
        /// <param name="CurrentNameSpace"></param>
        /// <returns></returns>
        private static string GenerateCode(ICodeGenerator CodeGenerator,
            CodeNamespace CurrentNameSpace)
        {
            // CodeGeneratorOptions允许我们指定各种供代码生成器 
            // 使用的格式化选项 
            CodeGeneratorOptions cop = new CodeGeneratorOptions();
            // 指定格式：花括号的位置 
            cop.BracingStyle = "C";
            // 指定格式：代码块的缩进方式 
            cop.IndentString = " ";
            StringBuilder sbCode = new StringBuilder();
            StringWriter sw = new StringWriter(sbCode);
            CodeGenerator.GenerateCodeFromNamespace(CurrentNameSpace, sw, cop);
            return sbCode.ToString();
        }
    }   

    public class MappingToClassFromXml
    {
        private static XmlDocument m_xmldoc;
        private static XmlNamespaceManager m_xmlManager;

        public static void OpenXmlDoc(string strFileName)
        {
            m_xmldoc = new XmlDocument();
            m_xmldoc.Load(strFileName);
            m_xmlManager = new XmlNamespaceManager(m_xmldoc.NameTable);
        }

        //查询名为Element_Node的所有节点
        private static XmlNodeList FindMulInstance()
        {
            string strNodePath;     //被查询实例的路径	
            XmlNodeList nlInstance = null;    //所有instance的列表
            strNodePath = string.Format(
                "/{0}/{1}", "Mapping", "DataMapper");		//xpath

            nlInstance = m_xmldoc.SelectNodes(strNodePath);
            return nlInstance;
        }

        public static string ObtainClassNameWithDataCode(string strDataCode)
        {
            OpenXmlDoc(ConfigurationSettings.AppSettings["DATAMAPPING_FILEPATH"]);
            XmlNodeList nl_DataMapper = FindMulInstance();
            foreach (XmlNode n_DataMapper in nl_DataMapper)
            {
                XmlNode n_StandardData
                    = n_DataMapper.SelectSingleNode("StdData");
                string strStandDataCode 
                    = n_StandardData.SelectSingleNode("StdDataCode").InnerText;
                if (strStandDataCode == strDataCode)
                {
                    XmlNode n_Class = n_DataMapper.SelectSingleNode("Class");
                    return n_Class.SelectSingleNode("ClsName").InnerText;
                }
            }
            return string.Empty;
        }
    }
}
