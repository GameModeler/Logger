using Logger.Interfaces;
using Logger.Layout;
using Logger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;

namespace Logger.Utils
{
    public static class LogPatterns
    {

        public static string Reformate(string pattern, ILog log)
        {
            string stackTrace = log.Exception == null ? "" : log.Exception.StackTrace;

            return string.Format(pattern, log.Timestamp, log.Level.GetStringValue(), log.LoggerName, log.Message, stackTrace);
        }

        public static void BuildXmlTemplate(this XmlDocument toastXml, List<string> lines, ILog log)
        {
            // Fill in the text elements
            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");

            int cmpt = 0;

            foreach (string elem in lines)
            {
                stringElements[cmpt].AppendChild(toastXml.CreateTextNode(Reformate(elem, log)));
                cmpt++;
            }
        }

        public static string StrRef(this LogElements elem, string option = null)
        {
            
            return option == null ? string.Format("{{{0}}}", (int) elem) : string.Format("{{{0}:{1}}}", (int) elem, option);
        }
    }
}
