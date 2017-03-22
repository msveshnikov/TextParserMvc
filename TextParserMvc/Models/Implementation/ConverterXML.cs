using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace TextParserMvc.Models
{
    public class ConverterXML : IConvert
    {
        public string Convert(Text text)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
            doc.AppendChild(docNode);
            XmlElement root = (XmlElement)doc.AppendChild(doc.CreateElement("Text"));

            foreach (Sentence sentence in text.Sentences)
            {
                var sentenceNode = doc.CreateElement("sentence");
                foreach (string word in sentence.Words)
                {
                    var wordNode = doc.CreateElement("word");
                    wordNode.InnerText = word;
                    sentenceNode.AppendChild(wordNode);
                }
                root.AppendChild(sentenceNode);
            }


            return FormatXML.FormatXMLString(doc);
        }
    }

    static class FormatXML
    {
        public static string FormatXMLString(XmlDocument xd)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (XmlTextWriter xtw = new XmlTextWriter(sw))
            {
                xtw.Formatting = Formatting.Indented;
                xd.WriteTo(xtw);
            }
            return sb.ToString();
        }
    }
}