using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Data;

namespace BookLibrayWeb.Service
{
    public static class Extensions
    {
        public static string AsString(this XmlDocument xmlDoc)
        {
            StringWriter sw = new StringWriter();
            XmlTextWriter tx = new XmlTextWriter(sw);
            xmlDoc.WriteTo(tx);
            string strXmlText = sw.ToString();
            return strXmlText;
        }

        public static XmlDocument AsXml(this string xmlString)
        {
            XmlDocument xm = new XmlDocument();
            xm.LoadXml(xmlString);
            return xm;
        }
        public static XmlElement AsXmlElement(this string xmlString)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlString);
            return doc.DocumentElement;
        }

        public static DataTable AsDataTable(this string xmlString)
        {
            DataSet dataSet = new DataSet();
            XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(xmlString));
            reader.Read();
            string inner = reader.ReadInnerXml();
            dataSet.ReadXml(reader);
            return dataSet.Tables[0];
        }
       
    }
}