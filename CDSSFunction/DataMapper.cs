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
        /// DataModel code��SystemDataӳ�䣬����oIEvMRInput���и�ֵ
        /// </summary>
        /// <param name="oIEvMRInput"></param>
        /// <returns></returns>
        public static bool MapDataToFact(ref vMRClsDef.IEvMRInput oIEvMRInput)
        {
            //TODO ����ӳ�����ʵ��
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
            //TODO IE������ӳ�䣬��������ʾ
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
                    return "��������ƫͷʹ";
                case "Migraine_With_Aura":
                    return "������ƫͷʹ";
                case "Chronic_Migraine":
                    return "����ƫͷʹ";
                case "Probable_Migraine":
                    return "�ܿ��ܵ�ƫͷʹ";
                case "Status_Migrainosus":
                    return "ƫͷʹ����״̬";
                case "Retinal_Migraine":
                    return "����Ĥ��ƫͷʹ";

        
                 case "Infrequent_Episodic_Tension-type_Headache":
                    return "ż�������Խ�����ͷʹ";
                 case "Frequent_Episodic_Tension-type_Headache":
                    return "Ƶ�����Խ�����ͷʹ";
                case "Chronic_Tension-type_Headache":
                    return "���Խ�����ͷʹ";
                case "Probable_Tension_Type_Headache":
                    return "�ܿ��ܵĽ�����ͷʹ";


                case"Cluster_Headache_and_Other_Trigeminal_Autonomic_Cephalalgias":
                    return "�Լ���ͷʹ������ԭ����������ʹ";
                case "Cluster_Headache":
                    return "�Լ���ͷʹ";
                case "Paroxysmal_Hemicrania":
                    return "����ƫ��ͷʹ";
                case "SUNCT":
                    return "SUNCT";
                case "Probable_SUNCT":
                    return "�ܿ��ܵ�SUNCT";
                case "Probable_Cluster_Headache":
                    return "�ܿ��ܵĴԼ���ͷʹ";
                case "Probable_Paroxysmal_Hemicrania":
                    return "�ܿ��ܵ�����ƫ��ͷʹ";


                case"New_Daily_Persistent_Headache":
                    return "�·�ÿ�ճ�����ͷʹ";
                case "Other_Primary_Headaches":
                    return "����ԭ����ͷʹ";


                case "Other_Chronic_Daily_Headache":
                    return "��������ÿ��ͷʹ";

                case "Medication-overuse_Headache":
                    return "ҩ�����������ͷʹ";

                case "Cranial_Neuralgias_and_Central_Causes_of_Facial_Pain":
                    return "­��ʹ������Դ����ʹ";

                case "Other_Headache":
                    return "�������͵�ͷʹ";
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
        /// ����ӳ���������ȡCDSSSystemData.GlobalData�г�Ա����
        /// ����ֵ���Ͳ�������CDSSSystemData.GlobalData�г�Ա�������;���
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
                string str = "�����ļ����� " + cr.PathToAssembly + ": \r\n";
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
        /// ������ȡCDSSSystemData GlobalData�����ݵĶ�̬code,����������
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
        /// ��ʼ����̬code��NameSpace
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
        /// ������
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
        /// ��������
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
        /// ���ɴ���
        /// </summary>
        /// <param name="CodeGenerator"></param>
        /// <param name="CurrentNameSpace"></param>
        /// <returns></returns>
        private static string GenerateCode(ICodeGenerator CodeGenerator,
            CodeNamespace CurrentNameSpace)
        {
            // CodeGeneratorOptions��������ָ�����ֹ����������� 
            // ʹ�õĸ�ʽ��ѡ�� 
            CodeGeneratorOptions cop = new CodeGeneratorOptions();
            // ָ����ʽ�������ŵ�λ�� 
            cop.BracingStyle = "C";
            // ָ����ʽ��������������ʽ 
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

        //��ѯ��ΪElement_Node�����нڵ�
        private static XmlNodeList FindMulInstance()
        {
            string strNodePath;     //����ѯʵ����·��	
            XmlNodeList nlInstance = null;    //����instance���б�
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
