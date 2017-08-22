using Logger.Interfaces;
using Logger.Layout;
using System.Collections.Generic;
using Windows.Data.Xml.Dom;

namespace Logger.Utils
{
    /// <summary>
    /// Log Patterns
    /// </summary>
    public static class LogPatterns
    {
        /// <summary>
        /// Reformate a log from its elements
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        public static string Reformate(string pattern, ILog log)
        {

            string stackTrace = log.Exception == null ? "" : log.Exception;

            return string.Format(pattern, log.Timestamp, log.Level.GetStringValue(), log.LoggerName, log.Message, stackTrace);
        }

        /// <summary>
        /// Build the toast xml template
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
                stringElements[cmpt].InnerText = Reformate(elem, log);             
                cmpt++;
            }
        }

        /// <summary>
        /// Method to formate log pattern from its elements
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
