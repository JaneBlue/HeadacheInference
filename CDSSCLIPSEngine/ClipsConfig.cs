using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Configuration;

namespace CDSSCLIPSEngine
{
    public static class ClipsConfig
    {
        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="strNodeName"></param>
        /// <returns></returns>
        public static string ReadConfig(string strNodeName)
        {
            XmlDocument xmlDoc = new XmlDocument(); 
            //string strNum = ConfigurationManager.AppSettings["CLIPSAPP_PATH"];
            string str = System.Environment.CurrentDirectory;
            //xmlDoc.Load("..\\output\\debug\\CDSSServer\\EngineServer\\CLIPSApp.xml");
            xmlDoc.Load("F:\\工作空间\\HeadacheInferenceWebservice\\HeadacheInferenceWebservice\\output\\debug\\CDSSServer\\EngineServer\\CLIPSApp.xml");
            string strNodepath = string.Format("/{0}/{1}/{2}", "CLIPSApp", "Config", strNodeName);
            XmlNode n_Node = xmlDoc.SelectSingleNode(strNodepath);
            return n_Node.InnerText;
        }
    }
}
