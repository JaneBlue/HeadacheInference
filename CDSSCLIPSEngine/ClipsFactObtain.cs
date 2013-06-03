using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using CDSSvMRDataDef;

namespace CDSSCLIPSEngine
{
    public class ClipsFactObtain
    {
        private static XmlDocument m_xmldoc;
        private static XmlNamespaceManager m_xmlManager;
        public static List<vMRClsDef.TriggeringEvent> lstTriggeringEvents = new List<vMRClsDef.TriggeringEvent>();

        public static void OpenXmlDoc(string strFileName)
        {
            m_xmldoc = new XmlDocument();
            m_xmldoc.Load(strFileName);
            m_xmlManager = new XmlNamespaceManager(m_xmldoc.NameTable);
            m_xmlManager.AddNamespace("x", "http://www.vico-lab.com.cn");    //"x"Ϊxml�ļ���namespace,namespace������Ϊ�������
        }

        //��ѯ��ΪElement_Node�����нڵ�
        private static XmlNodeList FindMulInstance(string Element_Node)
        {
            string strNodePath;     //����ѯʵ����·��	
            XmlNodeList nlInstance = null;    //����instance���б�
            strNodePath = string.Format(
                "/x:{0}/x:{1}/x:{2}", "Relationship", "EDR",
                Element_Node);		//xpath

            nlInstance = m_xmldoc.SelectNodes(strNodePath, m_xmlManager);
            return nlInstance;
        }

        private static void ObtainDataModel(string strFilePath, string strFileName, ref vMRClsDef.InputDataModel oInputDataModel)
        {
            //string strFilePath = ClipsConfig.ReadConfig("Filepath");
            OpenXmlDoc(strFilePath + strFileName);
            string strEvent = oInputDataModel.oTriggeringEvent.oEvent.strEventName;

            XmlNodeList nl_DataModel = null;
            XmlNodeList nl_Event = FindMulInstance("EventModel");//���ҳ�xml�ļ������еĴ����¼��ڵ�

            foreach (XmlNode n_Event in nl_Event)
            {
                //�õ��¼�����
                string strEventENName = n_Event.SelectSingleNode("x:ENName", m_xmlManager).InnerText;
                if (strEventENName == strEvent)
                {

                    //�õ��¼�����������ģ��
                    nl_DataModel = n_Event.SelectNodes("x:DataModel", m_xmlManager);//���Ҹ��¼���������������ģ��
                    //ѭ��,����ȡ��datamodel��data�ı���������������
                    foreach (XmlNode n_DataModel in nl_DataModel)
                    {
                        vMRClsDef.DataModel oDataModel = new vMRClsDef.DataModel();
                        oDataModel.strDataName = n_DataModel.SelectSingleNode("x:Data/x:DataName", m_xmlManager).InnerText;//��������  
                        oDataModel.strDataCNName = n_DataModel.SelectSingleNode("x:Data/x:DisplayName", m_xmlManager).InnerText;
                        oDataModel.strDataCode = n_DataModel.SelectSingleNode("x:Code", m_xmlManager).InnerText;
                        oDataModel.m_emDataType = vMRClsDef.EnumDataType.STRING;
                        oDataModel.strDataValue = "NULL";
                        oInputDataModel.lstDataModel.Add(oDataModel);
                    }
                    break;
                }
            }
            
        }

        public static bool ObtainDataModelWithEventFromCLIPSDataModel(ref vMRClsDef.InputDataModel oInputDataModel)
        {
            string strFilePath = ClipsConfig.ReadConfig("Filepath");
            string strDataModelFileName = ClipsConfig.ReadConfig("DataModelFileName");
            string strManualAddDataModelFileName = ClipsConfig.ReadConfig("ManualAddDataModelFileName");
            ObtainDataModel(strFilePath, strDataModelFileName, ref oInputDataModel);
            //ObtainDataModel(strFilePath, strManualAddDataModelFileName, ref oInputDataModel);

            return true;
        }

