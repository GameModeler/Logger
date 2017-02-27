using GMLogger.Interfaces;
using GMLogger.Layout;
using GMLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;

namespace GMLogger.Utils
{
    /// <summary>
    /// Util Log Pattern class
    /// </summary>
    public static class LogPatterns
    {
        /// <summary>
        /// Reformate the string pattern from the log
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public static string Reformate(string pattern, ILog log)
        {
            string stackTrace = log.Exception == null ? "" : log.Exception.StackTrace;

            return string.Format(pattern, log.Timestamp, log.Level.GetStringValue(), log.LoggerName, log.Message, stackTrace);
        }

        /// <summary>
        /// Build the xmlTemplate for toast appender
        /// </summary>
        /// <param name="toastXml"></param>
        /// <param name="lines"></param>
        /// <param name="log"></param>
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

        /// <summary>
        /// Use to build the log pattern
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public static string StrRef(this LogElements elem, string option = null)
        {
            
            return option == null ? string.Format("{{{0}}}", (int) elem) : string.Format("{{{0}:{1}}}", (int) elem, option);
        }
    }
}
