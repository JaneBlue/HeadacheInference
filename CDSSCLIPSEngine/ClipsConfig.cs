using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Web;




namespace CDSSCLIPSEngine
{
    public static class ClipsConfig
    {
        /// <summary>
        /// ��ȡ�����ļ�
        /// </summary>
        /// <param name="strNodeName"></param>
        /// <returns></returns>
        public static string ReadConfig(string strNodeName)
        {
            XmlDocument xmlDoc = new XmlDocument(); 
            //string strNum = ConfigurationManager.AppSettings["CLIPSAPP_PATH"];
            string str = AppDomain.CurrentDomain.BaseDirectory;
            xmlDoc.Load(str + "bin\\CDSSServer\\EngineServer\\CLIPSApp.xml");
            string strNodepath = string.Format("/{0}/{1}/{2}", "CLIPSApp", "Config", strNodeName);
            XmlNode n_Node = xmlDoc.SelectSingleNode(strNodepath);
            return n_Node.InnerText;
        }
    }
}