        public static bool ObtainConcludeWithEventFromCLIPSDataModel(string strEvent, ref List<vMRClsDef.DataModel> lstNewFact)
        {
            string strFilePath = ClipsConfig.ReadConfig("Filepath");
            string strConcludeFileName = ClipsConfig.ReadConfig("ConcludeFileName");
            OpenXmlDoc(strFilePath + strConcludeFileName);

            XmlNodeList nl_DataModel = null;
            XmlNodeList nl_Event = FindMulInstance("EventModel");//���ҳ�xml�ļ������еĴ����¼��ڵ�

            foreach (XmlNode n_Event in nl_Event)
            {
                //�õ��¼�����
                string strEventENName = n_Event.SelectSingleNode("x:ENName", m_xmlManager).InnerText;
                if (strEventENName == strEvent)
                {

                    //�õ��¼�����������ģ��
                    nl_DataModel = n_Event.SelectNodes("x:DataModel", m_xmlManager);//���Ҹ��¼���������������ģ��
                    //ѭ��,����ȡ��datamodel��data�ı���������������
                    foreach (XmlNode n_DataModel in nl_DataModel)
                    {
                        vMRClsDef.DataModel oDataModel = new vMRClsDef.DataModel();
                        oDataModel.strDataName = n_DataModel.SelectSingleNode("x:Data/x:DataName", m_xmlManager).InnerText;//�������� 
                        oDataModel.strDataCNName = n_DataModel.SelectSingleNode("x:Data/x:DisplayName", m_xmlManager).InnerText;
                        oDataModel.strDataCode = n_DataModel.SelectSingleNode("x:Code", m_xmlManager).InnerText;
                        oDataModel.m_emDataType = vMRClsDef.EnumDataType.STRING;
                        oDataModel.strDataValue = "NULL";
                        lstNewFact.Add(oDataModel);
                    }
                    break;
                }
            }
            return true;
        }

        public static bool ObtainDataModelWithSymptomsFromCLIPSDataModel(ref vMRClsDef.InputDataModel oInputDataModel)
        {
            //�����ݲ�ʵ��
            return true;
        }

        public static string ObtainDataCNNamewithDataName(vMRClsDef.OutputInfo oOutputInfo, string strDataName)
        {
            return string.Empty;
        }

        public static string ObtainEventCNNamewithEventName(vMRClsDef.OutputInfo oOutputInfo)
        {
            if(lstTriggeringEvents.Count == 0)
            {
                ObtainTriggeringEventListFromCLIPSDataModel();
            }

            foreach(vMRClsDef.TriggeringEvent oTriggeringEvent in  lstTriggeringEvents)
            {
                if(oOutputInfo.oTriggeringEvent.oEvent.strEventName == oTriggeringEvent.oEvent.strEventName)
                {
                    return oTriggeringEvent.oEvent.strEventCNName;
                }
            }

            return string.Empty;
        }

        private static void ObtainTriggeringEventList(string strFilePath, string strFileName)
        {        
            OpenXmlDoc(strFilePath + strFileName);
            XmlNodeList nl_Disease = FindMulInstance("EventModel");//���ҳ�xml�ļ������еĴ����¼��ڵ�

            foreach (XmlNode n_Disease in nl_Disease)
            {
                vMRClsDef.TriggeringEvent oTriggeringEvent = new vMRClsDef.TriggeringEvent();
                oTriggeringEvent.oEvent.strEventName = n_Disease.SelectSingleNode("x:ENName", m_xmlManager).InnerText;
                oTriggeringEvent.oEvent.strEventCNName = n_Disease.SelectSingleNode("x:CNName", m_xmlManager).InnerText;
                ClipsEventsDef.MapEvent(oTriggeringEvent.oEvent.strEventName, ref oTriggeringEvent);
                lstTriggeringEvents.Add(oTriggeringEvent);
            }
        }
        public static bool ObtainTriggeringEventListFromCLIPSDataModel()
        {
            string strFilePath = ClipsConfig.ReadConfig("Filepath");
            string strDataModelFileName = ClipsConfig.ReadConfig("DataModelFileName");
            string strManualAddDataModelFileName = ClipsConfig.ReadConfig("ManualAddDataModelFileName");

            ObtainTriggeringEventList(strFilePath, strDataModelFileName);
            //ObtainTriggeringEventList(strFilePath, strManualAddDataModelFileName);

            return true;
        }

        
    }
}
